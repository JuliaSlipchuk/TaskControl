namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInitialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                        Budget = c.Long(nullable: false),
                        Customer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Progress = c.Double(nullable: false),
                        Status = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        WorkLoad = c.Double(nullable: false),
                        WorkerId = c.Int(),
                        ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Workers", t => t.WorkerId)
                .Index(t => t.WorkerId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Salary = c.Int(nullable: false),
                        Сongestion = c.Double(nullable: false),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WorkingDirection = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Workers", new[] { "TeamId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Workers");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
