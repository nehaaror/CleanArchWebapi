using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CleanArchWebapi.Controllers
{
    public class ExampleController : ApiController
    {
        public string Get()
        {
            return "My First Api Example";
        }
    }
}
