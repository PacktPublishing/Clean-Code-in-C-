// Template: Controller Interface (ApiControllerInterface.t4) version 5.0

using System.Threading.Tasks;
using System.Web.Http;

namespace CH09_RamlClient.Api
{
    public interface Iv1HelloWorldController
    {

        Task<IHttpActionResult> Get();
    }
}
