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

using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views.Core
{
    internal static class ViewModelStoreProvider
    {
        private const string ViewModelStoreTag = "FlexiMvvm_ViewModelStore";

        internal static IViewModelStore? Get(IView<IViewModel> view)
        {
            ViewModelStoreFragment? store = null;
            var fragmentManager = view.As(
                activity => activity.SupportFragmentManager,
                fragment => fragment.Activity.SupportFragmentManager);

            if (!fragmentManager.IsDestroyed)
            {
                store = (ViewModelStoreFragment)fragmentManager.FindFragmentByTag(ViewModelStoreTag);

                if (store == null)
                {
                    store = ViewModelStoreFragment.NewInstance();

                    fragmentManager
                        .BeginTransaction()
                        .Add(store, ViewModelStoreTag)
                        .Commit();
                }
            }

            return store;
        }
    }
}
