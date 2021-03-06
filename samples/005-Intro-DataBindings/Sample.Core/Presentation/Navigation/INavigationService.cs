﻿using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.ViewModels;

namespace Sample.Core.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToUserProfile(EntryViewModel from);

        void NavigateToUserProfile(ILifecycleViewModel from, UserProfileParameters parameters);

        void NavigateToLanguages(ILifecycleViewModelWithResultHandler from);

        void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult? result);
    }
}
