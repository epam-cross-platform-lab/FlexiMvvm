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
using Android.Content;
using Android.OS;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Navigation
{
    public delegate void ForwardNavigationDelegate([NotNull] INavigationView<IViewModel> fromView, [NotNull] Intent intent, int? requestCode = null);

    public sealed class ForwardNavigationStrategy
    {
        [NotNull]
        public ForwardNavigationDelegate StartActivity([CanBeNull] Bundle options = null)
        {
            return (fromView, intent, requestCode) =>
            {
                fromView.NotNull().StartActivity(intent.NotNull(), options);
            };
        }

        [NotNull]
        public ForwardNavigationDelegate StartActivityForResult([CanBeNull] Bundle options = null)
        {
            return (fromView, intent, requestCode) =>
            {
                if (requestCode == null)
                {
                    throw new ArgumentException(
                        $"Request code should be specified for \"{nameof(StartActivityForResult)}\" navigation strategy.", nameof(requestCode));
                }

                fromView.NotNull().StartActivityForResult(intent.NotNull(), requestCode.Value, options);
            };
        }
    }
}
