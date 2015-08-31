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
    public class UserController : ApiController
    {
        private readonly AngularDbContext _db;
        private readonly IDbSet<User> _userTable;

        public UserController()
        {
            _db=new AngularDbContext();
            _userTable = _db.Users;
        }

        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            return _userTable.AsQueryable();
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            return _userTable.Find(id);
        }

        // POST api/<controller>
        public User Post(User user)
        {
            _userTable.AddOrUpdate(user);
            _db.SaveChanges();
            return user;

        }

        // PUT api/<controller>/5
        public void Put(int id, User user)
        {
            _userTable.AddOrUpdate(user);
            _db.SaveChanges();

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var deleteProject = _userTable.Find(id);
            _userTable.Remove(deleteProject);
            _db.SaveChanges();

        }
    }
}