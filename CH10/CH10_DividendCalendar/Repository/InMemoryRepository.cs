using CH10_DividendCalendar.Security.Authentication;
using CH10_DividendCalendar.Security.Authorisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH10_DividendCalendar.Repository
{
    public class InMemoryRepository : IRepository
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public InMemoryRepository()
        {
            var existingApiKeys = new List<ApiKey>
            {
                new ApiKey(1, "Internal", "C5BFF7F0-B4DF-475E-A331-F737424F013C", new DateTime(2019, 01, 01),
                    new List<string>
                    {
                        Roles.Internal
                    }),
                new ApiKey(2, "External", "9218FACE-3EAC-6574-C3F0-08357FEDABE9", new DateTime(2020, 4, 15),
                    new List<string>
                    {
                        Roles.External
                    })
            };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> GetApiKey(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
