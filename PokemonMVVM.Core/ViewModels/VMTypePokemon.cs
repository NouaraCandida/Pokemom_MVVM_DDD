using MvvmCross.Navigation;


namespace PokemonMVVM.Core.ViewModels
{

    public class VMTypePokemon : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public VMTypePokemon(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }

}
