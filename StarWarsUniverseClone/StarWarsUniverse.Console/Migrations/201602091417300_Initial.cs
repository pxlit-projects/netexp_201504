namespace StarwarsUniverse.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SWMovies",
                c => new
                    {
                        ResourceUri = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Episode_ID = c.Int(nullable: false),
                        OpeningCrawl = c.String(),
                        Director = c.String(),
                        Producer = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Edited = c.DateTime(nullable: false),
                        SWPlanet_ResourceUri = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResourceUri)
                .ForeignKey("dbo.SWPlanets", t => t.SWPlanet_ResourceUri)
                .Index(t => t.SWPlanet_ResourceUri);
            
            CreateTable(
                "dbo.SWPlanets",
                c => new
                    {
                        ResourceUri = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        RotationPeriod = c.Int(nullable: false),
                        OrbitalPeriod = c.Int(nullable: false),
                        Diameter = c.Int(nullable: false),
                        Climate = c.String(),
                        Gravity = c.String(),
                        Terrain = c.String(),
                        SurfaceWater = c.String(),
                        Population = c.String(),
                        Created = c.DateTime(nullable: false),
                        Edited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceUri);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SWMovies", "SWPlanet_ResourceUri", "dbo.SWPlanets");
            DropIndex("dbo.SWMovies", new[] { "SWPlanet_ResourceUri" });
            DropTable("dbo.SWPlanets");
            DropTable("dbo.SWMovies");
        }
    }
}
