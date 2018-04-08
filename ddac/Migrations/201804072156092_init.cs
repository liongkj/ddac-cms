namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
                        Status = c.String(),
                        Customer_CusId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Customers", t => t.Customer_CusId)
                .Index(t => t.Customer_CusId);
            
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
                        Ship_ShipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Ships", t => t.Ship_ShipId, cascadeDelete: true)
                .Index(t => t.Ship_ShipId);
            
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
            DropForeignKey("dbo.Schedules", "Ship_ShipId", "dbo.Ships");
            DropForeignKey("dbo.Items", "Customer_CusId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropIndex("dbo.Schedules", new[] { "Ship_ShipId" });
            DropIndex("dbo.Items", new[] { "Customer_CusId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropTable("dbo.Ships");
            DropTable("dbo.Schedules");
            DropTable("dbo.Items");
            DropTable("dbo.Users");
            DropTable("dbo.Customers");
        }
    }
}
