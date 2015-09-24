using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ConsoleApplication1;
using Microsoft.AspNet.Mvc;

namespace WebApplication.ResourceServer.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ElearningDbContext _db;
        private readonly DbSet<Project> _projectTable;

        public ProjectController()
        {
            _db = new ElearningDbContext();
            _projectTable= _db.Project;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _projectTable.AsQueryable();
        }

        [HttpGet("{id}")]
        // GET api/<controller>/5
        public Project Get(int id)
        {
            return _projectTable.Find(id);
        }

        [HttpPost]
        // POST api/<controller>
        public Project Post(Project newProject)
        {
            _projectTable.AddOrUpdate(newProject);
            _db.SaveChanges();
            return newProject;
        }

        [HttpPut("{id}")]
        // PUT api/<controller>/5
        public void Put(int id, Project project)
        {
            _projectTable.AddOrUpdate(project);
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var deleteProject = _projectTable.Find(id);
            _projectTable.Remove(deleteProject);
            _db.SaveChanges();
        }
    }
}