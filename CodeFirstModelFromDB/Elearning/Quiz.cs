namespace CodeFirstModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quiz")]
    public partial class Quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quiz()
        {
            Action_UserQuiz = new HashSet<Action_UserQuiz>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int? CourseId { get; set; }

        public int? PaperId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action_UserQuiz> Action_UserQuiz { get; set; }

        public virtual Course Course { get; set; }

        public virtual Paper Paper { get; set; }

        public virtual Project Project { get; set; }
    }
}
