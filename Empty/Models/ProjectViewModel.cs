using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstModelFromDB;

namespace Empty.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProjectsViewModel
    {
        public IList<ProjectViewModel> Projects { get; set; }
    }
}