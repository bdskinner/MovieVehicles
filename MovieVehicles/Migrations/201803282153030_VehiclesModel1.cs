namespace MovieVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehiclesModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
