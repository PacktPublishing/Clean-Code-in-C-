using CH10_DividendCalendar.Security.Authentication;
using System.Threading.Tasks;

namespace CH10_DividendCalendar.Repository
{
    public interface IRepository
    {
        Task<ApiKey> GetApiKey(string providedApiKey);
    }
}
