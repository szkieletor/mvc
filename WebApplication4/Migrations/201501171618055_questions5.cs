namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Correct", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Correct");
        }
    }
}
