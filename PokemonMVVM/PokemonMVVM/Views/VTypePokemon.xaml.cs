using MvvmCross.Forms.Views;
using PokemonMVVM.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace PokemonMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VTypePokemon : MvxContentPage<VMTypePokemon>
    {
        public VTypePokemon()
        {
            InitializeComponent();
        }
    }
}