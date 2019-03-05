using FirstScreen.Core.Presentation.Navigation;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class LanguagesViewModel : ViewModel, IViewModelWithResult<SelectedLanguageResult>
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
            System.Diagnostics.Debug.WriteLine(@value);

            SetResult(ResultCode.Ok, new SelectedLanguageResult(true, @value));
        }
    }

    public class Language
    {
        public string Title { get; set; }
    }
}
