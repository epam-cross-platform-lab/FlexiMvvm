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
using System.Collections.Generic;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public sealed class RequestCode
    {
        [CanBeNull]
        [ItemNotNull]
        private List<Type> _requestsCodes;
        [CanBeNull]
        [ItemNotNull]
        private List<IResultMapper> _resultsMappers;

        [NotNull]
        [ItemNotNull]
        private List<Type> RequestsCodes => _requestsCodes ?? (_requestsCodes = new List<Type>());

        [NotNull]
        [ItemNotNull]
        private List<IResultMapper> ResultsMappers => _resultsMappers ?? (_resultsMappers = new List<IResultMapper>());

        public int GetFor<TResult>([CanBeNull] IResultMapper mapper = null)
            where TResult : Result
        {
            var resultType = typeof(TResult);
            var requestCode = RequestsCodes.IndexOf(resultType);

            if (requestCode == -1)
            {
                RequestsCodes.Add(resultType);
                ResultsMappers.Add(mapper ?? new ResultMapper<TResult>());

                requestCode = RequestsCodes.Count - 1;
            }

            return requestCode;
        }

        [CanBeNull]
        internal IResultMapper GetResultMapper(int requestCode)
        {
            IResultMapper mapper = null;

            if (requestCode > -1 && requestCode < ResultsMappers.Count)
            {
                mapper = ResultsMappers[requestCode];
            }

            return mapper;
        }
    }
}
