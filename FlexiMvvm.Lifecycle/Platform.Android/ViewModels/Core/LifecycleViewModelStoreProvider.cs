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

using FlexiMvvm.Views;

namespace FlexiMvvm.ViewModels.Core
{
    internal static class LifecycleViewModelStoreProvider
    {
        private const string LifecycleViewModelStoreTag = "FlexiMvvm_LifecycleViewModelStore";

        internal static ILifecycleViewModelStore? Get(IView<ILifecycleViewModel> view)
        {
            LifecycleViewModelStoreFragment? store = null;
            var fragmentManager = view.As(
                activity => activity.SupportFragmentManager,
                fragment => fragment.Activity.SupportFragmentManager);

            if (!fragmentManager.IsDestroyed)
            {
                store = (LifecycleViewModelStoreFragment)fragmentManager.FindFragmentByTag(LifecycleViewModelStoreTag);

                if (store == null)
                {
                    store = LifecycleViewModelStoreFragment.NewInstance();

                    fragmentManager
                        .BeginTransaction()
                        .Add(store, LifecycleViewModelStoreTag)
                        .Commit();
                }
            }

            return store;
        }
    }
}
