namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        startTime = c.DateTime(nullable: false),
                        endTime = c.DateTime(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false, maxLength: 50),
                        lastName = c.String(maxLength: 50),
                        phone = c.String(maxLength: 15),
                        sex = c.Int(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 50),
                        isAdmin = c.Boolean(nullable: false),
                        lastLogged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        price = c.Double(nullable: false),
                        duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkItemAppointments",
                c => new
                    {
                        AppointmentRefId = c.Int(nullable: false),
                        WorkItemRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppointmentRefId, t.WorkItemRefId })
                .ForeignKey("dbo.Appointments", t => t.AppointmentRefId, cascadeDelete: true)
                .ForeignKey("dbo.WorkItems", t => t.WorkItemRefId, cascadeDelete: true)
                .Index(t => t.AppointmentRefId)
                .Index(t => t.WorkItemRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItemAppointments", "WorkItemRefId", "dbo.WorkItems");
            DropForeignKey("dbo.WorkItemAppointments", "AppointmentRefId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "userID", "dbo.Users");
            DropIndex("dbo.WorkItemAppointments", new[] { "WorkItemRefId" });
            DropIndex("dbo.WorkItemAppointments", new[] { "AppointmentRefId" });
            DropIndex("dbo.Appointments", new[] { "userID" });
            DropTable("dbo.WorkItemAppointments");
            DropTable("dbo.WorkItems");
            DropTable("dbo.Users");
            DropTable("dbo.Appointments");
        }
    }
}
