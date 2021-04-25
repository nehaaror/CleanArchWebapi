using CrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CrudWebApi.Controllers
{
    public class DepController : ApiController
    {
        MyOrgEntities org = new MyOrgEntities();

        public DepController()
        {
            org.Configuration.ProxyCreationEnabled = false;

        }
        // GET api/<controller>
        [ResponseType(typeof(IEnumerable<Department>))]
        public IHttpActionResult Get()
        {
            return Ok(org.Departments);
        }
        // GET api/<controller>/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult Get(int id)
        {
            Department dep = org.Departments.Find(id);
            if (dep != null)
                return Ok(dep);
            else
                return NotFound();
        }

        // POST api/<controller>
        [ResponseType(typeof(Department))]
        public IHttpActionResult Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                org.Departments.Add(department);
                org.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = department.Did }, department);
            }
            else
                return BadRequest(ModelState);
        }

        // PUT api/<controller>/5
          [ResponseType(typeof(Department))]
        public IHttpActionResult Put(int id, [FromBody] Department department)
        {
            Department dept = org.Departments.Find(id);
            if (dept == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                org.Entry(department).State = System.Data.Entity.EntityState.Modified;
                org.SaveChanges();
                return Ok(department);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<controller>/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult Delete(int id)
        {

            Department dep = org.Departments.Find(id);
            if (dep != null)
            {
                org.Departments.Remove(dep);
                org.SaveChanges();
                return Ok(dep);
            }
            else
            {
                return NotFound();
            }
        }
    }
}