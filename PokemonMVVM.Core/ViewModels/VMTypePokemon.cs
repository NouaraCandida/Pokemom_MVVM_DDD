using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PokemonDomain;
using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonMVVM.Core.ViewModels
{

    public class VMTypePokemon : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IPokemonService _pokemonService;
        private readonly IRestClient _restClient;
        private string _nextPage;
        public VMTypePokemon(IMvxNavigationService navigationService, IPokemonService pokemonService, IRestClient restClient)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _restClient = restClient;
            FilterTypeCommand = new MvxCommand(FilterPokemon);
            Pokemons =  new MvxObservableCollection<Pokemon>();
            PokemonSelectedCommand = new MvxAsyncCommand<Pokemon>(PokemonSelected);
            FetchPokemonCommand = new MvxCommand(
               () =>
               {
                   if (!string.IsNullOrEmpty(_nextPage))
                   {
                       FetchPokemonTask = MvxNotifyTask.Create(LoadPokemon);
                       RaisePropertyChanged(() => FetchPokemonTask);
                   }
               });
            RefreshPokemonCommand = new MvxCommand(RefreshPokemon);
        }

        private void FilterPokemon()
        {
             _navigationService.Navigate<VMFilterTypePokemon>();
            var result =  _pokemonService.GetPokemonTypeAsync(_restClient, "");
        }

        private async Task LoadPokemon()
        {
            var result = await _pokemonService.GetPokemonAsync(_restClient, _nextPage);

            if (string.IsNullOrEmpty(_nextPage))
            {
                Pokemons.Clear();
                Pokemons.AddRange(result.Results);
            }
            else
            {
                Pokemons.AddRange(result.Results);
            }

            _nextPage = result.Next;
        }

        private async Task PokemonSelected(Pokemon selectedPokemon)
        {
            /* var result = await _navigationService.Navigate<PersonViewModel, Person, DestructionResult<Person>>(selectedPerson);

             if (result != null && result.Destroyed)
             {
                 var person = People.FirstOrDefault(p => p.Name == result.Entity.Name);
                 if (person != null)
                     People.Remove(person);
             }*/
            
        }

        public MvxNotifyTask LoadPokemonTask { get; private set; }
        public MvxNotifyTask FetchPokemonTask { get; private set; }

        private MvxObservableCollection<Pokemon> _pokemons;
        public MvxObservableCollection<Pokemon> Pokemons
        {
            get
            {
                return _pokemons;
            }
            set
            {
                _pokemons = value;
                RaisePropertyChanged(() => Pokemons);
            }
        }

        public IMvxCommand FilterTypeCommand { get; private set; }
        public IMvxCommand<Pokemon> PokemonSelectedCommand { get; private set; }

        public IMvxCommand FetchPokemonCommand { get; private set; }

        public IMvxCommand RefreshPokemonCommand { get; private set; }

        private void RefreshPokemon()
        {
            _nextPage = null;

            LoadPokemonTask = MvxNotifyTask.Create(LoadPokemon);
            RaisePropertyChanged(() => LoadPokemonTask);
        }

        public override Task Initialize()
        {
            LoadPokemonTask = MvxNotifyTask.Create(LoadPokemon);

            return Task.FromResult(0);
        }
    }

}
