namespace CodeFirstModelFromDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "Name");
        }
    }
}
