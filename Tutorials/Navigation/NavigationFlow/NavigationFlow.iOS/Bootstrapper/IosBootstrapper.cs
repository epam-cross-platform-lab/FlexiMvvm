using FlexiMvvm.Bootstrappers;
using NavigationFlow.Core.Bootstrapper;
using NavigationFlow.Core.Navigation;
using NavigationFlow.iOS.Navigation;

namespace NavigationFlow.iOS.Bootstrapper
{
    internal sealed class IosBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();
            simpleIoc.Register<INavigationService>(() => new AppNavigationService());
        }
    }
}