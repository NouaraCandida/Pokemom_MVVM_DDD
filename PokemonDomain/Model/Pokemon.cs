﻿using Newtonsoft.Json;
using PokemonDomain.Model;
using System;

namespace PokemonDomain
{
    public class Pokemon: PokemonImage
    {
        public string Name { get; set; }
        public string Url { get; set; }

        [JsonConstructor]
        public Pokemon(string name, string url)
        {
            Name = name;
            Url = url;
            UrlImage = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + Url?.Replace(Constants.BaseUrl, "").Replace("/","") + ".png";
        }
    }
}
