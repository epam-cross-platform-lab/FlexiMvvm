using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace Sample.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : LifecycleViewModel
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;

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

        public Command SaveCommand => new RelayCommand(Save);

        private void Save()
        {
            System.Diagnostics.Debug.WriteLine($"Saving: {FirstName} {LastName}, {Email}...");
        }
    }
}
