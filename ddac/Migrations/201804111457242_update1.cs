namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Agent_UserId = c.Int(),
                        Item_ItemId = c.Int(),
                        Schedule_ScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Users", t => t.Agent_UserId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleId)
                .Index(t => t.Agent_UserId)
                .Index(t => t.Item_ItemId)
                .Index(t => t.Schedule_ScheduleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserType = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Destination = c.Int(nullable: false),
                        Source = c.Int(nullable: false),
                        Customer_CusId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Customers", t => t.Customer_CusId)
                .Index(t => t.Customer_CusId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CusId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        ShippingAddress_Addressline1 = c.String(nullable: false),
                        ShippingAddress_City = c.String(nullable: false),
                        ShippingAddress_Postcode = c.String(nullable: false),
                        ShippingAddress_StateOrProvince = c.String(nullable: false),
                        ShippingAddress_Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CusId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Departure = c.DateTime(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                        Destination = c.Int(nullable: false),
                        Source = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ShipId = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipId = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        IMO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Schedule_ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Bookings", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "Customer_CusId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "Agent_UserId", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Items", new[] { "Customer_CusId" });
            DropIndex("dbo.Bookings", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.Bookings", new[] { "Item_ItemId" });
            DropIndex("dbo.Bookings", new[] { "Agent_UserId" });
            DropTable("dbo.Ships");
            DropTable("dbo.Schedules");
            DropTable("dbo.Customers");
            DropTable("dbo.Items");
            DropTable("dbo.Users");
            DropTable("dbo.Bookings");
        }
    }
}
