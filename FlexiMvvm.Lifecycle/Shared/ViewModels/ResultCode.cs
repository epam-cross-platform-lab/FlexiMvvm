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
    public partial struct ResultCode : IEquatable<ResultCode>
    {
        public static readonly ResultCode Ok = new ResultCode(-1);
        public static readonly ResultCode Canceled = new ResultCode(0);

        private readonly sbyte _value;

        private ResultCode(sbyte value)
        {
            _value = value;
        }

        public static bool operator ==(ResultCode code1, ResultCode code2)
        {
            return code1.Equals(code2);
        }

        public static bool operator !=(ResultCode code1, ResultCode code2)
        {
            return !(code1 == code2);
        }

        public override bool Equals(object obj)
        {
            return obj is ResultCode code && Equals(code);
        }

        public bool Equals(ResultCode other)
        {
            return _value == other._value;
        }

        public override int GetHashCode()
        {
            return -1939223833 + _value.GetHashCode();
        }
    }
}
