using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;
using NavigationFlow.Core.Navigation;
using NavigationFlow.Core.ViewModels;
using NavigationFlow.Core.ViewModels.CustomFlow;
using NavigationFlow.Droid.Views;
using NavigationFlow.Droid.Views.CustomFlow;

namespace NavigationFlow.Droid.Navigation
{
    internal sealed class AppNavigationService : NavigationService, INavigationService
    {
        public void NavigateToHome(EntryViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetActivity<SplashScreenActivity, EntryViewModel>(fromViewModel);

            Navigate<HomeActivity>(fromView);
        }

        public void NavigateToFirstPage(HomeViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetActivity<HomeActivity, HomeViewModel>(fromViewModel);

            NavigateForResult<FirstActivity, FlowResult>(fromView);
        }

        public void NavigateToSecondPage(FirstViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetActivity<FirstActivity, FirstViewModel>(fromViewModel);

            NavigateForResult<SecondActivity, FlowResult>(fromView);
        }

        public void NavigateToThirdPage(SecondViewModel fromViewModel)
        {
            var fromView = NavigationViewProvider.GetActivity<SecondActivity, SecondViewModel>(fromViewModel);

            NavigateForResult<ThirdActivity, FlowResult>(fromView);
        }

        public void NavigateBack<TResult>(ILifecycleViewModelWithResult<TResult> fromViewModel, ResultCode resultCode, TResult result)
            where TResult : Result
        {
            var fromView = NavigationViewProvider.Get(fromViewModel);

            NavigateBack(fromView, resultCode, result);
        }

        public void NavigateBack(ThirdViewModel fromViewModel, ResultCode resultCode, FlowResult result)
        {
            NavigateBack<FlowResult>(fromViewModel, resultCode, result);
        }

        public void NavigateBack(FirstViewModel fromViewModel, ResultCode resultCode, FlowResult result)
        {
            NavigateBack<FlowResult>(fromViewModel, resultCode, result);
        }
    }
}