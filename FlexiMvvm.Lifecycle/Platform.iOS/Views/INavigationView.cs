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
    public interface INavigationView<out TViewModel> : IView<TViewModel>
        where TViewModel : class, IViewModel
    {
        event EventHandler<ResultSetEventArgs> ResultSet;

        bool IsBeingPresented { get; }

        bool IsBeingDismissed { get; }

        bool IsMovingFromParentViewController { get; }

        void SetResult(ResultCode resultCode);

        void SetResult(ResultCode resultCode, Result? result);

        void RaiseResultSet(ResultCode resultCode, Result? result);

        void HandleResult(object sender, ResultSetEventArgs args);

        void DismissViewController(bool animated, Action? completionHandler);
    }
}
