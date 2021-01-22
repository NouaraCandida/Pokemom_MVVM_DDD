using MvvmCross.IoC;
using MvvmCross.ViewModels;
using PokemonInjection;

namespace PokemonMVVM.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            InjectionMobile.Start();


            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            RegisterCustomAppStart<AppStart>();
            base.Initialize();
        }
    }
}
