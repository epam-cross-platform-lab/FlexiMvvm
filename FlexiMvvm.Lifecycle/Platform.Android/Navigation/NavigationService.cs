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
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Provides a set of methods for performing navigation.
    /// </summary>
    public abstract class NavigationService
    {
        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target one.
        /// </summary>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="targetViewIntent">The description of the target view.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="ForwardNavigationStrategy.StartActivity(Android.OS.Bundle)"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetViewIntent"/> is <c>null</c>.</exception>
        public void Navigate(
            [NotNull] INavigationView<IViewModel> sourceView,
            [NotNull] Intent targetViewIntent,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetViewIntent == null)
                throw new ArgumentNullException(nameof(targetViewIntent));

            (navigationStrategy ?? NavigationStrategy.Forward.StartActivity()).Invoke(sourceView, targetViewIntent);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target one.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="ForwardNavigationStrategy.StartActivity(Android.OS.Bundle)"/>.</param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="Android.Support.V4.App.FragmentActivity"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void Navigate<TTargetView>(
            [NotNull] INavigationView<IViewModel> sourceView,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TTargetView : Android.Support.V4.App.FragmentActivity, IView<IViewModel>
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var context = sourceView.GetActivity();

            if (context == null)
            {
                throw new ArgumentNullException("View's activity is 'null'.", nameof(sourceView));
            }

            var intent = new Intent(context, typeof(TTargetView));
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivity()).Invoke(sourceView, intent);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target one with provided <paramref name="parameters"/>.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TParameters">The type of the target view model parameters.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="parameters">The target view model parameters.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="ForwardNavigationStrategy.StartActivity(Android.OS.Bundle)"/>.</param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="Android.Support.V4.App.FragmentActivity"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void Navigate<TTargetView, TParameters>(
            [NotNull] INavigationView<IViewModel> sourceView,
            [CanBeNull] TParameters parameters,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TTargetView : Android.Support.V4.App.FragmentActivity, IView<IViewModelWithParameters<TParameters>>
            where TParameters : Parameters
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var context = sourceView.GetActivity();

            if (context == null)
            {
                throw new ArgumentNullException("View's activity is 'null'.", nameof(sourceView));
            }

            var intent = new Intent(context, typeof(TTargetView));
            intent.PutParameters(parameters);
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivity()).Invoke(sourceView, intent);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target one with receiving a result when it finished.
        /// </summary>
        /// <typeparam name="TResultMapper">The type of the target view model result mapper.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="targetViewIntent">The description of the target view.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="ForwardNavigationStrategy.StartActivityForResult(Android.OS.Bundle)"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetViewIntent"/> or <paramref name="resultMapper"/> is <c>null</c>.</exception>
        public void NavigateForResult<TResultMapper>(
            INavigationView<IViewModelWithResultHandler> sourceView,
            Intent targetViewIntent,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TResultMapper : IResultMapper<Result>, new()
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetViewIntent == null)
                throw new ArgumentNullException(nameof(targetViewIntent));

            var requestCode = sourceView.RequestCode.GetFor<TResultMapper>();
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivityForResult()).Invoke(sourceView, targetViewIntent, requestCode);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target one with receiving a result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="ForwardNavigationStrategy.StartActivityForResult(Android.OS.Bundle)"/>.</param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="Android.Support.V4.App.FragmentActivity"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void NavigateForResult<TTargetView, TResult>(
            INavigationView<IViewModelWithResultHandler> sourceView,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : Android.Support.V4.App.FragmentActivity, INavigationView<IViewModelWithResult<TResult>>
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var context = sourceView.GetActivity();

            if (context == null)
            {
                throw new ArgumentNullException("View's activity is 'null'.", nameof(sourceView));
            }

            var intent = new Intent(context, typeof(TTargetView));
            var requestCode = sourceView.RequestCode.GetFor<DefaultResultMapper<TResult>>();
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivityForResult()).Invoke(sourceView, intent, requestCode);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target one with provided <paramref name="parameters"/> and receiving a result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TParameters">The type of the target view model parameters.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="parameters">The target view model parameters.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="ForwardNavigationStrategy.StartActivityForResult(Android.OS.Bundle)"/>.</param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="Android.Support.V4.App.FragmentActivity"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void NavigateForResult<TTargetView, TParameters, TResult>(
            INavigationView<IViewModelWithResultHandler> sourceView,
            TParameters? parameters,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : Android.Support.V4.App.FragmentActivity, IView<IViewModelWithParameters<TParameters>>, INavigationView<IViewModelWithResult<TResult>>
            where TParameters : Parameters
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var context = sourceView.GetActivity();

            if (context == null)
            {
                throw new ArgumentNullException("View's activity is 'null'.", nameof(sourceView));
            }

            var intent = new Intent(context, typeof(TTargetView));
            intent.PutParameters(parameters);
            var requestCode = sourceView.RequestCode.GetFor<DefaultResultMapper<TResult>>();
            (navigationStrategy ?? NavigationStrategy.Forward.StartActivityForResult()).Invoke(sourceView, intent, requestCode);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/>.
        /// </summary>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="BackwardNavigationStrategy.Finish()"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <c>null</c>.</exception>
        public void NavigateBack(
            [NotNull] INavigationView<IViewModel> sourceView,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            (navigationStrategy ?? NavigationStrategy.Backward.Finish()).Invoke(sourceView);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/> with a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the source view model result.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="resultCode">Determines whether the result has been set successfully or canceled.</param>
        /// <param name="result">The source view model result.</param>
        /// <param name="navigationStrategy">The strategy used for performing navigation. Default is <see cref="BackwardNavigationStrategy.Finish()"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <c>null</c>.</exception>
        public void NavigateBack<TResult>(
            [NotNull] INavigationView<IViewModelWithResult<TResult>> sourceView,
            ResultCode resultCode,
            [CanBeNull] TResult result,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var intent = new Intent();
            intent.PutResult(result);
            sourceView.SetResult(resultCode, intent);
            (navigationStrategy ?? NavigationStrategy.Backward.Finish()).Invoke(sourceView);
        }
    }
}
