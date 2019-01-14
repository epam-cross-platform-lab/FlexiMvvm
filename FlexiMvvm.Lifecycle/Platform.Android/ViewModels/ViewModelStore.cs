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
using Android.App;
using Android.OS;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    internal class ViewModelStore : Fragment
    {
        [NotNull]
        private readonly Dictionary<string, IViewModel> _viewModels = new Dictionary<string, IViewModel>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RetainInstance = true;
        }

        [CanBeNull]
        internal TViewModel Get<TViewModel>([NotNull] string key)
            where TViewModel : class, IViewModel
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            TViewModel viewModel = null;

            if (_viewModels.ContainsKey(key))
            {
                viewModel = (TViewModel)_viewModels[key];
            }

            return viewModel;
        }

        internal void Set<TViewModel>([NotNull] string key, [NotNull] IViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            _viewModels[key] = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
