using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class LanguagesViewModel : LifecycleViewModel, ILifecycleViewModelWithResult<SelectedLanguageResult>
    {
        private INavigationService _navigationService;

        public LanguagesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Command<string> SelectLanguage => CommandProvider.Get<string>(OnSelectLanguage);

        public void SetResult(ResultCode resultCode, SelectedLanguageResult result)
        {
            _navigationService.NavigateBack(this, resultCode, result);
        }

        private void OnSelectLanguage(string @value)
        {
            SetResult(ResultCode.Ok, new SelectedLanguageResult(true, @value));
        }
    }
}
