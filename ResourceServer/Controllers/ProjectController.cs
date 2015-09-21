using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using CodeFirstModelFromDB;

namespace ResourceServer.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly ElearningDbContext _db;
        private readonly DbSet<Project> _projectTable;

        public ProjectController()
        {
            _db = new ElearningDbContext();
            _projectTable= _db.Project;
        }

//        [Authorize]
        // GET api/<controller>
        public IEnumerable<Project> Get()
        {
            return _projectTable.AsQueryable();
        }

        // GET api/<controller>/5
        public Project Get(int id)
        {
            return _projectTable.Find(id);
        }

        // POST api/<controller>
        public Project Post(Project newProject)
        {
            _projectTable.AddOrUpdate(newProject);
            _db.SaveChanges();
            return newProject;
        }

        // PUT api/<controller>/5
        public void Put(int id, Project project)
        {
            _projectTable.AddOrUpdate(project);
            _db.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var deleteProject = _projectTable.Find(id);
            _projectTable.Remove(deleteProject);
            _db.SaveChanges();
        }
    }
}