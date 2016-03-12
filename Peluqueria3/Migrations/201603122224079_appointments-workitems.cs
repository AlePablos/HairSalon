namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentsworkitems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkItems", "Appointment_ID", "dbo.Appointments");
            DropForeignKey("dbo.Appointment_WorkItem", "appointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointment_WorkItem", "workItemID", "dbo.WorkItems");
            DropIndex("dbo.WorkItems", new[] { "Appointment_ID" });
            DropIndex("dbo.Appointment_WorkItem", new[] { "appointmentID" });
            DropIndex("dbo.Appointment_WorkItem", new[] { "workItemID" });
            CreateTable(
                "dbo.WorkItemAppointments",
                c => new
                    {
                        WorkItem_ID = c.Int(nullable: false),
                        Appointment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkItem_ID, t.Appointment_ID })
                .ForeignKey("dbo.WorkItems", t => t.WorkItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.Appointments", t => t.Appointment_ID, cascadeDelete: true)
                .Index(t => t.WorkItem_ID)
                .Index(t => t.Appointment_ID);
            
            DropColumn("dbo.WorkItems", "Appointment_ID");
            DropTable("dbo.Appointment_WorkItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Appointment_WorkItem",
                c => new
                    {
                        appointmentID = c.Int(nullable: false),
                        workItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.appointmentID, t.workItemID });
            
            AddColumn("dbo.WorkItems", "Appointment_ID", c => c.Int());
            DropForeignKey("dbo.WorkItemAppointments", "Appointment_ID", "dbo.Appointments");
            DropForeignKey("dbo.WorkItemAppointments", "WorkItem_ID", "dbo.WorkItems");
            DropIndex("dbo.WorkItemAppointments", new[] { "Appointment_ID" });
            DropIndex("dbo.WorkItemAppointments", new[] { "WorkItem_ID" });
            DropTable("dbo.WorkItemAppointments");
            CreateIndex("dbo.Appointment_WorkItem", "workItemID");
            CreateIndex("dbo.Appointment_WorkItem", "appointmentID");
            CreateIndex("dbo.WorkItems", "Appointment_ID");
            AddForeignKey("dbo.Appointment_WorkItem", "workItemID", "dbo.WorkItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Appointment_WorkItem", "appointmentID", "dbo.Appointments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WorkItems", "Appointment_ID", "dbo.Appointments", "ID");
        }
    }
}
