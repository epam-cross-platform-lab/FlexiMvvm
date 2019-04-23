using FirstScreen.Core.Presentation.ViewModels;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters);

        void NavigateToLanguages(UserProfileViewModel from);

        void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult result);
    }
}
