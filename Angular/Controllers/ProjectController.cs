using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeFirstModelFromDB;

namespace Angular.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly AngularDbContext _db;

        public ProjectController()
        {
            _db = new AngularDbContext();
        }

        // GET api/<controller>
        public IEnumerable<Project> Get()
        {
            return _db.Project.AsQueryable();
        }

        // GET api/<controller>/5
        public Project Get(int id)
        {
            return _db.Project.Find(id);
        }

        // POST api/<controller>
        public Project Post(Project newProject)
        {
            _db.Project.AddOrUpdate(newProject);
            _db.SaveChanges();
            return newProject;
        }

        // PUT api/<controller>/5
        public void Put(int id, Project project)
        {
            _db.Project.AddOrUpdate(project);
            _db.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var deleteProject = _db.Project.Find(id);
            _db.Project.Remove(deleteProject);
            _db.SaveChanges();
        }
    }
}