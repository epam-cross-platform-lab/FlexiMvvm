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

namespace FlexiMvvm.ViewModels
{
    public interface ILifecycleViewModel : IViewModel
    {
    }

    public interface ILifecycleViewModelWithoutParameters : ILifecycleViewModel
    {
        Task InitializeAsync();

        void Initialize();
    }

    public interface ILifecycleViewModelWithParameters<TParameters> : ILifecycleViewModel
        where TParameters : Parameters
    {
        Task InitializeAsync(TParameters? parameters);

        void Initialize(TParameters? parameters);
    }

    public interface ILifecycleViewModelWithResult<in TResult> : ILifecycleViewModel
        where TResult : Result
    {
        void SetResult(ResultCode resultCode, TResult? result);
    }

    public interface ILifecycleViewModelWithResultHandler : ILifecycleViewModel
    {
        void HandleResult(ResultCode resultCode, Result? result);
    }
}
