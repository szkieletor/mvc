namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Desc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Desc");
        }
    }
}
