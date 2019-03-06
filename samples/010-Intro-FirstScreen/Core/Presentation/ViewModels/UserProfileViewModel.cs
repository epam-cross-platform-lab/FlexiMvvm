using System.Threading.Tasks;
using FirstScreen.Core.Infrastructure.Data;
using FirstScreen.Core.Presentation.Navigation;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : ViewModel<UserProfileParameters>, IViewModelWithResultHandler
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private INavigationService _navigationService;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _language;

        public UserProfileViewModel(
            IUserProfileRepository userProfileRepository,
            INavigationService navigationService)
        {
            _userProfileRepository = userProfileRepository;
            _navigationService = navigationService;
        }

        ////

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

        ////

        public Command SaveCommand => CommandProvider.Get(Save);

        ////

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (!string.IsNullOrEmpty(Parameters.Email))
            {
                var profile = await _userProfileRepository.Get(Parameters.Email);

                Email = profile.Email;
                FirstName = profile.FirstName;
                LastName = profile.LastName;
                Language = profile.Language;
            }
        }

        ////

        public async void HandleResult(ResultCode resultCode, Result result)
        {
            if (result is SelectedLanguageResult selectedLanguageResult)
            {
                if (resultCode == ResultCode.Ok && selectedLanguageResult.IsSelected)
                {
                    Language = selectedLanguageResult.SelectedLanguage;

                    await _userProfileRepository.Update(new UserProfile
                    {
                        Email = Email,
                        FirstName = FirstName,
                        LastName = LastName,
                        Language = Language
                    });
                }
            }
        }

        private async void Save()
        {
            //// TODO: Validate the input

            await _userProfileRepository.Update(new UserProfile
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Language = Language
            });

            _navigationService.NavigateToLanguages(this);
        }
    }
}
