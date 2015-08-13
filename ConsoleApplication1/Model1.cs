using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConsoleApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model21")
        {
        }

        public virtual DbSet<Action_UserCourse> Action_UserCourse { get; set; }
        public virtual DbSet<Action_UserQuiz> Action_UserQuiz { get; set; }
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Courseware> Courseware { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Paper> Paper { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Class>()
                .HasMany(e => e.Course)
                .WithMany(e => e.Class)
                .Map(m =>m.ToTable("Class_Course"));

            modelBuilder.Entity<Class>()
                .HasMany(e => e.User)
                .WithMany(e => e.Class)
                .Map(m => m.ToTable("User_Class"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Action_UserCourse)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quiz>()
                .HasMany(e => e.Action_UserQuiz)
                .WithRequired(e => e.Quiz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithMany(e => e.Role)
                .Map(m => m.ToTable("User_Role"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Action_UserCourse)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Action_UserQuiz)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
