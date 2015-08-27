namespace CodeFirstModelFromDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Action_UserCourse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoursewareId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courseware", t => t.CoursewareId)
                .Index(t => t.CoursewareId);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        CourseId = c.Int(),
                        PaperId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Paper", t => t.PaperId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.CourseId)
                .Index(t => t.PaperId);
            
            CreateTable(
                "dbo.Action_UserQuiz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        QuizId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Quiz", t => t.QuizId)
                .Index(t => t.UserId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User_Role",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Paper",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courseware",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Class_Course",
                c => new
                    {
                        Class_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Class_Id, t.Course_Id })
                .ForeignKey("dbo.Class", t => t.Class_Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Class_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.User_Class",
                c => new
                    {
                        Class_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Class_Id, t.User_Id })
                .ForeignKey("dbo.Class", t => t.Class_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.Class_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Project_Course",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Project_Id })
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Role", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Project_Course", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.Project_Course", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Course", "CoursewareId", "dbo.Courseware");
            DropForeignKey("dbo.User_Class", "User_Id", "dbo.User");
            DropForeignKey("dbo.User_Class", "Class_Id", "dbo.Class");
            DropForeignKey("dbo.Quiz", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Quiz", "PaperId", "dbo.Paper");
            DropForeignKey("dbo.Quiz", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Action_UserQuiz", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.User_Role", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Login", "UserId", "dbo.User");
            DropForeignKey("dbo.Claim", "UserId", "dbo.User");
            DropForeignKey("dbo.Action_UserQuiz", "UserId", "dbo.User");
            DropForeignKey("dbo.Action_UserCourse", "UserId", "dbo.User");
            DropForeignKey("dbo.Class", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Class_Course", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Class_Course", "Class_Id", "dbo.Class");
            DropForeignKey("dbo.Action_UserCourse", "CourseId", "dbo.Course");
            DropIndex("dbo.Project_Course", new[] { "Project_Id" });
            DropIndex("dbo.Project_Course", new[] { "Course_Id" });
            DropIndex("dbo.User_Class", new[] { "User_Id" });
            DropIndex("dbo.User_Class", new[] { "Class_Id" });
            DropIndex("dbo.Class_Course", new[] { "Course_Id" });
            DropIndex("dbo.Class_Course", new[] { "Class_Id" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.User_Role", new[] { "RoleId" });
            DropIndex("dbo.User_Role", new[] { "UserId" });
            DropIndex("dbo.Login", new[] { "UserId" });
            DropIndex("dbo.Claim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", new[] { "ProjectId" });
            DropIndex("dbo.Action_UserQuiz", new[] { "QuizId" });
            DropIndex("dbo.Action_UserQuiz", new[] { "UserId" });
            DropIndex("dbo.Quiz", new[] { "PaperId" });
            DropIndex("dbo.Quiz", new[] { "CourseId" });
            DropIndex("dbo.Quiz", new[] { "ProjectId" });
            DropIndex("dbo.Class", new[] { "ProjectId" });
            DropIndex("dbo.Course", new[] { "CoursewareId" });
            DropIndex("dbo.Action_UserCourse", new[] { "CourseId" });
            DropIndex("dbo.Action_UserCourse", new[] { "UserId" });
            DropTable("dbo.Project_Course");
            DropTable("dbo.User_Class");
            DropTable("dbo.Class_Course");
            DropTable("dbo.Role");
            DropTable("dbo.Courseware");
            DropTable("dbo.Paper");
            DropTable("dbo.User_Role");
            DropTable("dbo.Login");
            DropTable("dbo.Claim");
            DropTable("dbo.User");
            DropTable("dbo.Action_UserQuiz");
            DropTable("dbo.Quiz");
            DropTable("dbo.Project");
            DropTable("dbo.Class");
            DropTable("dbo.Course");
            DropTable("dbo.Action_UserCourse");
        }
    }
}
