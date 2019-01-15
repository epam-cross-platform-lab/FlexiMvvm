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

using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public interface IViewModel
    {
        [NotNull]
        Task InitializeAsync();
    }

    public interface IViewModelWithParameters<out TParameters> : IViewModel
        where TParameters : Parameters
    {
        [CanBeNull]
        TParameters Parameters { get; }
    }

    public interface IViewModelWithResult<in TResult> : IViewModel
        where TResult : Result
    {
        void SetResult(ResultCode resultCode, [CanBeNull] TResult result);
    }

    public interface IViewModelWithResultHandler : IViewModel
    {
        void HandleResult(ResultCode resultCode, [CanBeNull] Result result);
    }
}
