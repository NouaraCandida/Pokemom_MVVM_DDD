using PokemonDomain;
using PokemonMVVM.Core.Model;
using PokemonServiceContext.Rest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonServiceContext.Services
{
    public interface IPokemonService
    {
        Task<PagedResult<Pokemon>> GetPokemonAsync(IRestClient restClient, string url = null);
    }
}
