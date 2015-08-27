namespace CodeFirstModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Action_UserCourse
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
