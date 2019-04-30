using System.Windows.Input;
using FlexiMvvm.ViewModels;
using NavigationFlow.Core.Navigation;

namespace NavigationFlow.Core.ViewModels.CustomFlow
{
    public sealed class ThirdViewModel : LifecycleViewModel, ILifecycleViewModelWithResult<FlowResult>
    {
        private readonly INavigationService _navigationService;

        public ThirdViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand AcceptCommand => CommandProvider.Get(Accept);

        public ICommand DeclineCommand => CommandProvider.Get(Decline);

        public string Result
        {
            get => State.GetString();
            set => State.SetString(value);
        }

        private void Accept()
        {
            SetResult(ResultCode.Ok, new FlowResult(Result));
        }

        private void Decline()
        {
            SetResult(ResultCode.Canceled, new FlowResult(string.Empty));
        }

        public void SetResult(ResultCode resultCode, FlowResult result)
        {
            _navigationService.NavigateBack(this, resultCode, result);
        }
    }
}
