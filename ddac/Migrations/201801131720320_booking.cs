namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Departure = c.DateTime(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                        ShipSize = c.String(),
                        Destination = c.String(),
                        Source = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Year = c.DateTime(nullable: false),
                        IMO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ships");
            DropTable("dbo.Bookings");
        }
    }
}
