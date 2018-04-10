namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
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
            
            AddColumn("dbo.Schedules", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Schedule_ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Bookings", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Bookings", "Agent_UserId", "dbo.Users");
            DropIndex("dbo.Bookings", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.Bookings", new[] { "Item_ItemId" });
            DropIndex("dbo.Bookings", new[] { "Agent_UserId" });
            DropColumn("dbo.Schedules", "Weight");
            DropTable("dbo.Bookings");
        }
    }
}
