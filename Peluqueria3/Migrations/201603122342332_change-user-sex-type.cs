namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeusersextype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "sex", c => c.Boolean(nullable: false));
        }
    }
}
