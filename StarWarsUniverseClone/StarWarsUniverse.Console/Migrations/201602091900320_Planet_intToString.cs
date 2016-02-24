namespace StarwarsUniverse.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Planet_intToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SWPlanets", "RotationPeriod", c => c.String());
            AlterColumn("dbo.SWPlanets", "OrbitalPeriod", c => c.String());
            AlterColumn("dbo.SWPlanets", "Diameter", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SWPlanets", "Diameter", c => c.Int(nullable: false));
            AlterColumn("dbo.SWPlanets", "OrbitalPeriod", c => c.Int(nullable: false));
            AlterColumn("dbo.SWPlanets", "RotationPeriod", c => c.Int(nullable: false));
        }
    }
}
