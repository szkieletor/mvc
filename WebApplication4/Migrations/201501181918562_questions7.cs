namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Correct", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Correct", c => c.String());
        }
    }
}
