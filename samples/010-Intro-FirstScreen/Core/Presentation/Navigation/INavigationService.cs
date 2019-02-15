using FirstScreen.Core.Presentation.ViewModels;

namespace FirstScreen.Core.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters);
    }
}
