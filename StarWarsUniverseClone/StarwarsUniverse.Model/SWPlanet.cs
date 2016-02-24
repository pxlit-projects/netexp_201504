using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace StarWarsUniverse.Model
{
    public class SWPlanet : SWResource
    {

        public SWPlanet()
        {
            this.Films = new HashSet<SWMovie>();
        }
        public string Name { get; set; }
        [JsonProperty("rotation_period")]
        public string RotationPeriod { get; set; }
        [JsonProperty("orbital_period")]
        public string OrbitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        [JsonIgnore]
        public virtual ICollection<SWMovie> Films { get; set; }
        [JsonProperty(PropertyName = "films")]
        public List<string> FilmUris { get; set; }
    }
}