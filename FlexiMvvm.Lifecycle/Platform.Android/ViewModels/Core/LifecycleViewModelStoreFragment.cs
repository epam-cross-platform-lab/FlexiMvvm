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
using System.Collections.Generic;
using Android.OS;

namespace FlexiMvvm.ViewModels.Core
{
    using Android.Support.V4.App;

    internal sealed class LifecycleViewModelStoreFragment : Fragment, ILifecycleViewModelStore
    {
        private Dictionary<string, ILifecycleViewModel>? _viewModels;

        private Dictionary<string, ILifecycleViewModel> ViewModels => _viewModels ??= new Dictionary<string, ILifecycleViewModel>();

        internal static LifecycleViewModelStoreFragment NewInstance()
        {
            return new LifecycleViewModelStoreFragment();
        }

        public override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RetainInstance = true;
        }

        /// <inheritdoc />
        public TViewModel? Get<TViewModel>(string key)
            where TViewModel : class, ILifecycleViewModel
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (TViewModel)_viewModels.GetValueOrDefault(key);
        }

        /// <inheritdoc />
        public void Add<TViewModel>(string key, TViewModel viewModel)
            where TViewModel : class, ILifecycleViewModel
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (ViewModels.ContainsKey(key))
                throw new ArgumentException($"The lifecycle-aware view model store already has a view model with the '{key}' key.");

            ViewModels[key] = viewModel;
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            ViewModels.Remove(key);
        }
    }
}
