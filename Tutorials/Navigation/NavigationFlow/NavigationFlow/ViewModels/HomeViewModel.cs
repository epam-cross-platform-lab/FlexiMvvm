using System.Windows.Input;
using FlexiMvvm.ViewModels;
using NavigationFlow.Core.Navigation;
using NavigationFlow.Core.ViewModels.CustomFlow;

namespace NavigationFlow.Core.ViewModels
{
    public sealed class HomeViewModel : LifecycleViewModel, ILifecycleViewModelWithResultHandler
    {
        private readonly INavigationService _navigationService;
        private string _result;

        public string Result
        {
            get => _result;
            set => SetValue(ref _result, value);
        }

        public ICommand StartSeparateFlowCommand => CommandProvider.Get(StartFlow);

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void StartFlow()
        {
            _navigationService.NavigateToFirstPage(this);
        }

        public void HandleResult(ResultCode resultCode, Result result)
        {
            if (resultCode == ResultCode.Canceled)
            {
                Result = "Flow was closed without setting Result";
            }
            else if (result is FlowResult flowResult)
            {
                Result = flowResult.Value;
            }
        }
    }
}
