using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH10_DividendCalendar
{
    public class CustomExceptionMiddleware
    {
        public async Task Invoke(HttpContext httpContext)
        {
            throw new NotImplementedException();
        }
    }
}
