using FlexiMvvm.ViewModels;
using NavigationFlow.Core.ViewModels;
using NavigationFlow.Core.ViewModels.CustomFlow;

namespace NavigationFlow.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToHome(EntryViewModel fromViewModel);

        void NavigateToFirstPage(HomeViewModel fromViewModel);

        void NavigateToSecondPage(FirstViewModel fromViewModel);

        void NavigateToThirdPage(SecondViewModel fromViewModel);

        void NavigateBack<TResult>(
            ILifecycleViewModelWithResult<TResult> fromViewModel,
            ResultCode resultCode,
            TResult result) where TResult : Result;

        void NavigateBack(FirstViewModel fromViewModel, ResultCode resultCode, FlowResult result);

        void NavigateBack(ThirdViewModel fromViewModel, ResultCode resultCode, FlowResult result);
    }
}
