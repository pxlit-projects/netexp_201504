namespace StarwarsUniverse.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingContext2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWMovieRefResourceUri", newName: "SWMovies_ResourceUri");
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWPlanetRefResourceUri", newName: "SWPlanets_ResourceUri");
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWMovieRefResourceUri", newName: "IX_SWMovies_ResourceUri");
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWPlanetRefResourceUri", newName: "IX_SWPlanets_ResourceUri");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWPlanets_ResourceUri", newName: "IX_SWPlanetRefResourceUri");
            RenameIndex(table: "dbo.SWPlanetsSWMovies", name: "IX_SWMovies_ResourceUri", newName: "IX_SWMovieRefResourceUri");
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWPlanets_ResourceUri", newName: "SWPlanetRefResourceUri");
            RenameColumn(table: "dbo.SWPlanetsSWMovies", name: "SWMovies_ResourceUri", newName: "SWMovieRefResourceUri");
        }
    }
}
