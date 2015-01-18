using System.Data.Entity.Migrations;

namespace WebApplication4.Migrations
{
    public partial class addedUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfJoin", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "DateOfLastLogin", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Parent_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Parent_Id");
            AddForeignKey("dbo.AspNetUsers", "Parent_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Parent_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Parent_Id" });
            DropColumn("dbo.AspNetUsers", "Parent_Id");
            DropColumn("dbo.AspNetUsers", "DateOfLastLogin");
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "DateOfJoin");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "Email");
        }
    }
}
