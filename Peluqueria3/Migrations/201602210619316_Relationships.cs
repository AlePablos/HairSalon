namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Appointment_WorkItem", "appointmentID");
            CreateIndex("dbo.Appointment_WorkItem", "workItemID");
            AddForeignKey("dbo.Appointment_WorkItem", "appointmentID", "dbo.Appointments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Appointment_WorkItem", "workItemID", "dbo.WorkItems", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment_WorkItem", "workItemID", "dbo.WorkItems");
            DropForeignKey("dbo.Appointment_WorkItem", "appointmentID", "dbo.Appointments");
            DropIndex("dbo.Appointment_WorkItem", new[] { "workItemID" });
            DropIndex("dbo.Appointment_WorkItem", new[] { "appointmentID" });
        }
    }
}
