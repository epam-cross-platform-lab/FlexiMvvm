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
using FlexiMvvm.Persistence;
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views
{
    public sealed class RequestCode
    {
        public const int InvalidRequestCode = -1;

        private IBundle? _state;

        private IBundle State => _state ?? (_state = BundleFactory.Create());

        public int GetFor<TResultMapper>()
            where TResultMapper : IResultMapper<Result>, new()
        {
            var resultMapperAssemblyQualifiedName = typeof(TResultMapper).AssemblyQualifiedName;
            var requestCode = State.GetInt(InvalidRequestCode, resultMapperAssemblyQualifiedName);

            if (requestCode == InvalidRequestCode)
            {
                requestCode = State.Count;
                State.SetInt(requestCode, resultMapperAssemblyQualifiedName);
                State.SetString(resultMapperAssemblyQualifiedName, requestCode.ToString());
            }

            return requestCode;
        }

        internal IResultMapper<Result>? GetResultMapper(int requestCode)
        {
            IResultMapper<Result>? resultMapper = null;
            var resultMapperAssemblyQualifiedName = _state?.GetString(null, requestCode.ToString());

            if (!string.IsNullOrWhiteSpace(resultMapperAssemblyQualifiedName))
            {
                var resultMapperType = Type.GetType(resultMapperAssemblyQualifiedName);
                resultMapper = (IResultMapper<Result>)Activator.CreateInstance(resultMapperType);
            }

            return resultMapper;
        }

        internal void ImportState(IBundle? state)
        {
            _state = state;
        }

        internal IBundle? ExportState()
        {
            return _state;
        }
    }
}
