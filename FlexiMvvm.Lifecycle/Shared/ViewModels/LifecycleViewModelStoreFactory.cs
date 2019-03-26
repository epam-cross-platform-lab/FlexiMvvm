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

using FlexiMvvm.ViewModels.Core;

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Represents a lifecycle-aware view model store factory.
    /// </summary>
    public static class LifecycleViewModelStoreFactory
    {
        /// <summary>
        /// Creates a new instance of the lifecycle-aware view model store.
        /// </summary>
        /// <returns>The view model store instance.</returns>
        public static ILifecycleViewModelStore Create()
        {
#if __ANDROID__
            return LifecycleViewModelStoreFragment.NewInstance();
#else
            return new InMemoryLifecycleViewModelStore();
#endif
        }
    }
}
