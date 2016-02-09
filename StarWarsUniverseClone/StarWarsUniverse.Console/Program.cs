using StarWarsUniverse.Model;
using StarWarsUniverse.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsUniverse.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //TESTING
            StarWarsContext context = new StarWarsContext();
            SWDataService dataService = new SWDataService();
            IList moviestest = dataService.GetAllSWMovies();
            var counter = 1;
            foreach (SWMovie movie in moviestest)
            {
                foreach (String s in movie.PlanetUris)
                {
                    System.Console.WriteLine(movie.Title + " - " + s);
                    Debug.WriteLine(movie.Title + " - " + s);
                }
                
            }
            IList planets = dataService.GetAllSWPlanets();
            foreach (SWPlanet planet in planets)
            {
                foreach (String s in planet.FilmUris)
                {
                    SWMovie movie = dataService.GetSWMovieDetails(s);
                    System.Console.WriteLine(planet.Name + " - " + movie.Title + " - " + movie.ResourceUri);
                }
            }
            System.Console.WriteLine("+++++++++++++++++++++++++");
            System.Console.WriteLine("+++++++++++++++++++++++++");
            //END TESING

            System.Console.WriteLine("=== Star Wars Movies ===");
            StarWarsContext db = new StarWarsContext();
            IList movies = db.SWMovies.ToList().OrderBy(o => o.Episode_ID).ToList();
            foreach (SWMovie movie in movies)
            {
                System.Console.WriteLine("Episode " + movie.Episode_ID + " - " + movie.Title);
                System.Console.WriteLine("\tReleased: " + movie.ReleaseDate.ToShortDateString());
            }

            System.Console.WriteLine("========================");

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
