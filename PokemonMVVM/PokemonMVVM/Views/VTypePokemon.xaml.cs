using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;
using PokemonMVVM.Core.ViewModels;
using Xamarin.Forms;

namespace PokemonMVVM.Views
{
    public partial class VTypePokemon : MvxContentPage<VMTypePokemon>
    {
        public VTypePokemon()
        {
            InitializeComponent();
        }
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            var set = this.CreateBindingSet<VTypePokemon, VMTypePokemon>();
            set.Apply();

        }
    }
}