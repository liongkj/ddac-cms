namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Ship_ShipId", "dbo.Ships");
            DropIndex("dbo.Schedules", new[] { "Ship_ShipId" });
            AddColumn("dbo.Schedules", "ShipId", c => c.String(nullable: false));
            DropColumn("dbo.Schedules", "Ship_ShipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Ship_ShipId", c => c.Int(nullable: false));
            DropColumn("dbo.Schedules", "ShipId");
            CreateIndex("dbo.Schedules", "Ship_ShipId");
            AddForeignKey("dbo.Schedules", "Ship_ShipId", "dbo.Ships", "ShipId", cascadeDelete: true);
        }
    }
}
