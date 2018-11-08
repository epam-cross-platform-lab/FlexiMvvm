// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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

using Android.App;
using Android.Content;
using Android.OS;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views.Core
{
    public interface IViewDelegate<out TView>
        where TView : class, IAndroidView
    {
        [NotNull]
        TView View { get; }

        void OnCreate([CanBeNull] Bundle savedInstanceState);

        void OnActivityCreated();

        void OnStart();

        void OnResume();

        void OnPause();

        void OnStop();

        void OnActivityResult(int requestCode, Result resultCode, [CanBeNull] Intent data);

        void OnSaveInstanceState([NotNull] Bundle outState);

        void OnDestroyView();

        void OnDestroy();
    }

    public interface IViewDelegate<out TView, out TViewModel> : IViewDelegate<TView>
        where TView : class, IAndroidView<TViewModel>
        where TViewModel : class, IViewModel
    {
        [NotNull]
        TViewModel ViewModel { get; }
    }
}
