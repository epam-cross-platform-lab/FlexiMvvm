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
using Android.App;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation
{
    public abstract class NavigationServiceBase
    {
        [NotNull]
        public TActivity GetActivity<TViewModel, TActivity>([NotNull] TViewModel viewModel)
            where TViewModel : class, IViewModel
            where TActivity : Activity, IFlxActivity<TViewModel>
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewModelViewCache.GetView<TViewModel, TActivity>(viewModel);
        }

        [NotNull]
        public TFragment GetAppCompatFragment<TViewModel, TFragment>([NotNull] TViewModel viewModel)
            where TViewModel : class, IViewModel
            where TFragment : Android.Support.V4.App.Fragment, IFlxFragment<TViewModel>
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewModelViewCache.GetView<TViewModel, TFragment>(viewModel);
        }

        [NotNull]
        public TFragment GetFragment<TViewModel, TFragment>([NotNull] TViewModel viewModel)
            where TViewModel : class, IViewModel
            where TFragment : Fragment, IFlxFragment<TViewModel>
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewModelViewCache.GetView<TViewModel, TFragment>(viewModel);
        }

        [NotNull]
        public IAndroidView GetView([NotNull] IViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ViewModelViewCache.GetView<IViewModel, IAndroidView<IViewModel>>(viewModel);
        }
    }
}
