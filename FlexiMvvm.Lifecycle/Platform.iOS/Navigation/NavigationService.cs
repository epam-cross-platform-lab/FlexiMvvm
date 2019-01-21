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

using System;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Navigation
{
    public abstract partial class NavigationService
    {
        [NotNull]
        public TViewController GetViewController<TViewController, TViewModel>([NotNull] TViewModel viewModel)
            where TViewController : UIViewController, IViewController<TViewModel>
            where TViewModel : class, IViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<TViewController, TViewModel>(viewModel);
        }

        public void Navigate<TViewController>(
            [NotNull] IForwardNavigationView<IViewModel> fromView,
            [NotNull] TViewController toView,
            bool animated,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TViewController : UIViewController
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));
            if (toView == null)
                throw new ArgumentNullException(nameof(toView));

            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? GetForwardNavigationStrategy(toView)).Invoke(navigationController, toView, animated);
        }

        public void NavigateForResult<TViewController, TResult>(
            [NotNull] IForwardNavigationView<IViewModelWithResultHandler> fromView,
            [NotNull] TViewController toView,
            bool animated,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TViewController : UIViewController, IBackwardNavigationView<IViewModelWithResult<TResult>>
            where TResult : Result
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));
            if (toView == null)
                throw new ArgumentNullException(nameof(toView));

            toView.ResultSetWeakSubscribe(fromView.HandleResult);
            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? GetForwardNavigationStrategy(toView)).Invoke(navigationController, toView, animated);
        }

        public void NavigateBack(
            [NotNull] IBackwardNavigationView<IViewModel> fromView,
            bool animated,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? GetBackwardNavigationStrategy(fromView)).Invoke(navigationController, fromView, animated);
        }

        public void NavigateBack<TResult>(
            [NotNull] IBackwardNavigationView<IViewModelWithResult<TResult>> fromView,
            ResultCode resultCode,
            [CanBeNull] TResult result,
            bool animated,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
            where TResult : Result
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            fromView.SetResult(resultCode, result);
            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? GetBackwardNavigationStrategy(fromView)).Invoke(navigationController, fromView, animated);
        }

        [NotNull]
        private ForwardNavigationDelegate GetForwardNavigationStrategy([NotNull] UIViewController toView)
        {
            return toView is UINavigationController ? NavigationStrategy.Forward.PresentViewController() : NavigationStrategy.Forward.PushViewController();
        }

        [NotNull]
        private BackwardNavigationDelegate GetBackwardNavigationStrategy([NotNull] IBackwardNavigationView<IViewModel> fromView)
        {
            return fromView.IsBeingPresented ? NavigationStrategy.Backward.DismissViewController() : NavigationStrategy.Backward.PopViewController();
        }
    }
}
