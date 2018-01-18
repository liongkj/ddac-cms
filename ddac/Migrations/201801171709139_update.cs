namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "ShipSize", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Destination", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Source", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Source", c => c.String());
            AlterColumn("dbo.Bookings", "Destination", c => c.String());
            AlterColumn("dbo.Bookings", "ShipSize", c => c.String());
        }
    }
}
