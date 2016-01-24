using Newtonsoft.Json;
using System;
namespace StarWarsUniverse.Model
{     public class SWMovie : SWResource
{
    public string Title { get; set; }
    public int Episode_ID { get; set; }
    [JsonProperty(PropertyName = "opening_crawl")]
    public string OpeningCrawl { get; set; }
    public string Director { get; set; }
    public string Producer { get; set; }
    [JsonProperty(PropertyName = "release_date")]
    public DateTime ReleaseDate { get; set; }
}
}