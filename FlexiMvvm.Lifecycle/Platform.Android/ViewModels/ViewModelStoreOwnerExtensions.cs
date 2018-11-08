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

using Android.OS;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    internal static class ViewModelStoreOwnerExtensions
    {
        private const string ViewModelStoreTag = "FlexiMvvm_ViewModelStore";

        [NotNull]
        internal static ViewModelStore GetViewModelStore([NotNull] this IViewModelStoreOwner owner)
        {
            var fragmentManager = owner.GetFragmentManager();
            var store = (ViewModelStore)fragmentManager.FindFragmentByTag(ViewModelStoreTag);

            if (store == null)
            {
                store = new ViewModelStore();

                var fragmentTransaction = fragmentManager
                    .BeginTransaction().NotNull()
                    .Add(store, ViewModelStoreTag).NotNull();

                if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                {
                    fragmentTransaction.CommitNow();
                }
                else
                {
                    fragmentTransaction.Commit();
                    fragmentManager.ExecutePendingTransactions();
                }
            }

            return store;
        }
    }
}
