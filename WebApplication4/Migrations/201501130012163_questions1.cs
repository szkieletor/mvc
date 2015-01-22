namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Exam_ExamID", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "Exam_ExamID" });
            AddColumn("dbo.Questions", "ExamID_ExamID", c => c.Int());
            CreateIndex("dbo.Questions", "ExamID_ExamID");
            AddForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams", "ExamID");
            DropColumn("dbo.Questions", "Exam");
            DropColumn("dbo.Questions", "Exam_ExamID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Exam_ExamID", c => c.Int());
            AddColumn("dbo.Questions", "Exam", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "ExamID_ExamID", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "ExamID_ExamID" });
            DropColumn("dbo.Questions", "ExamID_ExamID");
            CreateIndex("dbo.Questions", "Exam_ExamID");
            AddForeignKey("dbo.Questions", "Exam_ExamID", "dbo.Exams", "ExamID");
        }
    }
}
