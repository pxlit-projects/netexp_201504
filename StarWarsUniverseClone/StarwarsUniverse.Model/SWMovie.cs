using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StarWarsUniverse.Model
{
    public class SWMovie : SWResource
    {

        public SWMovie()
        {
            Planets = new HashSet<SWPlanet>();
        }
        public string Title { get; set; }
        public int Episode_ID { get; set; }
        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<SWPlanet> Planets { get; set; }
        [JsonProperty(PropertyName = "planets")]
        public List<string> PlanetUris { get; set; }
    }
}