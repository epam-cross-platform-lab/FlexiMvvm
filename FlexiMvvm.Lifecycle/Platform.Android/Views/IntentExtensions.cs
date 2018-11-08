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

using System;
using Android.Content;
using Android.OS;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class IntentExtensions
    {
        [CanBeNull]
        public static TParameters GetViewModelParameters<TParameters>([CanBeNull] this Intent intent)
            where TParameters : ViewModelParametersBase
        {
            return intent?.Extras.GetViewModelParameters<TParameters>();
        }

        public static void PutViewModelParameters<TParameters>([NotNull] this Intent intent, [CanBeNull] TParameters parameters)
            where TParameters : ViewModelParametersBase
        {
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));

            var bundle = intent.Extras ?? new Bundle();
            bundle.PutViewModelParameters(parameters);

            intent.ReplaceExtras(bundle);
        }

        [CanBeNull]
        public static TResult GetViewModelResult<TResult>([CanBeNull] this Intent intent)
            where TResult : ViewModelResultBase
        {
            return intent?.Extras.GetViewModelResult<TResult>();
        }

        public static void PutViewModelResult<TResult>([NotNull] this Intent intent, [CanBeNull] TResult result)
            where TResult : ViewModelResultBase
        {
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));

            var bundle = intent.Extras ?? new Bundle();
            bundle.PutViewModelResult(result);

            intent.ReplaceExtras(bundle);
        }
    }
}
