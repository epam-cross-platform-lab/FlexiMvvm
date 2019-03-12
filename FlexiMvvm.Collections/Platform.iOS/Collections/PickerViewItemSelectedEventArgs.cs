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

using System;

namespace FlexiMvvm.Collections
{
    /// <summary>
    /// Provides data for the <see cref="PickerViewObservableModel{T}.SelectedCalled"/> event.
    /// </summary>
    public class PickerViewItemSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PickerViewItemSelectedEventArgs"/> class.
        /// </summary>
        /// <param name="row">The selected row index of the <paramref name="component"/>.</param>
        /// <param name="component">The selected component index.</param>
        public PickerViewItemSelectedEventArgs(nint row, nint component)
        {
            Row = row;
            Component = component;
        }

        /// <summary>
        /// Gets the selected row index of the <see cref="Component"/>.
        /// </summary>
        public nint Row { get; }

        /// <summary>
        /// Gets the selected component index.
        /// </summary>
        public nint Component { get; }
    }
}
