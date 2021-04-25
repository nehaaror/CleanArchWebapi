using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudWebApi.Controllers
{
    public class TestController : ApiController
    {
        [ApiKeyAuthorizeAttribute(Roles = "A")]
        public IHttpActionResult Get()
        {
            return Ok<string>("You are Welcome: "+ User.Identity.Name);
        }
        [ApiKeyAuthorizeAttribute(Roles = "U")]
        //[AllowAnonymous]
        public IHttpActionResult Getbyid(int id)
        {
            return Ok<string>("You are Welcome: " + id + User.Identity.Name);
        }

    }
}
