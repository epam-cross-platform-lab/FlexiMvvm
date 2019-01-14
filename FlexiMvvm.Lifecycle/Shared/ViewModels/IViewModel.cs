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

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FlexiMvvm.Persistence;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        [CanBeNull]
        Task Initialization { get; }

        [NotifyPropertyChangedInvocator]
        void RaisePropertyChanged([CallerMemberName] string propertyName = null);
    }

    public interface IViewModelWithState : IViewModel
    {
        void ImportStateBundle([CanBeNull] IBundle bundle);

        [CanBeNull]
        IBundle ExportStateBundle();
    }

    public interface IViewModelWithoutParameters : IViewModel
    {
        void Initialize();

        [NotNull]
        Task InitializeAsync();
    }

    public interface IViewModelWithParameters<in TParameters> : IViewModel
        where TParameters : ViewModelParametersBase
    {
        void Initialize([CanBeNull] TParameters parameters);

        [NotNull]
        Task InitializeAsync([CanBeNull] TParameters parameters);
    }

    public interface IViewModelWithResult<in TResult> : IViewModel
        where TResult : ViewModelResultBase
    {
        void SetResult(ViewModelResultCode resultCode, [CanBeNull] TResult result);
    }

    public interface IViewModelWithResultHandler : IViewModel
    {
        void HandleResult(ViewModelResultCode resultCode, [CanBeNull] ViewModelResultBase result);
    }
}
