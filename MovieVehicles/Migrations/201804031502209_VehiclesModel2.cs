namespace MovieVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehiclesModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "VehiclePhoto", c => c.String(nullable: false));
            DropColumn("dbo.Vehicles", "MoviePoster");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "MoviePoster", c => c.String(nullable: false));
            DropColumn("dbo.Vehicles", "VehiclePhoto");
        }
    }
}
