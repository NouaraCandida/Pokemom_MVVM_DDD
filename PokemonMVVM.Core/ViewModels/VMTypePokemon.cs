using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PokemonDomain;
using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;
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
            var result =  _pokemonService.GetPokemonAsync(_restClient);
        }

        private async Task LoadPokemon()
        {
            var result = await _pokemonService.GetPokemonAsync(_restClient, _nextPage);

            if (string.IsNullOrEmpty(_nextPage))
            {
                Pokemon.Clear();
                //Pokemon.AddRange(result.Results.Where(p => !p.Name.Contains("Vader") && !p.Name.Contains("Anakin")));
            }
            else
            {
               // Pokemon.AddRange(result.Results.Where(p => !p.Name.Contains("Vader") && !p.Name.Contains("Anakin")));
            }

            _nextPage = result.Next;
        }


        private MvxObservableCollection<Pokemon> _pokemon;
        public MvxObservableCollection<Pokemon> Pokemon
        {
            get
            {
                return _pokemon;
            }
            set
            {
                _pokemon = value;
                RaisePropertyChanged(() => Pokemon);
            }
        }

        public override void Prepare()
        {
            
        }
    }

}
