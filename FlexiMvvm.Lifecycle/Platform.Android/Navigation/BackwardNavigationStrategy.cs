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
using FlexiMvvm.Views;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Defines the contract for backward navigation.
    /// </summary>
    /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
    public delegate void BackwardNavigationDelegate(INavigationView<ILifecycleViewModel> sourceView);

    /// <summary>
    /// Provides a set of backward navigation strategies.
    /// </summary>
    public sealed class BackwardNavigationStrategy
    {
        /// <summary>
        /// Backward navigation using the <see cref="INavigationView{TViewModel}.Finish()"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public BackwardNavigationDelegate Finish()
        {
            return sourceView =>
            {
                sourceView.Finish();
            };
        }
    }
}
