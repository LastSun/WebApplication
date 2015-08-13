using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeFirstModelFromDB
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("ELearning", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Action_UserCourse> Action_UserCourse { get; set; }
        public virtual DbSet<Action_UserQuiz> Action_UserQuiz { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Courseware> Courseware { get; set; }
        public virtual DbSet<Paper> Paper { get; set; }
        public virtual DbSet<Project> Project { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("User_Role");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Login");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claim");
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Class>()
                .HasMany(e => e.Course)
                .WithMany(e => e.Class)
                .Map(m => m.ToTable("Class_Course"));

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

    public partial class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
    }
}