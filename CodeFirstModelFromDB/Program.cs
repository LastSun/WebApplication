using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstModelFromDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.Initialize(true);
                db.Project.Add(new Project());
                db.SaveChanges();
            }
        }
    }
}
