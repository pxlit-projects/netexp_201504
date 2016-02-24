namespace StarwarsUniverse.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingContext : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWMovie_ResourceUri", newName: "SWMovieRefResourceUri");
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWPlanet_ResourceUri", newName: "SWPlanetRefResourceUri");
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWMovie_ResourceUri", newName: "IX_SWMovieRefResourceUri");
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWPlanet_ResourceUri", newName: "IX_SWPlanetRefResourceUri");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWPlanetRefResourceUri", newName: "IX_SWPlanet_ResourceUri");
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWMovieRefResourceUri", newName: "IX_SWMovie_ResourceUri");
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWPlanetRefResourceUri", newName: "SWPlanet_ResourceUri");
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWMovieRefResourceUri", newName: "SWMovie_ResourceUri");
        }
    }
}
