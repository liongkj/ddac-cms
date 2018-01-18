namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Destination", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "Source", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Source", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Destination", c => c.String(nullable: false));
        }
    }
}
