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

using FlexiMvvm.Commands;

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Base class for a view model implementation. Typically, such view models are used as children of lifecycle-aware view models.
    /// </summary>
    public abstract class ViewModel : ObservableObject, IViewModel
    {
        private CommandProvider? _commandProvider;

        /// <summary>
        /// Gets an existing command provider or creates a new one in the scope of the view model.
        /// </summary>
        protected CommandProvider CommandProvider => _commandProvider ?? (_commandProvider = new CommandProvider());
    }
}
