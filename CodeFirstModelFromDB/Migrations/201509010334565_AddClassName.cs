namespace CodeFirstModelFromDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Class", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Class", "Name");
        }
    }
}
