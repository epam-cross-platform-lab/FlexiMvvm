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

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Defines the contract for a view that owns a lifecycle-aware view model.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public interface IView<out TViewModel>
        where TViewModel : class, ILifecycleViewModel
    {
        /// <summary>
        /// Gets the lifecycle-aware view model.
        /// </summary>
        TViewModel ViewModel { get; }
    }
}
