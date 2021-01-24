using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain.Model
{
    public partial class PokemonDetail
    {
        
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }


        [JsonProperty("species")]
        public PokemonSpecies Species { get; set; }


        [JsonProperty("weight")]
        public long Weight { get; set; }
    }
}
