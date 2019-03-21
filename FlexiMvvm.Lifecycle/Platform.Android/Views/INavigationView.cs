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

using Android.Content;
using Android.OS;
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views
{
    public interface INavigationView<out TViewModel> : IView<TViewModel>
        where TViewModel : class, IViewModel
    {
        RequestCode RequestCode { get; }

        void StartActivity(Intent intent);

        void StartActivity(Intent intent, Bundle? options);

        void StartActivityForResult(Intent intent, int requestCode);

        void StartActivityForResult(Intent intent, int requestCode, Bundle? options);

        void SetResult(Android.App.Result resultCode);

        void SetResult(Android.App.Result resultCode, Intent? data);

        void Finish();
    }
}
