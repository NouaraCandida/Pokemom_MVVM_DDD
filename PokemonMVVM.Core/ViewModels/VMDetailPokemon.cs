using MvvmCross.Navigation;
using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonMVVM.Core.ViewModels
{
    public class VMDetailPokemon : BaseViewModel
    {

        private readonly IMvxNavigationService _navigationService;
        private readonly IPokemonService _pokemonService;
        private readonly IRestClient _restClient;

        public VMDetailPokemon(IMvxNavigationService navigationService, IPokemonService pokemonService, IRestClient restClient)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _restClient = restClient;
           
        }
    }
}
