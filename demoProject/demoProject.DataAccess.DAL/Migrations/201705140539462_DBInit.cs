namespace demoProject.DataAccess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CouresModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EnrollmentModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CouresModel", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.StudentModel", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentModel", "StudentID", "dbo.StudentModel");
            DropForeignKey("dbo.EnrollmentModel", "CourseID", "dbo.CouresModel");
            DropIndex("dbo.EnrollmentModel", new[] { "StudentID" });
            DropIndex("dbo.EnrollmentModel", new[] { "CourseID" });
            DropTable("dbo.StudentModel");
            DropTable("dbo.EnrollmentModel");
            DropTable("dbo.CouresModel");
        }
    }
}
