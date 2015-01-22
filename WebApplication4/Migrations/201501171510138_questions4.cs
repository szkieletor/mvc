namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "ExamID_ExamID" });
            AddColumn("dbo.Questions", "ExamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "ExamID");
            AddForeignKey("dbo.Questions", "ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
            DropColumn("dbo.Questions", "ExamID_ExamID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "ExamID_ExamID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "ExamID", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "ExamID" });
            DropColumn("dbo.Questions", "ExamID");
            CreateIndex("dbo.Questions", "ExamID_ExamID");
            AddForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
        }
    }
}
