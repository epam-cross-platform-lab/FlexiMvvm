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

using FlexiMvvm.Views.Keyboard;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Defines the contract for a platform-specific view.
    /// </summary>
    public interface IIosView
    {
        /// <summary>
        /// Gets the keyboard handler that is responsible for scrolling the view to make the invisible or partially visible
        /// focused field fully visible when the keyboard appears. Can be <c>null</c>.
        /// </summary>
        IKeyboardHandler? KeyboardHandler { get; }
    }
}
