namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        DescA = c.String(),
                        DescB = c.String(),
                        DescC = c.String(),
                        DescD = c.String(),
                        Value = c.Int(nullable: false),
                        Exam = c.Int(nullable: false),
                        Exam_ExamID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Exams", t => t.Exam_ExamID)
                .Index(t => t.Exam_ExamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Exam_ExamID", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "Exam_ExamID" });
            DropTable("dbo.Questions");
        }
    }
}
