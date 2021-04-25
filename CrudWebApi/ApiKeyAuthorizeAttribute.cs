using CrudWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CrudWebApi
{
    public class ApiKeyAuthorizeAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionrole = Roles[0].ToString();
            var username = HttpContext.Current.User.Identity.Name;
            APIKeyEntities entities = new APIKeyEntities();
             var Userobj=  entities.APIUsers.Where(x => x.APIUserName == username).FirstOrDefault();
            if (Userobj != null)
            {
                var Userrole = Userobj.APIUserRole;
                if (actionrole == Userrole)
                {
                    Console.WriteLine("User Authorized");
                }
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

           
        }
    }
}