using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Model.CodeFirst
{
    public class TestDbContext : IdentityDbContext<TestUser>
    {
        public TestDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }

    public class TestUser : IdentityUser
    {

    }
}