namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "ExamID_ExamID" });
            AlterColumn("dbo.Questions", "ExamID_ExamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "ExamID_ExamID");
            AddForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "ExamID_ExamID" });
            AlterColumn("dbo.Questions", "ExamID_ExamID", c => c.Int());
            CreateIndex("dbo.Questions", "ExamID_ExamID");
            AddForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams", "ExamID");
        }
    }
}
