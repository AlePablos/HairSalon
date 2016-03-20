namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "status");
        }
    }
}
