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

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Allows to get existing navigation view by a view model.
    /// </summary>
    public static partial class NavigationViewProvider
    {
        /// <summary>
        /// Gets the navigation view.
        /// </summary>
        /// <param name="viewModel">The view model used for getting a bound view.</param>
        /// <returns>The navigation view.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        public static INavigationView<IViewModel> Get(IViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModel>, IViewModel>(viewModel);
        }

        /// <summary>
        /// Gets the navigation view which can handle passed result.
        /// </summary>
        /// <param name="viewModel">The view model used for getting a bound view.</param>
        /// <returns>The navigation view.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        public static INavigationView<IViewModelWithResultHandler> Get(IViewModelWithResultHandler viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModelWithResultHandler>, IViewModelWithResultHandler>(viewModel);
        }

        /// <summary>
        /// Gets the navigation view which can return a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the view model result.</typeparam>
        /// <param name="viewModel">The view model used for getting a bound view.</param>
        /// <returns>The navigation view.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        public static INavigationView<IViewModelWithResult<TResult>> Get<TResult>(IViewModelWithResult<TResult> viewModel)
            where TResult : Result
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModelWithResult<TResult>>, IViewModelWithResult<TResult>>(viewModel);
        }
    }
}
