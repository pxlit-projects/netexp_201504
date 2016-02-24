using System;
using System.Collections.Generic;
using StarWarsUniverse.Model;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

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
            Debug.WriteLine("DEBUG ALLMOVIES: " + result);
            var root = JsonConvert.DeserializeObject<RootObject<SWMovie>>(result);

            var movies = root.results;
            //Add planets
            foreach (SWMovie movie in movies)
            {
                movie.Planets = new List<SWPlanet>();
                foreach (String s in movie.PlanetUris)
                {
                   // movie.Planets.Add(GetSWPlanetDetails(s));
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
            Debug.WriteLine("DEBUG ALLPLANETS: " + result);
            var root = JsonConvert.DeserializeObject<RootObject<SWPlanet>>(result);

            var planets = root.results;

            //Add movies
            foreach(SWPlanet planet in planets)
            {
                planet.Films = new List<SWMovie>();
                foreach (String s in planet.FilmUris)
                {
                    Console.WriteLine("DATASERVICE: " + planet.Name + " - " + s);
                    
                    planet.Films.Add(GetSWMovieDetails(s));
                }
            }

            return planets;
        }

        public SWPlanet GetSWPlanetDetails(string uri)
        {
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            Debug.WriteLine("DEBUG: " + result);
            var planet = JsonConvert.DeserializeObject<SWPlanet>(result);
            Debug.WriteLine("DEBUG: " + planet.Name + " - " + planet.ResourceUri);
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