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

using FlexiMvvm.Views.Core;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides a set of static methods for the <see cref="IViewLifecycleDelegate"/>.
    /// </summary>
    public static class ViewLifecycleDelegateExtensions
    {
        /// <summary>
        /// This method does nothing and just forces the <paramref name="lifecycleDelegate"/> to be created.
        /// It should only be used in the <paramref name="lifecycleDelegate"/> owner's constructor for a lazy loaded property
        /// that itself creates the <paramref name="lifecycleDelegate"/> instance.
        /// <para>
        /// The <see cref="IViewLifecycleDelegate"/> instance should be created in the owner's constructor,
        /// but due to the https://bugzilla.xamarin.com/show_bug.cgi?id=22490 issue,
        /// it should be defined as a lazy loaded property that itself can create the instance.
        /// </para>
        /// </summary>
        /// <param name="lifecycleDelegate">The view lifecycle delegate that needs to be created.</param>
        public static void ForceInstanceCreation(this IViewLifecycleDelegate lifecycleDelegate)
        {
        }
    }
}
