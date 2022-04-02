namespace Library_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Edition = c.Int(nullable: false),
                        No_of_Total_Copy = c.Int(nullable: false),
                        No_of_Available_Copy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollegeId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailId = c.String(),
                        DOB = c.DateTime(nullable: false),
                        MobileNum = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        RollNo = c.Int(nullable: false),
                        Branch = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecureToken = c.String(),
                        StudentId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "StudentId", "dbo.Students");
            DropIndex("dbo.Tokens", new[] { "StudentId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Students");
            DropTable("dbo.Books");
        }
    }
}
