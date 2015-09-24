using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ConsoleApplication1;
using Microsoft.AspNet.Mvc;

namespace WebApplication.ResourceServer.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private readonly ElearningDbContext _db;
        private readonly DbSet<Class> _classTable;


        public ClassController()
        {
            _db = new ElearningDbContext();
            _classTable = _db.Class;
        }

        [HttpGet]
        // GET api/<controller>
        public IEnumerable<Class> Get()
        {
            return _classTable.AsQueryable();
        }

        [HttpGet("{id}")]
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