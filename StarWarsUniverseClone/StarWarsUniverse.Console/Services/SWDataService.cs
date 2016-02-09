using System;
using System.Collections.Generic;
using StarWarsUniverse.Model;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace StarWarsUniverse.Services
{
    public class SWDataService : ISWDataService
    {
        public List<SWMovie> GetAllSWMovies()
        {
            string swapifilms = "http://swapi.co/api/films";
            var uri = new Uri(String.Format("{0}?format=json", swapifilms));
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
                response.EnsureSuccessStatusCode();
                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                    var root = JsonConvert.DeserializeObject<RootObject<SWMovie>>(result);

            var movies = root.results;
            //Add movies
            foreach (SWMovie movie in movies)
            {
                foreach (String s in movie.PlanetUris)
                {
                    movie.Planets = new List<SWPlanet>();
                    movie.Planets.Add(GetSWPlanetDetails(s));
                }
            }
            return movies;
        }
        public SWMovie GetSWMovieDetails(string uri)
        {
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var movie = JsonConvert.DeserializeObject<SWMovie>(result);
            return movie;
        }
        public List<SWPlanet> GetAllSWPlanets()
        {
            string swapiplanets = "http://swapi.co/api/planets";
            var uri = new Uri(String.Format("{0}?format=json", swapiplanets));
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var root = JsonConvert.DeserializeObject<RootObject<SWPlanet>>(result);

            var planets = root.results;

            //Add movies
            /*foreach(SWPlanet planet in planets)
            {
                planet.Films = new List<SWMovie>();
                foreach (String s in planet.FilmUris)
                {
                    Console.WriteLine("DATASERVICE: " + planet.Name + " - " + s);
                    
                    planet.Films.Add(GetSWMovieDetails(s));
                }
            }*/

            return planets;
        }

        public SWPlanet GetSWPlanetDetails(string uri)
        {
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var planet = JsonConvert.DeserializeObject<SWPlanet>(result);
            return planet;
        }
    }
    class RootObject<T>
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<T> results { get; set; }
    }
}