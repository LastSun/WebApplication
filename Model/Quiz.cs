//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quiz()
        {
            this.Action_User_Quiz = new HashSet<Action_UserQuiz>();
        }
    
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> PaperId { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Course Course { get; set; }
        public virtual Paper Paper { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action_UserQuiz> Action_User_Quiz { get; set; }
    }
}
