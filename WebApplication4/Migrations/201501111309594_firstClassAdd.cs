using System.Data.Entity.Migrations;

namespace WebApplication4.Migrations
{
    public partial class firstClassAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        ClassTeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassroomID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ClassRoom_ClassroomID = c.Int(),
                    })
                .PrimaryKey(t => t.GradeID)
                .ForeignKey("dbo.Classrooms", t => t.ClassRoom_ClassroomID)
                .Index(t => t.ClassRoom_ClassroomID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Grade_GradeID = c.Int(),
                        Teacher_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Grades", t => t.Grade_GradeID)
                .ForeignKey("dbo.AspNetUsers", t => t.Teacher_Id)
                .Index(t => t.Grade_GradeID)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        ExamResultID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        CurseID = c.Int(nullable: false),
                        Marks = c.String(),
                    })
                .PrimaryKey(t => t.ExamResultID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ExamType_ExamTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ExamID)
                .ForeignKey("dbo.ExamTypes", t => t.ExamType_ExamTypeID)
                .Index(t => t.ExamType_ExamTypeID);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        ExamTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExamTypeID);
            
            AddColumn("dbo.AspNetUsers", "Classroom_ClassroomID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Classroom_ClassroomID");
            AddForeignKey("dbo.AspNetUsers", "Classroom_ClassroomID", "dbo.Classrooms", "ClassroomID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "ExamType_ExamTypeID", "dbo.ExamTypes");
            DropForeignKey("dbo.ExamResults", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.AspNetUsers", "Classroom_ClassroomID", "dbo.Classrooms");
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Grade_GradeID", "dbo.Grades");
            DropForeignKey("dbo.Grades", "ClassRoom_ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Exams", new[] { "ExamType_ExamTypeID" });
            DropIndex("dbo.ExamResults", new[] { "ExamID" });
            DropIndex("dbo.AspNetUsers", new[] { "Classroom_ClassroomID" });
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropIndex("dbo.Courses", new[] { "Grade_GradeID" });
            DropIndex("dbo.Grades", new[] { "ClassRoom_ClassroomID" });
            DropColumn("dbo.AspNetUsers", "Classroom_ClassroomID");
            DropTable("dbo.ExamTypes");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamResults");
            DropTable("dbo.Courses");
            DropTable("dbo.Grades");
            DropTable("dbo.Classrooms");
        }
    }
}
