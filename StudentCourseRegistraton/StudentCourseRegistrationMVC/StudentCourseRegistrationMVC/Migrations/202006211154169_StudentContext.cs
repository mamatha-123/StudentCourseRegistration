namespace StudentCourseRegistrationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        studentId = c.Int(nullable: false),
                        studentName = c.String(nullable: false, maxLength: 20),
                        email = c.String(nullable: false, maxLength: 30),
                        phoneNo = c.String(nullable: false, maxLength: 10),
                        country = c.String(nullable: false, maxLength: 20),
                        userName = c.String(nullable: false, maxLength: 20),
                        password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.studentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
        }
    }
}
