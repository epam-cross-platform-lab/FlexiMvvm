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
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class IntentExtensions
    {
        [CanBeNull]
        public static TParameters GetParameters<TParameters>([NotNull] this Intent intent)
            where TParameters : Parameters
        {
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));

            return intent.Extras?.GetParameters<TParameters>();
        }

        public static void PutParameters<TParameters>([NotNull] this Intent intent, [CanBeNull] TParameters parameters)
            where TParameters : Parameters
        {
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));

            if (parameters != null)
            {
                var bundle = intent.Extras ?? new Bundle();
                bundle.PutParameters(parameters);
                intent.ReplaceExtras(bundle);
            }
        }

        [CanBeNull]
        public static TResult GetResult<TResult>([NotNull] this Intent intent)
            where TResult : Result
        {
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));

            return intent.Extras?.GetResult<TResult>();
        }

        public static void PutResult<TResult>([NotNull] this Intent intent, [CanBeNull] TResult result)
            where TResult : Result
        {
            if (intent == null)
                throw new ArgumentNullException(nameof(intent));

            if (result != null)
            {
                var bundle = intent.Extras ?? new Bundle();
                bundle.PutResult(result);
                intent.ReplaceExtras(bundle);
            }
        }
    }
}
