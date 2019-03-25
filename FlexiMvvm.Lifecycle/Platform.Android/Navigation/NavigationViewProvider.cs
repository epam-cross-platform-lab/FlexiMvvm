﻿// =========================================================================
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
using Fragment = Android.Support.V4.App.Fragment;
using FragmentActivity = Android.Support.V4.App.FragmentActivity;

namespace FlexiMvvm.Navigation
{
    public static partial class NavigationViewProvider
    {
        /// <summary>
        /// Gets the navigation view derived from the <see cref="FragmentActivity"/>.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="viewModel">The view model used for getting a bound view.</param>
        /// <returns>The navigation view.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for <paramref name="viewModel"/> instance.</exception>
        public static TView GetActivity<TView, TViewModel>(TViewModel viewModel)
            where TView : FragmentActivity, INavigationView<TViewModel>
            where TViewModel : class, ILifecycleViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<TView, TViewModel>(viewModel);
        }

        /// <summary>
        /// Gets the navigation view derived from the <see cref="Fragment"/>.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="viewModel">The view model used for getting a bound view.</param>
        /// <returns>The navigation view.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The view instance is missing for <paramref name="viewModel"/> instance.</exception>
        public static TView GetFragment<TView, TViewModel>(TViewModel viewModel)
            where TView : Fragment, INavigationView<TViewModel>
            where TViewModel : class, ILifecycleViewModel
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<TView, TViewModel>(viewModel);
        }
    }
}
