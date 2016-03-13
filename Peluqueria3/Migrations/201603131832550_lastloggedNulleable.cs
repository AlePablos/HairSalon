namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastloggedNulleable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "lastLogged", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "lastLogged", c => c.DateTime(nullable: false));
        }
    }
}
