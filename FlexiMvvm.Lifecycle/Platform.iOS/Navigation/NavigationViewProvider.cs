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
using UIKit;

namespace FlexiMvvm.Navigation
{
    public static partial class NavigationViewProvider
    {
        /// <summary>
        /// Returns an existing navigation <typeparamref name="TView"/> derived from the <see cref="UIViewController"/> by <paramref name="viewModel"/>.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="viewModel">The view model that is used to get its view.</param>
        /// <returns>The navigation view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for the provided <paramref name="viewModel"/>.</exception>
        public static TView GetViewController<TView, TViewModel>(TViewModel viewModel)
            where TView : UIViewController, INavigationView<TViewModel>
            where TViewModel : class, ILifecycleViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<TView, TViewModel>(viewModel);
        }
    }
}
