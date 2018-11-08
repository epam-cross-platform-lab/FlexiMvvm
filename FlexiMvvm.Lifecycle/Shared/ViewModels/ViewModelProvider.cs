// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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

using FlexiMvvm.Persistence;
using FlexiMvvm.ViewModels.Locator;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public static partial class ViewModelProvider
    {
        [NotNull]
        public static TViewModel Get<TViewModel>([CanBeNull] IBundle stateBundle)
            where TViewModel : class, IViewModel, IViewModelWithState
        {
            var viewModel = Get<TViewModel>();
            viewModel.ImportStateBundle(stateBundle);

            return viewModel;
        }

        [NotNull]
        public static TViewModel Get<TViewModel>()
            where TViewModel : class, IViewModel
        {
            return ViewModelLocator.CreateInstance<TViewModel>();
        }
    }
}
