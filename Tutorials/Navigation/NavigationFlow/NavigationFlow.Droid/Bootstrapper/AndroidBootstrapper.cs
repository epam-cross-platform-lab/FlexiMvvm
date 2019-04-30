using FlexiMvvm.Bootstrappers;
using NavigationFlow.Core.Bootstrapper;
using NavigationFlow.Core.Navigation;
using NavigationFlow.Droid.Navigation;

namespace NavigationFlow.Droid.Bootstrapper
{
    internal sealed class AndroidBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();
            simpleIoc.Register<INavigationService>(() => new AppNavigationService());
        }
    }
}