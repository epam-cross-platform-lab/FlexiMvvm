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
        public INavigationView<IViewModel> GetView([NotNull] IViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModel>, IViewModel>(viewModel);
        }

        [NotNull]
        public INavigationView<IViewModelWithResultHandler> GetView([NotNull] IViewModelWithResultHandler viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModelWithResultHandler>, IViewModelWithResultHandler>(viewModel);
        }

        [NotNull]
        public INavigationView<IViewModelWithResult<TResult>> GetView<TResult>([NotNull] IViewModelWithResult<TResult> viewModel)
            where TResult : Result
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewCache.Get<INavigationView<IViewModelWithResult<TResult>>, IViewModelWithResult<TResult>>(viewModel);
        }
    }
}
