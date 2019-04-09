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
    /// Determines whether a lifecycle-aware view model result is set successfully or not due to cancellation by the user.
    /// </summary>
    public partial struct ResultCode : IEquatable<ResultCode>
    {
        /// <summary>
        /// Indicates that the lifecycle-aware view model result is set successfully.
        /// </summary>
        public static readonly ResultCode Ok = new ResultCode(-1);

        /// <summary>
        /// Indicates that the lifecycle-aware view model result is not set due to cancellation by the user.
        /// </summary>
        public static readonly ResultCode Canceled = new ResultCode(0);

        private readonly sbyte _value;

        private ResultCode(sbyte value)
        {
            _value = value;
        }

        /// <summary>
        /// Determines whether result codes are equal.
        /// </summary>
        /// <param name="code1">First result code to compare.</param>
        /// <param name="code2">Second result code to compare.</param>
        /// <returns><see langword="true"/> if result codes are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(ResultCode code1, ResultCode code2)
        {
            return code1.Equals(code2);
        }

        /// <summary>
        /// Determines whether result codes are not equal.
        /// </summary>
        /// <param name="code1">First result code to compare.</param>
        /// <param name="code2">Second result code to compare.</param>
        /// <returns><see langword="true"/> if result codes are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(ResultCode code1, ResultCode code2)
        {
            return !(code1 == code2);
        }

        /// <summary>
        /// Determines whether the current result code is equal to the <paramref name="obj"/> one.
        /// </summary>
        /// <param name="obj">The result code to compare.</param>
        /// <returns><see langword="true"/> if the <paramref name="obj"/> is <see cref="ResultCode"/> and result codes are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return obj is ResultCode code && Equals(code);
        }

        /// <summary>
        /// Determines whether the current result code is equal to the <paramref name="other"/> one.
        /// </summary>
        /// <param name="other">The result code to compare.</param>
        /// <returns><see langword="true"/> if result codes are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ResultCode other)
        {
            return _value == other._value;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return -1939223833 + _value.GetHashCode();
        }
    }
}
