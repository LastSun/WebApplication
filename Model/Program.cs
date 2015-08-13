using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db= new ELearningContainer())
            {
                db.Project.Add(new Project());
                db.SaveChanges();
            }
        }
    }
}
