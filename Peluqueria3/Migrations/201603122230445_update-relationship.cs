namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterelationship : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.WorkItemAppointments", name: "WorkItem_ID", newName: "WorkItemRefId");
            RenameColumn(table: "dbo.WorkItemAppointments", name: "Appointment_ID", newName: "AppointmentRefId");
            RenameIndex(table: "dbo.WorkItemAppointments", name: "IX_Appointment_ID", newName: "IX_AppointmentRefId");
            RenameIndex(table: "dbo.WorkItemAppointments", name: "IX_WorkItem_ID", newName: "IX_WorkItemRefId");
            DropPrimaryKey("dbo.WorkItemAppointments");
            AddPrimaryKey("dbo.WorkItemAppointments", new[] { "AppointmentRefId", "WorkItemRefId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.WorkItemAppointments");
            AddPrimaryKey("dbo.WorkItemAppointments", new[] { "WorkItem_ID", "Appointment_ID" });
            RenameIndex(table: "dbo.WorkItemAppointments", name: "IX_WorkItemRefId", newName: "IX_WorkItem_ID");
            RenameIndex(table: "dbo.WorkItemAppointments", name: "IX_AppointmentRefId", newName: "IX_Appointment_ID");
            RenameColumn(table: "dbo.WorkItemAppointments", name: "AppointmentRefId", newName: "Appointment_ID");
            RenameColumn(table: "dbo.WorkItemAppointments", name: "WorkItemRefId", newName: "WorkItem_ID");
        }
    }
}
