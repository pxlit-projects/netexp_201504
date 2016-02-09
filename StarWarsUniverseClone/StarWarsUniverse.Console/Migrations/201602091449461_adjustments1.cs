namespace StarwarsUniverse.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustments1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SWPlanetSWMovies", newName: "SWPlanetsSWMovies");
            DropPrimaryKey("dbo.SWPlanetsSWMovies");
            AddPrimaryKey("dbo.SWPlanetsSWMovies", new[] { "SWMovie_ResourceUri", "SWPlanet_ResourceUri" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SWPlanetsSWMovies");
            AddPrimaryKey("dbo.SWPlanetsSWMovies", new[] { "SWPlanet_ResourceUri", "SWMovie_ResourceUri" });
            RenameTable(name: "dbo.SWPlanetsSWMovies", newName: "SWPlanetSWMovies");
        }
    }
}
