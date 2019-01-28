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
using Android.Content;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation
{
    public abstract partial class NavigationService
    {
        [NotNull]
        public TActivity GetActivity<TActivity, TViewModel>([NotNull] TViewModel viewModel)
            where TActivity : Android.Support.V4.App.FragmentActivity, INavigationView<TViewModel>
            where TViewModel : class, IViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<TActivity, TViewModel>(viewModel);
        }

        [NotNull]
        public TFragment GetFragment<TFragment, TViewModel>([NotNull] TViewModel viewModel)
            where TFragment : Android.Support.V4.App.Fragment, INavigationView<TViewModel>
            where TViewModel : class, IViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<TFragment, TViewModel>(viewModel);
        }

        public void Navigate(
            [NotNull] INavigationView<IViewModel> fromView,
            [NotNull] Intent intent,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));

            (navigationStrategy ?? NavigationStrategy.Forward.StartActivity()).Invoke(fromView, intent);
        }

        public void Navigate<TActivity>(
            [NotNull] INavigationView<IViewModel> fromView,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Android.Support.V4.App.FragmentActivity, IView<IViewModel>
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var context = fromView.GetActivity();
            var intent = new Intent(context, typeof(TActivity));
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivity()).Invoke(fromView, intent);
        }

        public void Navigate<TActivity, TParameters>(
            [NotNull] INavigationView<IViewModel> fromView,
            [CanBeNull] TParameters parameters,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Android.Support.V4.App.FragmentActivity, IView<IViewModelWithParameters<TParameters>>
            where TParameters : Parameters
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var context = fromView.GetActivity();
            var intent = new Intent(context, typeof(TActivity));
            intent.PutParameters(parameters);
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivity()).Invoke(fromView, intent);
        }

        public void NavigateForResult<TResult>(
            [NotNull] INavigationView<IViewModelWithResultHandler> fromView,
            [NotNull] Intent intent,
            [NotNull] IResultMapper resultMapper,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TResult : Result
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));
            if (resultMapper == null)
                throw new ArgumentNullException(nameof(resultMapper));

            var requestCode = fromView.RequestCode.GetFor<TResult>(resultMapper);
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivityForResult()).Invoke(fromView, intent, requestCode);
        }

        public void NavigateForResult<TActivity, TResult>(
            [NotNull] INavigationView<IViewModelWithResultHandler> fromView,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Android.Support.V4.App.FragmentActivity, INavigationView<IViewModelWithResult<TResult>>
            where TResult : Result
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var context = fromView.GetActivity();
            var intent = new Intent(context, typeof(TActivity));
            var requestCode = fromView.RequestCode.GetFor<TResult>();
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivityForResult()).Invoke(fromView, intent, requestCode);
        }

        public void NavigateForResult<TActivity, TParameters, TResult>(
            [NotNull] INavigationView<IViewModelWithResultHandler> fromView,
            [CanBeNull] TParameters parameters,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TActivity : Android.Support.V4.App.FragmentActivity, IView<IViewModelWithParameters<TParameters>>, INavigationView<IViewModelWithResult<TResult>>
            where TParameters : Parameters
            where TResult : Result
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var context = fromView.GetActivity();
            var intent = new Intent(context, typeof(TActivity));
            intent.PutParameters(parameters);
            var requestCode = fromView.RequestCode.GetFor<TResult>();
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivityForResult()).Invoke(fromView, intent, requestCode);
        }

        public void NavigateBack(
            [NotNull] INavigationView<IViewModel> fromView,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            (navigationStrategy ?? NavigationStrategy.Backward.Finish()).Invoke(fromView);
        }

        public void NavigateBack<TResult>(
            [NotNull] INavigationView<IViewModelWithResult<TResult>> fromView,
            ResultCode resultCode,
            [CanBeNull] TResult result,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
            where TResult : Result
        {
            if (fromView == null)
                throw new ArgumentNullException(nameof(fromView));

            var intent = new Intent();
            intent.PutResult(result);
            fromView.SetResult(resultCode, intent);
            (navigationStrategy ?? NavigationStrategy.Backward.Finish()).Invoke(fromView);
        }
    }
}
