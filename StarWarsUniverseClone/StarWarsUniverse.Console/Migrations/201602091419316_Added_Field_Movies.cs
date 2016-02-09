namespace StarwarsUniverse.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Field_Movies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SWMovies", "SWPlanet_ResourceUri", "dbo.SWPlanets");
            DropIndex("dbo.SWMovies", new[] { "SWPlanet_ResourceUri" });
            CreateTable(
                "dbo.SWPlanetSWMovies",
                c => new
                    {
                        SWPlanet_ResourceUri = c.String(nullable: false, maxLength: 128),
                        SWMovie_ResourceUri = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SWPlanet_ResourceUri, t.SWMovie_ResourceUri })
                .ForeignKey("dbo.SWPlanets", t => t.SWPlanet_ResourceUri, cascadeDelete: true)
                .ForeignKey("dbo.SWMovies", t => t.SWMovie_ResourceUri, cascadeDelete: true)
                .Index(t => t.SWPlanet_ResourceUri)
                .Index(t => t.SWMovie_ResourceUri);
            
            DropColumn("dbo.SWMovies", "SWPlanet_ResourceUri");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SWMovies", "SWPlanet_ResourceUri", c => c.String(maxLength: 128));
            DropForeignKey("dbo.SWPlanetSWMovies", "SWMovie_ResourceUri", "dbo.SWMovies");
            DropForeignKey("dbo.SWPlanetSWMovies", "SWPlanet_ResourceUri", "dbo.SWPlanets");
            DropIndex("dbo.SWPlanetSWMovies", new[] { "SWMovie_ResourceUri" });
            DropIndex("dbo.SWPlanetSWMovies", new[] { "SWPlanet_ResourceUri" });
            DropTable("dbo.SWPlanetSWMovies");
            CreateIndex("dbo.SWMovies", "SWPlanet_ResourceUri");
            AddForeignKey("dbo.SWMovies", "SWPlanet_ResourceUri", "dbo.SWPlanets", "ResourceUri");
        }
    }
}
