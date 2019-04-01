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

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Defines the contract for a view model to view interaction.
    /// </summary>
    public class Interaction
    {
        /// <summary>
        /// Occurs when the view model requested the interaction.
        /// </summary>
        public event EventHandler Requested;

        /// <summary>
        /// Raises the <see cref="Requested"/> event.
        /// </summary>
        public void RaiseRequested()
        {
            Requested?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Defines the contract for a view model to view interaction.
    /// </summary>
    /// <typeparam name="T">The type of the request.</typeparam>
    public class Interaction<T>
    {
        /// <summary>
        /// Raised when the view model requested the interaction.
        /// </summary>
        public event EventHandler<InteractionRequestedEventArgs<T>> Requested;

        /// <summary>
        /// Raises the <see cref="Requested"/> event.
        /// </summary>
        /// <param name="request">The request to be passed in the event arguments.</param>
        public void RaiseRequested(T request)
        {
            Requested?.Invoke(this, new InteractionRequestedEventArgs<T>(request));
        }
    }
}
