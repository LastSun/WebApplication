using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeFirstModelFromDB;

namespace Angular.Controllers
{
    public class ProjectController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            throw new Exception();
            return new {name = "SDF"};
        }

        // POST api/<controller>
        public void Post([FromBody]Project project)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Project.Add(project);
                db.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}