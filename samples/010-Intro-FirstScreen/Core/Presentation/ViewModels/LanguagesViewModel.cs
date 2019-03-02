using System.Threading.Tasks;
using FirstScreen.Core.Presentation.Navigation;
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

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            SetResult(ResultCode.Ok, new SelectedLanguageResult(true, "English"));
        }

        public void SetResult(ResultCode resultCode, SelectedLanguageResult result)
        {
            _navigationService.NavigateBack(this, resultCode, result);
        }
    }

    public class Language
    {
        public string Title { get; set; }
    }
}
