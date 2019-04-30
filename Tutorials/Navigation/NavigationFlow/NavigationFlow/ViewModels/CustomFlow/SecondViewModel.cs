using System.Windows.Input;
using FlexiMvvm.ViewModels;
using NavigationFlow.Core.Navigation;

namespace NavigationFlow.Core.ViewModels.CustomFlow
{
    public sealed class SecondViewModel : LifecycleViewModel, ILifecycleViewModelWithResult<FlowResult>, ILifecycleViewModelWithResultHandler
    {
        private readonly INavigationService _navigationService;

        public SecondViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand GoToNextCommand => CommandProvider.Get(GoToNext);

        public void SetResult(ResultCode resultCode, FlowResult result)
        {
            _navigationService.NavigateBack(this, resultCode, result);
        }

        public void HandleResult(ResultCode resultCode, Result result)
        {
            if (result is FlowResult flowResult)
            {
                SetResult(resultCode, flowResult);
            }
        }

        private void GoToNext()
        {
            _navigationService.NavigateToThirdPage(this);
        }
    }
}
