namespace StarwarsUniverse.Console.Migrations
{
    using StarWarsUniverse.Model;
    using StarWarsUniverse.Services;
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StarWarsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StarWarsContext context)
        {
            SWDataService dataService = new SWDataService();

            IList movies = dataService.GetAllSWMovies();
            foreach (SWMovie movie in movies)
            {
                context.SWMovies.AddOrUpdate(
                 m => m.ResourceUri, movie);
            }

            IList planets = dataService.GetAllSWPlanets();
            foreach (SWPlanet planet in planets)
            {
                context.SWPlanets.AddOrUpdate(
                 p => p.ResourceUri, planet);
            }
        }
    }
}
