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
    /// Provides data for the <see cref="Interaction{T}.Requested"/> event.
    /// </summary>
    /// <typeparam name="T">The type of the request.</typeparam>
    public class InteractionRequestedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionRequestedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="request">The request to be passed by the view model to view.</param>
        public InteractionRequestedEventArgs(T request)
        {
            Request = request;
        }

        /// <summary>
        /// Gets the request sent by the view model.
        /// </summary>
        public T Request { get; }
    }
}
