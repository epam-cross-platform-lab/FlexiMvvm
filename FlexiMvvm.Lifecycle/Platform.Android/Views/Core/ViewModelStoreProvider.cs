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
using JetBrains.Annotations;

namespace FlexiMvvm.Views.Core
{
    internal static class ViewModelStoreProvider
    {
        private const string ViewModelStoreTag = "FlexiMvvm_ViewModelStore";

        [NotNull]
        internal static IViewModelStore Get([NotNull] IView view)
        {
            var fragmentManager = view.GetActivity().SupportFragmentManager.NotNull();
            var store = (ViewModelStoreFragment)fragmentManager.FindFragmentByTag(ViewModelStoreTag);

            if (store == null)
            {
                store = ViewModelStoreFragment.NewInstance();

                fragmentManager
                    .BeginTransaction().NotNull()
                    .Add(store, ViewModelStoreTag).NotNull()
                    .Commit();
            }

            return store;
        }
    }
}
