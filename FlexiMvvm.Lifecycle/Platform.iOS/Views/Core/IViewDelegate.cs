// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using FlexiMvvm.ViewModels;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views.Core
{
    public interface IViewDelegate<out TView>
        where TView : class, IIosView
    {
        [NotNull]
        TView View { get; }

        [CanBeNull]
        KeyboardHandler KeyboardHandler { get; }

        void ViewDidLoad();

        void ViewWillAppear();

        void ViewDidAppear();

        void ViewWillDisappear();

        void ViewDidDisappear();

        void WillMoveToParentViewController([CanBeNull] UIViewController parent);

        void DidMoveToParentViewController([CanBeNull] UIViewController parent);
    }

    public interface IViewDelegate<out TView, out TViewModel> : IViewDelegate<TView>
        where TView : class, IIosView<TViewModel>
        where TViewModel : class, IViewModel
    {
        [NotNull]
        TViewModel ViewModel { get; }

        void SetResult(ViewModelResultCode resultCode);

        void SetResult(ViewModelResultCode resultCode, [CanBeNull] ViewModelResultBase result);

        void HandleResult([NotNull] object sender, [NotNull] ViewModelResultSetEventArgs args);
    }
}
