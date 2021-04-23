using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CleanArchWebapi.Controllers
{
    [EnableCors("*","*","*")]
    public class ExampleController : ApiController
    {
        private string[] S= { "My First Api Example", "Introduction to Webapi" };
        public string[] Get()
        {
            return S;
        }
        public string Get(int id)
        {
            return S[id];
         }
    }
}
