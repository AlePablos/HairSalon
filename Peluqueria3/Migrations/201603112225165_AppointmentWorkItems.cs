namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentWorkItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkItems", "Appointment_ID", c => c.Int());
            CreateIndex("dbo.WorkItems", "Appointment_ID");
            AddForeignKey("dbo.WorkItems", "Appointment_ID", "dbo.Appointments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItems", "Appointment_ID", "dbo.Appointments");
            DropIndex("dbo.WorkItems", new[] { "Appointment_ID" });
            DropColumn("dbo.WorkItems", "Appointment_ID");
        }
    }
}
