using FlexiMvvm.ViewModels;

namespace Sample.Core.Presentation.ViewModels
{
    public class UserProfileParameters : Parameters
    {
        public UserProfileParameters(string email)
        {
            Email = email;
        }

        public string? Email
        {
            get => Bundle.GetString();
            set => Bundle.SetString(value);
        }
    }
}
