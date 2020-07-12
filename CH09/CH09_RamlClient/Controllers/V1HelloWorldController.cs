// Template: Controller Implementation (ApiControllerImplementation.t4) version 5.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CH09_RamlClient.Api.Models;

namespace CH09_RamlClient.Api
{
    public partial class v1HelloWorldController : Iv1HelloWorldController
    {

        /// <summary>
		/// /helloWorld
		/// </summary>
		/// <returns>HelloWorldGet200</returns>
        public async Task<IHttpActionResult> Get()
        {
            // TODO: implement Get - route: helloWorld/helloWorld
			// var result = new HelloWorldGet200();
			// return Ok(result);
			return Ok("Hello World!");
        }
    }
}
