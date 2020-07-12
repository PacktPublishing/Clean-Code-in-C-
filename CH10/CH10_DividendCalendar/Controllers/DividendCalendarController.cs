using CH10_DividendCalendar.Models;
using CH10_DividendCalendar.Security.Authorisation;
using CH10_DividendCalendar.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CH10_DividendCalendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DividendCalendarController : ControllerBase
    {
        private AppSettings _appSettings;

        public DividendCalendarController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [Authorize(Policy = Policies.Internal)]
        [HttpGet("internal")]
        public IActionResult GetDividendCalendar()
        {
            if (CanExecuteApiRequest())
                return new ObjectResult(JsonConvert.SerializeObject(BuildDividendCalendar()));
            else
                return new ObjectResult(ThrottleMessage());
        }

        [Authorize(Policy = Policies.External)]
        [HttpGet("external")]
        public IActionResult External()
        {
            var message = "External access is currently unavailable.";
            return new ObjectResult(message);
        }

        private string ThrottleMessage()
        {
            return "This API Call can only be made once on the 25th of each month.";
        }

        private DateTime? FormatStringDate(string date)
        {
            return string.IsNullOrEmpty(date) ? (DateTime?)null : DateTime.Parse(date);
        }

        private List<Dividend> BuildDividendCalendar()
        {
            const string MIC = "XLON";
            var thisYearsDividends = new List<Dividend>();

            var companies = GetCompanies(MIC);

            foreach (var company in companies.Results)
            {
                var dividends = GetDividends(MIC, company.Ticker);
                if (dividends.Results == null)
                    continue;
                var currentDividend = dividends.Results.FirstOrDefault();
                if (currentDividend == null || currentDividend["payableDt"] == null)
                    continue;
                var dateDiff = DateTime.Compare(DateTime.Parse(currentDividend["payableDt"]), new DateTime(DateTime.Now.Year - 1, 12, 31));
                if (dateDiff > 0)
                {
                    var payableDate = DateTime.Parse(currentDividend["payableDt"]);
                    var dividend = new Dividend()
                    {
                        Mic = MIC,
                        Ticker = company.Ticker,
                        CompanyName = company.CompanyName,
                        ExDividendDate = FormatStringDate(currentDividend["exDividendDt"]),
                        DeclarationDate = FormatStringDate(currentDividend["declarationDt"]),
                        RecordDate = FormatStringDate(currentDividend["recordDt"]),
                        PaymentDate = FormatStringDate(currentDividend["payableDt"]),
                        Amount = float.Parse(currentDividend["amount"])
                    };
                    thisYearsDividends.Add(dividend);
                }
            }
            return thisYearsDividends;
        }

        private async Task<string> GetMorningstarApiKey()
        {
            try
            {
                AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
                KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                var secret = await keyVaultClient.GetSecretAsync(ApiKeyConstants.MorningstarApiKeyUrl)
                        .ConfigureAwait(false);
                return secret.Value;
            }
            catch (KeyVaultErrorException keyVaultException)
            {
                return keyVaultException.Message;
            }
        }

        private Companies GetCompanies(string mic)
        {
            var client = new RestClient($"https://morningstar1.p.rapidapi.com/companies/list-by-exchange?Mic={mic}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "morningstar1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", GetMorningstarApiKey().Result);
            request.AddHeader("accept", "string");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Companies>(response.Content);
        }

        private Dividends GetDividends(string mic, string ticker)
        {
            var client = new RestClient($"https://morningstar1.p.rapidapi.com/dividends?Ticker={ticker}&Mic={mic}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "morningstar1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", GetMorningstarApiKey().Result);
            request.AddHeader("accept", "string");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dividends>(response.Content);
        }

        private DateTime? SetMorningstarNextRunDate()
        {
            int month;

            if (DateTime.Now.Day < 25)
                month = DateTime.Now.Month;
            else
                month = DateTime.Now.AddMonths(1).Month;

            var date = new DateTime(DateTime.Now.Year, month, ApiKeyConstants.ThrottleMonthDay);

            AppSettings.AddOrUpdateAppSetting<DateTime?>(
                "MorningstarNextRunDate",
                date
            );

            return date;
        }

        private bool CanExecuteApiRequest()
        {
            DateTime? nextRunDate = _appSettings.MorningstarNextRunDate;

            if (!nextRunDate.HasValue)
                nextRunDate = SetMorningstarNextRunDate();

            if (DateTime.Now.Day == ApiKeyConstants.ThrottleMonthDay)
            {
                if (nextRunDate.Value.Month == DateTime.Now.Month)
                {
                    SetMorningstarNextRunDate();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
