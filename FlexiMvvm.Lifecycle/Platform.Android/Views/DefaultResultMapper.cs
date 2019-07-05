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
using Android.Support.V4.App;
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Default implementation of the <see cref="IResultMapper{TResult}"/>.
    /// Uses <see cref="IntentExtensions.GetResult{TResult}(Intent)"/> to create a lifecycle-aware view model result instance.
    /// </summary>
    /// <typeparam name="TResult">The type of the view model result to create.</typeparam>
    public sealed class DefaultResultMapper<TResult> : IResultMapper<TResult>
        where TResult : Result
    {
        /// <inheritdoc />
        public TResult? Map(FragmentActivity activity, Android.App.Result resultCode, Intent? data)
        {
            return data?.GetResult<TResult>();
        }
    }
}
