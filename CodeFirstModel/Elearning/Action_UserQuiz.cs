using System.ComponentModel.DataAnnotations;

namespace CodeFirstModel
{
    public partial class Action_UserQuiz
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }

        public virtual User User { get; set; }
    }
}
