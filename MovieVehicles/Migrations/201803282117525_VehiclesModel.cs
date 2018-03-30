namespace MovieVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehiclesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Make", c => c.String());
            AddColumn("dbo.Vehicles", "Model", c => c.String());
            AddColumn("dbo.Vehicles", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Year");
            DropColumn("dbo.Vehicles", "Model");
            DropColumn("dbo.Vehicles", "Make");
        }
    }
}
