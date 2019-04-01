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
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides data for the <see cref="INavigationView{TViewModel}.ResultSet"/> event.
    /// </summary>
    public class ResultSetEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultSetEventArgs"/> class.
        /// </summary>
        /// <param name="resultCode">Determines whether the result should be set as successful or not due to cancellation by the user.</param>
        /// <param name="result">The view model result. Can be <c>null</c>.</param>
        public ResultSetEventArgs(ResultCode resultCode, Result? result)
        {
            ResultCode = resultCode;
            Result = result;
        }

        /// <summary>
        /// Gets the result code indicating whether the lifecycle-aware view model result is set successfully or not due to cancellation by the user.
        /// </summary>
        public ResultCode ResultCode { get; }

        /// <summary>
        /// Gets the lifecycle-aware view model result. Can be <c>null</c>.
        /// </summary>
        public Result? Result { get; }
    }
}
