using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class EntryViewModel : LifecycleViewModel
    {
        private readonly INavigationService _navigationService;

        public EntryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Initialize(bool recreated)
        {
            base.Initialize(recreated);

            _navigationService.NavigateToUserProfile(this, new UserProfileParameters("example@icloud.com"));
        }
    }
}
