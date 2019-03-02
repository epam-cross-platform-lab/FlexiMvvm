using System.Threading.Tasks;
using System.Windows.Input;
using FirstScreen.Core.Infrastructure.Data;
using FirstScreen.Core.Presentation.Navigation;
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

        ////

        public ICommand SaveCommand => CommandProvider.Get(Save);

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
            }
        }

        ////

        public void HandleResult(ResultCode resultCode, Result result)
        {
            if (result is SelectedLanguageResult selectedLanguageResult)
            {
                if (resultCode == ResultCode.Ok)
                {
                    // TODO
                }
                else if (resultCode == ResultCode.Canceled)
                {
                    // TODO
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
                LastName = LastName
            });

            _navigationService.NavigateToLanguages(this);
        }
    }
}
