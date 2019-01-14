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
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public interface IAndroidView
    {
        void StartActivity([NotNull] Intent intent);

        void StartActivity([NotNull] Intent intent, [CanBeNull] Bundle options);

        void StartActivityForResult([NotNull] Intent intent, int requestCode);

        void StartActivityForResult([NotNull] Intent intent, int requestCode, [CanBeNull] Bundle options);
    }

    public interface IAndroidView<out TViewModel> : IAndroidView, IView<TViewModel>, IViewModelStoreOwner
        where TViewModel : class, IViewModel
    {
    }
}
