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
using FlexiMvvm.Formatters;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Allows to get an existing navigation view by a lifecycle-aware view model.
    /// </summary>
    public static partial class NavigationViewProvider
    {
        /// <summary>
        /// Returns an existing <see cref="INavigationView{TViewModel}"/> instance by <paramref name="viewModel"/>.
        /// </summary>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <returns>The navigation view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        [Obsolete("Get(ILifecycleViewModel viewModel) will be removed soon. Use TryGetView(ILifecycleViewModel viewModel, out INavigationView<ILifecycleViewModel> view) method instead.")]
        public static INavigationView<ILifecycleViewModel> Get(ILifecycleViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (!ViewRegistry.TryGetView<ILifecycleViewModel, INavigationView<ILifecycleViewModel>>(viewModel, out var view))
            {
                throw new InvalidOperationException(
                    $"The view instance is missing for the provided '{TypeFormatter.FormatName(viewModel.GetType())}' view model.");
            }

            return view;
        }

        /// <summary>
        /// Gets an existing <see cref="INavigationView{TViewModel}"/> instance by <paramref name="viewModel"/>.
        /// </summary>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <param name="view">The navigation view corresponding to the provided model.</param>
        /// <returns><see langword="true"/> if the view still exists and has not yet been garbage collected or disposed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        public static bool TryGetView(ILifecycleViewModel viewModel, [MaybeNullWhen(returnValue: false)] out INavigationView<ILifecycleViewModel> view)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewRegistry.TryGetView(viewModel, out view);
        }

        /// <summary>
        /// Returns an existing <see cref="INavigationView{TViewModel}"/> instance by <paramref name="viewModel"/> that can handle a lifecycle-aware view model result.
        /// </summary>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <returns>The navigation view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        [Obsolete("Get(ILifecycleViewModelWithResultHandler viewModel) will be removed soon. Use TryGetView(ILifecycleViewModelWithResultHandler viewModel, out INavigationView<ILifecycleViewModelWithResultHandler> view) method instead.")]
        public static INavigationView<ILifecycleViewModelWithResultHandler> Get(ILifecycleViewModelWithResultHandler viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (!ViewRegistry.TryGetView<ILifecycleViewModelWithResultHandler, INavigationView<ILifecycleViewModelWithResultHandler>>(viewModel, out var view))
            {
                throw new InvalidOperationException(
                    $"The view instance is missing for the provided '{TypeFormatter.FormatName(viewModel.GetType())}' view model.");
            }

            return view;
        }

        /// <summary>
        /// Gets an existing <see cref="INavigationView{TViewModel}"/> instance by <paramref name="viewModel"/> that can handle a lifecycle-aware view model result.
        /// </summary>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <param name="view">The navigation view corresponding to the provided model.</param>
        /// <returns><see langword="true"/> if the view still exists and has not yet been garbage collected or disposed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        public static bool TryGetView(ILifecycleViewModelWithResultHandler viewModel, [MaybeNullWhen(returnValue: false)] out INavigationView<ILifecycleViewModelWithResultHandler> view)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewRegistry.TryGetView(viewModel, out view);
        }

        /// <summary>
        /// Returns an existing <see cref="INavigationView{TViewModel}"/> instance by <paramref name="viewModel"/> that can return a lifecycle-aware view model result.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <returns>The navigation view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        public static INavigationView<ILifecycleViewModelWithResult<TResult>> Get<TResult>(ILifecycleViewModelWithResult<TResult> viewModel)
            where TResult : Result
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (!ViewRegistry.TryGetView<ILifecycleViewModelWithResult<TResult>, INavigationView<ILifecycleViewModelWithResult<TResult>>>(viewModel, out var view))
            {
                throw new InvalidOperationException(
                    $"The view instance is missing for the provided '{TypeFormatter.FormatName(viewModel.GetType())}' view model.");
            }

            return view;
        }

        /// <summary>
        /// Gets an existing <see cref="INavigationView{TViewModel}"/> instance by <paramref name="viewModel"/> that can return a lifecycle-aware view model result.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <param name="view">The navigation view corresponding to the provided model.</param>
        /// <returns><see langword="true"/> if the view still exists and has not yet been garbage collected or disposed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        public static bool TryGetView<TResult>(ILifecycleViewModelWithResult<TResult> viewModel, [MaybeNullWhen(returnValue: false)] out INavigationView<ILifecycleViewModelWithResult<TResult>> view)
            where TResult : Result
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewRegistry.TryGetView(viewModel, out view);
        }
    }
}
