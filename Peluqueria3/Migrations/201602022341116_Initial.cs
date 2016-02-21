namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        firstName = c.String(maxLength: 50),
                        lastName = c.String(maxLength: 50),
                        phone = c.String(maxLength: 15),
                        sex = c.Boolean(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 50),
                        isAdmin = c.Boolean(nullable: false),
                        lastLogged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Appointment_WorkItem",
                c => new
                    {
                        appointmentID = c.Int(nullable: false),
                        workItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.appointmentID, t.workItemID });
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "userID", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "userID" });
            DropTable("dbo.WorkItems");
            DropTable("dbo.Appointment_WorkItem");
            DropTable("dbo.Users");
            DropTable("dbo.Appointments");
        }
    }
}
