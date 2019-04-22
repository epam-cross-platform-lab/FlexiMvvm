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

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Provides a set of methods for performing navigation.
    /// </summary>
    public abstract partial class NavigationService
    {
        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="viewModel">The model used for getting a bound view.</param>
        /// <returns>The view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">View instance is missing for provided <paramref name="viewModel"/>.</exception>
        [NotNull]
        public INavigationView<IViewModel> GetView([NotNull] IViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModel>, IViewModel>(viewModel);
        }

        /// <summary>
        /// Gets the view which can handle passed result.
        /// </summary>
        /// <param name="viewModel">The model used for getting a bound view.</param>
        /// <returns>The view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">View instance is missing for provided <paramref name="viewModel"/>.</exception>
        [NotNull]
        public INavigationView<IViewModelWithResultHandler> GetView([NotNull] IViewModelWithResultHandler viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModelWithResultHandler>, IViewModelWithResultHandler>(viewModel);
        }

        /// <summary>
        /// Gets the view which can return a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="viewModel">The model used for getting a bound view.</param>
        /// <returns>The view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">View instance is missing for provided <paramref name="viewModel"/>.</exception>
        [NotNull]
        public INavigationView<IViewModelWithResult<TResult>> GetView<TResult>([NotNull] IViewModelWithResult<TResult> viewModel)
            where TResult : Result
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModelWithResult<TResult>>, IViewModelWithResult<TResult>>(viewModel);
        }

        /// <summary>
        /// Gets the last navigated view.
        /// </summary>
        /// <returns>The view instance.</returns>
        [CanBeNull]
        public INavigationView<IViewModel> GetLastNavigatedView()
        {
            return ViewCache.GetLastOrDefault<INavigationView<IViewModel>>();
        }
    }
}
