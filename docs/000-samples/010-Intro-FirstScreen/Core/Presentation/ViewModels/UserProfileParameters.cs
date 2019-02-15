namespace FirstScreen.Core.Presentation.ViewModels
{
    public class UserProfileParameters : FlexiMvvm.ViewModels.Parameters
    {
        public UserProfileParameters(string email)
        {
            Email = email;
        }

        public string Email
        {
            get => Bundle.GetString();
            set => Bundle.SetString(value);
        }
    }
}
