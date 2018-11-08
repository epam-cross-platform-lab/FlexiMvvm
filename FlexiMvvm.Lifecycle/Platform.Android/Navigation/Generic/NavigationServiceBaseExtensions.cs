// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using Android.App;
using Android.Content;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation.Generic
{
    public static class NavigationServiceBaseExtensions
    {
        public static void Navigate(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IAndroidView fromView,
            [NotNull] Type toViewType,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));
            if (toViewType == null)
                throw new ArgumentNullException(nameof(toViewType));

            var activity = fromView.GetActivity();
            var intent = new Intent(activity, toViewType);
            (navigationStrategy ?? NavigationStrategy.Forward.Default()).Invoke(fromView, null, intent);
        }

        public static void Navigate<TActivity>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IAndroidView fromView,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Activity, IActivityView<IViewModelWithoutParameters>
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var activity = fromView.GetActivity();
            var targetActivityType = typeof(TActivity);
            var intent = new Intent(activity, targetActivityType);
            (navigationStrategy ?? NavigationStrategy.Forward.Default()).Invoke(fromView, null, intent);
        }

        public static void Navigate<TActivity, TParameters>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IAndroidView fromView,
            [CanBeNull] TParameters parameters,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Activity, IActivityView<IViewModelWithParameters<TParameters>>
            where TParameters : ViewModelParametersBase
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var activity = fromView.GetActivity();
            var targetActivityType = typeof(TActivity);
            var intent = new Intent(activity, targetActivityType);
            intent.PutViewModelParameters(parameters);
            (navigationStrategy ?? NavigationStrategy.Forward.Default()).Invoke(fromView, null, intent);
        }

        public static void NavigateForResult<TActivity, TResult>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IAndroidView<IViewModelWithResultHandler> fromView,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Activity, IActivityView<IViewModelWithoutParameters>, IActivityView<IViewModelWithResult<TResult>>
            where TResult : ViewModelResultBase
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var activity = fromView.GetActivity();
            var targetActivityType = typeof(TActivity);
            var intent = new Intent(activity, targetActivityType);
            var requestCode = RequestCode.Get<TResult>(activity, targetActivityType);
            (navigationStrategy ?? NavigationStrategy.Forward.Default()).Invoke(fromView, requestCode, intent);
        }

        public static void NavigateForResult<TActivity, TParameters, TResult>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IAndroidView<IViewModelWithResultHandler> fromView,
            [CanBeNull] TParameters parameters,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Activity, IActivityView<IViewModelWithParameters<TParameters>>, IActivityView<IViewModelWithResult<TResult>>
            where TParameters : ViewModelParametersBase
            where TResult : ViewModelResultBase
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var activity = fromView.GetActivity();
            var targetActivityType = typeof(TActivity);
            var intent = new Intent(activity, targetActivityType);
            intent.PutViewModelParameters(parameters);
            var requestCode = RequestCode.Get<TResult>(activity, targetActivityType);
            (navigationStrategy ?? NavigationStrategy.Forward.Default()).Invoke(fromView, requestCode, intent);
        }

        public static void NavigateBack(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IActivityView fromView,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            (navigationStrategy ?? NavigationStrategy.Backward.Default()).Invoke(fromView);
        }

        public static void NavigateBack<TResult>(
            [NotNull] this NavigationServiceBase navigationService,
            [NotNull] IActivityView<IViewModelWithResult<TResult>> fromView,
            ViewModelResultCode resultCode,
            [CanBeNull] TResult result,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
            where TResult : ViewModelResultBase
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var intent = new Intent();
            intent.PutViewModelResult(result);
            fromView.SetResult(resultCode.ToResult(), intent);
            (navigationStrategy ?? NavigationStrategy.Backward.Default()).Invoke(fromView);
        }
    }
}
