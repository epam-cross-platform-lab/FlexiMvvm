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
using Android.Views;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides data for the <see cref="IOptionsMenuSource.OnOptionsItemSelectedCalled"/> event.
    /// </summary>
    public class OptionsItemSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsItemSelectedEventArgs"/> class.
        /// </summary>
        /// <param name="item">The selected menu item.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        public OptionsItemSelectedEventArgs(IMenuItem item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }

        /// <summary>
        /// Gets the selected menu item.
        /// </summary>
        public IMenuItem Item { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the menu item selection is handled successfully or allow normal menu processing to proceed.
        /// <para>The default value is <see langword="false"/>.</para>
        /// </summary>
        public bool Handled { get; set; }
    }
}
