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
using Android.OS;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public sealed class ViewModelStoreFragment : Android.Support.V4.App.Fragment, IViewModelStore
    {
        [CanBeNull]
        private InMemoryViewModelStore _inMemoryViewModelStore;

        [NotNull]
        private InMemoryViewModelStore InMemoryViewModelStore => _inMemoryViewModelStore ?? (_inMemoryViewModelStore = new InMemoryViewModelStore());

        [NotNull]
        public static ViewModelStoreFragment NewInstance()
        {
            return new ViewModelStoreFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RetainInstance = true;
        }

        public TViewModel Get<TViewModel>(string key)
            where TViewModel : class, ILifecycleViewModel
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return InMemoryViewModelStore.Get<TViewModel>(key);
        }

        public void Add<TViewModel>(string key, TViewModel viewModel)
            where TViewModel : class, ILifecycleViewModel
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            InMemoryViewModelStore.Add(key, viewModel);
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            InMemoryViewModelStore.Remove(key);
        }
    }
}
