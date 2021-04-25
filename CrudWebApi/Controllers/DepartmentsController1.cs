using CrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudWebApi.Controllers
{
    public class DepartmentsController : ApiController
    {
        MyOrgEntities org = new MyOrgEntities();

        public DepartmentsController()
        {
          org.Configuration.ProxyCreationEnabled = false;

        }
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<IEnumerable<Department>>
                (HttpStatusCode.OK, org.Departments);
        }
        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            Department dep = org.Departments.Find(id);
            if (dep != null)
                return Request.CreateResponse<Department>(HttpStatusCode.OK, dep);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Record does not exist");
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                org.Departments.Add(department);
                org.SaveChanges();
                return Request.CreateResponse<Department>(HttpStatusCode.Created, department);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] Department department)
        {
            Department dept = org.Departments.Find(id);
            if(dept==null)
            {
               return Request.CreateResponse(HttpStatusCode.NotFound, "Dept does not exists");
            }
            if (ModelState.IsValid)
            {
                org.Entry(department).State = System.Data.Entity.EntityState.Modified;
                org.SaveChanges();
                return Request.CreateResponse<Department>(HttpStatusCode.OK, department);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            
            Department dep = org.Departments.Find(id);
            if (dep != null)
            {
                org.Departments.Remove(dep);
                org.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, dep);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Record does not exist");
            }
        }
    }
}