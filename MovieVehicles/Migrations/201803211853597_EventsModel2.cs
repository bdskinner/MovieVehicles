namespace MovieVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventsModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventCity", c => c.String(nullable: false));
            AddColumn("dbo.Events", "EventState", c => c.String(nullable: false));
            DropColumn("dbo.Events", "EventLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventLocation", c => c.String(nullable: false));
            DropColumn("dbo.Events", "EventState");
            DropColumn("dbo.Events", "EventCity");
        }
    }
}
