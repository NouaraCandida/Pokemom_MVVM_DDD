using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PokemonDomain.Model;
using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.Core.ViewModels
{
    public class VMFilterTypePokemon: BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IPokemonService _pokemonService;
        private readonly IRestClient _restClient;
        private string _nextPage;
        public VMFilterTypePokemon(IMvxNavigationService navigationService, IPokemonService pokemonService, IRestClient restClient)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _restClient = restClient;
            ClosePageCommand = new MvxAsyncCommand(ClosePage);
            PokemonsTypes = new MvxObservableCollection<PokemonType>();
            PokemonTypeSelectedCommand = new MvxAsyncCommand<PokemonType>(PokemonTypeSelected);

        }

        private Task PokemonTypeSelected(PokemonType arg)
        {
            throw new NotImplementedException();
        }

        private async Task ClosePage()
        {
            await _navigationService.Close(this);
        }
        private async Task LoadPokemon()
        {
            var result = await _pokemonService.GetPokemonTypeAsync(_restClient, _nextPage);

            if (string.IsNullOrEmpty(_nextPage))
            {
                PokemonsTypes.Clear();
                PokemonsTypes.AddRange(result.Results);
            }
            else
            {
                PokemonsTypes.AddRange(result.Results);
            }

            _nextPage = result.Next;
        }

        public MvxNotifyTask LoadPokemonTypeTask { get; private set; }
        private MvxObservableCollection<PokemonType> _pokemonsTypes;
        public MvxObservableCollection<PokemonType> PokemonsTypes
        {
            get
            {
                return _pokemonsTypes;
            }
            set
            {
                _pokemonsTypes = value;
                RaisePropertyChanged(() => PokemonsTypes);
            }
        }

        public IMvxCommand ClosePageCommand { get; private set; }
        public IMvxCommand<PokemonType> PokemonTypeSelectedCommand { get; private set; }

        public override Task Initialize()
        {
            LoadPokemonTypeTask = MvxNotifyTask.Create(LoadPokemon);

            return Task.FromResult(0);
        }
    }
}
