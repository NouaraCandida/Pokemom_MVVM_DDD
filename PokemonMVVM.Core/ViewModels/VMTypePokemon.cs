using MvvmCross.Navigation;
using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;

namespace PokemonMVVM.Core.ViewModels
{

    public class VMTypePokemon : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IPokemonService _pokemonService;

        public VMTypePokemon(IMvxNavigationService navigationService, IPokemonService pokemonService, IRestClient restClient)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _pokemonService.GetPokemonAsync(restClient);
        }

        public override void Prepare()
        {
            
        }
    }

}
