using CrudWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CrudWebApi
{
    public class ApiKeyhandler : DelegatingHandler

    {
        protected override Task<HttpResponseMessage> SendAsync
            (HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Code for reading the api key from Querystring
            //var querystring = request.RequestUri.ParseQueryString();
            //var apikey = querystring["apikey"];

            // Code to read apikey from header
            var apikey = request.Headers.GetValues("apikey").FirstOrDefault();
            APIKeyEntities entities = new APIKeyEntities();
            var UserObj = entities.APIUsers.Where(x => x.APIUserKey.ToString() == apikey).FirstOrDefault();
            if (UserObj != null)
            {
                var username = UserObj.APIUserName;
                var principal = new ClaimsPrincipal(new GenericIdentity(username, "Apikey"));
                HttpContext.Current.User = principal;
                //return base.SendAsync(request, cancellationToken);

            }
            // we would not use the else clause when its need to redirect to controller, like having 
            //allow anonymous methods
            //else
            //{
            //    var tsc = new TaskCompletionSource<HttpResponseMessage>();
            //    var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            //    tsc.SetResult(response);
            //    return tsc.Task;
            //}
            return base.SendAsync(request, cancellationToken);

        }
    }
    }
    
