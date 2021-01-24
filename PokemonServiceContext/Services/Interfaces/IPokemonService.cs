using PokemonDomain;
using PokemonDomain.Model;
using PokemonMVVM.Core.Model;
using PokemonServiceContext.Rest;
using System.Threading.Tasks;

namespace PokemonServiceContext.Services
{
    public interface IPokemonService
    {
        Task<PagedResult<Pokemon>> GetPokemonAsync(IRestClient restClient, string url = null);
        Task<PagedResult<PokemonType>> GetPokemonTypeAsync(IRestClient restClient, string url = null);
    }
}
