using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : LifecycleViewModel<UserProfileParameters>, ILifecycleViewModelWithResultHandler
    {
        private readonly INavigationService _navigationService;

        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _language = string.Empty;

        public UserProfileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string FirstName
        {
            get => _firstName;
            set => SetValue(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetValue(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetValue(ref _email, value);
        }

        public string Language
        {
            get => _language;
            set => SetValue(ref _language, value);
        }

        public Command SaveCommand => new RelayCommand(SaveAction);

        public Command NavigateToLanguagesCommand => new RelayCommand(NavigateToLanguagesAction);

        public void HandleResult(ResultCode resultCode, Result? result)
        {
            if (result is SelectedLanguageResult selectedLanguageResult)
            {
                if (resultCode == ResultCode.Ok && selectedLanguageResult.IsSelected)
                {
                    Language = selectedLanguageResult.SelectedLanguage;

                    System.Diagnostics.Debug.WriteLine($"Result retrieved: {Language}...");
                }
            }
        }

        public override void Initialize(UserProfileParameters? parameters, bool recreated)
        {
            base.Initialize(parameters, recreated);

            Email = parameters?.Email ?? string.Empty;

            System.Diagnostics.Debug.WriteLine($"Initializing with Email parameter passed: {Email}...");

            FirstName = "Jeremy";
            LastName = "Simpson";
        }

        private void SaveAction()
        {
            System.Diagnostics.Debug.WriteLine($"Saving: {FirstName} {LastName}, {Email}, {Language}...");
        }

        private void NavigateToLanguagesAction()
        {
            _navigationService.NavigateToLanguages(this);
        }
    }
}
