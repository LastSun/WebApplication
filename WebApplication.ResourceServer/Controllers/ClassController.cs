using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using CodeFirstModel;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace WebApplication.ResourceServer.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private readonly ElearningDbContext _db;
        private readonly IDbSet<Class> _classTable;


        public ClassController()
        {
            _db = new ElearningDbContext();
            _classTable = _db.Class;
        }

        // GET api/<controller>
        public IEnumerable<Class> Get()
        {
            return _classTable.AsQueryable();
        }

        // GET api/<controller>/5
        public Class Get(int id)
        {
            return _classTable.Find(id);
        }

        // POST api/<controller>
        public Class Post(Class @class)
        {
            _classTable.AddOrUpdate(@class);
            _db.SaveChanges();
            return @class;
        }

        // PUT api/<controller>/5
        public void Put(int id, Class @class)
        {
            _classTable.AddOrUpdate(@class);
            _db.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var @class = _classTable.Find(id);
            _classTable.Remove(@class);
            _db.SaveChanges();
        }
    }
}