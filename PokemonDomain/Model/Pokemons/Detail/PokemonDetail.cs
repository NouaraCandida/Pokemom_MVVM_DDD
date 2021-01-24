using Newtonsoft.Json;
using PokemonDomain.Model.Pokemons.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain.Model.Detail
{
    public partial class PokemonDetail
    {
        
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("types")]
        public PokemonType[] Types { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }
}
