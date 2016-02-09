using StarWarsUniverse.Model;
using System.Collections.Generic;

namespace StarWarsUniverse.Services
{
    interface ISWDataService
    {
        List<SWMovie> GetAllSWMovies();
        SWMovie GetSWMovieDetails(string uri);
        List<SWPlanet> GetAllSWPlanets();
        SWPlanet GetSWPlanetDetails(string uri);
    }
}