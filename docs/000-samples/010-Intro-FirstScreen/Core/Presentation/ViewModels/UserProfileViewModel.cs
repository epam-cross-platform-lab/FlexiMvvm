using System.Threading.Tasks;
using System.Windows.Input;
using FirstScreen.Core.Infrastructure.Data;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : ViewModel<UserProfileParameters>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        private string _firstName;
        private string _lastName;
        private string _email;

        public UserProfileViewModel(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
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

        private async void Save()
        {
            //// TODO: Validate the input

            await _userProfileRepository.Update(new UserProfile
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            });
        }
    }
}
