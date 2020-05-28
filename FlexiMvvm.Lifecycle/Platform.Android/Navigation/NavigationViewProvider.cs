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
using System.Diagnostics.CodeAnalysis;
#if __ANDROID_29__
using AndroidX.Fragment.App;
#else
using Android.Support.V4.App;
#endif
using FlexiMvvm.Formatters;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace FlexiMvvm.Navigation
{
    public static partial class NavigationViewProvider
    {
        /// <summary>
        /// Returns an existing navigation <typeparamref name="TView"/> derived from the <see cref="FragmentActivity"/> by <paramref name="viewModel"/>.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <returns>The navigation view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        [Obsolete("GetActivity<TView, TViewModel>(TViewModel viewModel) will be removed soon. Use TryGetActivity<TViewModel, TView>(TViewModel viewModel, out TView view) method instead.")]
        public static TView GetActivity<TView, TViewModel>(TViewModel viewModel)
            where TView : FragmentActivity, INavigationView<TViewModel>
            where TViewModel : class, ILifecycleViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (!ViewRegistry.TryGetView<TViewModel, TView>(viewModel, out var view))
            {
                throw new InvalidOperationException(
                    $"The view instance is missing for the provided '{TypeFormatter.FormatName(viewModel.GetType())}' view model.");
            }

            return view;
        }

        /// <summary>
        /// Gets an existing navigation <typeparamref name="TView"/> derived from the <see cref="FragmentActivity"/> by <paramref name="viewModel"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <param name="view">The navigation view corresponding to the provided model.</param>
        /// <returns><see langword="true"/> if the view still exists and has not yet been garbage collected or disposed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        public static bool TryGetActivity<TViewModel, TView>(TViewModel viewModel, [MaybeNullWhen(returnValue: false)] out TView view)
            where TViewModel : class, ILifecycleViewModel
            where TView : FragmentActivity, INavigationView<TViewModel>
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewRegistry.TryGetView(viewModel, out view);
        }

        /// <summary>
        /// Returns an existing navigation <typeparamref name="TView"/> derived from the <see cref="Fragment"/> by <paramref name="viewModel"/>.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <returns>The navigation view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        [Obsolete("GetFragment<TView, TViewModel>(TViewModel viewModel) will be removed soon. Use TryGetFragment<TViewModel, TView>(TViewModel viewModel, out TView view) method instead.")]
        public static TView GetFragment<TView, TViewModel>(TViewModel viewModel)
            where TView : Fragment, INavigationView<TViewModel>
            where TViewModel : class, ILifecycleViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (!ViewRegistry.TryGetView<TViewModel, TView>(viewModel, out var view))
            {
                throw new InvalidOperationException(
                    $"The view instance is missing for the provided '{TypeFormatter.FormatName(viewModel.GetType())}' view model.");
            }

            return view;
        }

        /// <summary>
        /// Gets an existing navigation <typeparamref name="TView"/> derived from the <see cref="Fragment"/> by <paramref name="viewModel"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <param name="view">The navigation view corresponding to the provided model.</param>
        /// <returns><see langword="true"/> if the view still exists and has not yet been garbage collected or disposed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        public static bool TryGetFragment<TViewModel, TView>(TViewModel viewModel, [MaybeNullWhen(returnValue: false)] out TView view)
            where TViewModel : class, ILifecycleViewModel
            where TView : Fragment, INavigationView<TViewModel>
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewRegistry.TryGetView(viewModel, out view);
        }

        /// <summary>
        /// Gets an existing navigation <typeparamref name="TView"/> derived from the <see cref="DialogFragment"/> by <paramref name="viewModel"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <param name="view">The navigation view corresponding to the provided model.</param>
        /// <returns><see langword="true"/> if the view still exists and has not yet been garbage collected or disposed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        public static bool TryGetDialogFragment<TViewModel, TView>(TViewModel viewModel, [MaybeNullWhen(returnValue: false)] out TView view)
            where TViewModel : class, ILifecycleViewModel
            where TView : DialogFragment, INavigationView<TViewModel>
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewRegistry.TryGetView(viewModel, out view);
        }
    }
}
