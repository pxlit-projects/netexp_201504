using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace StarWarsUniverse.Model
{
    public abstract class SWResource
    {
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        [JsonProperty(PropertyName = "url")]
        [Key]
        public string ResourceUri { get; set; }
    }
}