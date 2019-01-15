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
    public abstract partial class NavigationService
    {
        [NotNull]
        public static IForwardNavigationView<IViewModel> GetForwardNavigationView([NotNull] IViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<IForwardNavigationView<IViewModel>, IViewModel>(viewModel);
        }

        [NotNull]
        public static IForwardNavigationView<IViewModelWithResultHandler> GetForwardNavigationView([NotNull] IViewModelWithResultHandler viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<IForwardNavigationView<IViewModelWithResultHandler>, IViewModelWithResultHandler>(viewModel);
        }

        [NotNull]
        public static IBackwardNavigationView<IViewModelWithResult<TResult>> GetBackwardNavigationView<TResult>([NotNull] IViewModelWithResult<TResult> viewModel)
            where TResult : Result
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<IBackwardNavigationView<IViewModelWithResult<TResult>>, IViewModelWithResult<TResult>>(viewModel);
        }
    }
}
