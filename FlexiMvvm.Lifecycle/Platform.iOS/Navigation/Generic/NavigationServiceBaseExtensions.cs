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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Navigation.Generic
{
    public static class NavigationServiceBaseExtensions
    {
        public static void Navigate<TViewController>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IIosView fromView,
            [NotNull] TViewController toView,
            bool animated,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TViewController : UIViewController
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));
            if (toView == null)
                throw new ArgumentNullException(nameof(toView));

            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? NavigationStrategy.Forward.Default()).Invoke(navigationController, toView, animated);
        }

        public static void NavigateForResult<TViewController, TResult>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IIosView<IViewModelWithResultHandler> fromView,
            [NotNull] TViewController toView,
            bool animated,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TViewController : UIViewController, IIosView<IViewModelWithResult<TResult>>
            where TResult : ViewModelResultBase
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));
            if (toView == null)
                throw new ArgumentNullException(nameof(toView));

            toView.ResultSetWeakSubscribe(fromView.HandleResult);
            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? NavigationStrategy.Forward.Default()).Invoke(navigationController, toView, animated);
        }

        public static void NavigateBack(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IIosView fromView,
            bool animated,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? NavigationStrategy.Backward.Default()).Invoke(navigationController, fromView, animated);
        }

        public static void NavigateBack<TResult>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IIosView<IViewModelWithResult<TResult>> fromView,
            ViewModelResultCode resultCode,
            [CanBeNull] TResult result,
            bool animated,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
            where TResult : ViewModelResultBase
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            fromView.SetResult(resultCode, result);
            var navigationController = fromView.GetNavigationController();
            (navigationStrategy ?? NavigationStrategy.Backward.Default()).Invoke(navigationController, fromView, animated);
        }
    }
}
