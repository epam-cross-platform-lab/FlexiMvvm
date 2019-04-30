using System.Windows.Input;
using FlexiMvvm.ViewModels;
using NavigationFlow.Core.Navigation;

namespace NavigationFlow.Core.ViewModels.CustomFlow
{
    public sealed class FirstViewModel
        : LifecycleViewModel, ILifecycleViewModelWithResult<FlowResult>, ILifecycleViewModelWithResultHandler
    {
        private readonly INavigationService _navigationService;

        public FirstViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand GoToNextCommand => CommandProvider.Get(GoToNext);

        public ICommand CloseFlowCommand => CommandProvider.Get(CloseFlow);

        public void SetResult(ResultCode resultCode, FlowResult result)
        {
            HandleResult(resultCode, result);
        }

        public void HandleResult(ResultCode resultCode, Result result)
        {
            if (result is FlowResult flowResult)
            {
                _navigationService.NavigateBack(this, resultCode, flowResult);
            }
        }

        private void GoToNext()
        {
            _navigationService.NavigateToSecondPage(this);
        }

        private void CloseFlow()
        {
            _navigationService.NavigateBack(this, ResultCode.Canceled, null);
        }
    }
}
