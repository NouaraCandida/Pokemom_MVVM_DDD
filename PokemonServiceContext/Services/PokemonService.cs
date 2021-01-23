using PokemonDomain;
using PokemonMVVM.Core.Model;
using PokemonServiceContext.Rest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonServiceContext.Services
{
    public class PokemonService : IPokemonService
    {
        public PokemonService()
        {
            
        }


        public Task<PagedResult<Pokemon>> GetPokemonAsync(IRestClient restClient, string url = null)
        {
            return string.IsNullOrEmpty(url)
                        ? restClient.MakeApiCall<PagedResult<Pokemon>>($"{Constants.BaseUrl}", HttpMethod.Get)
                        : restClient.MakeApiCall<PagedResult<Pokemon>>(url, HttpMethod.Get);
        }
    }
}
