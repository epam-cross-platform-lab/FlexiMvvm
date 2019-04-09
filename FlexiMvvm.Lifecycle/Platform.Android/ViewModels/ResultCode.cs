﻿// =========================================================================
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

namespace FlexiMvvm.ViewModels
{
    public partial struct ResultCode
    {
        /// <summary>
        /// Converts the <paramref name="resultCode"/> instance to the <see cref="ResultCode"/> type.
        /// </summary>
        /// <param name="resultCode">The result code to convert.</param>
        public static implicit operator ResultCode(Android.App.Result resultCode)
        {
            return resultCode == Android.App.Result.Ok ? Ok : Canceled;
        }

        /// <summary>
        /// Converts the <paramref name="resultCode"/> instance to the <see cref="Android.App.Result"/> type.
        /// </summary>
        /// <param name="resultCode">The result code to convert.</param>
        public static implicit operator Android.App.Result(ResultCode resultCode)
        {
            return resultCode == Ok ? Android.App.Result.Ok : Android.App.Result.Canceled;
        }
    }
}
