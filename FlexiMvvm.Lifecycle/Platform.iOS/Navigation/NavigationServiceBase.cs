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

using System;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Navigation
{
    public abstract class NavigationServiceBase
    {
        [NotNull]
        public TViewController GetViewController<TViewModel, TViewController>([NotNull] TViewModel viewModel)
            where TViewModel : class, IViewModel
            where TViewController : UIViewController, IFlxViewController<TViewModel>
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewModelViewCache.GetView<TViewModel, TViewController>(viewModel);
        }

        [NotNull]
        public IIosView GetView([NotNull] IViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewModelViewCache.GetView<IViewModel, IIosView<IViewModel>>(viewModel);
        }
    }
}
