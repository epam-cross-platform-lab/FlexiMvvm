﻿// =========================================================================
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
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Defines the contract for a result mapper that knows how to create a lifecycle-aware view model result instance
    /// based on a set of key/value pairs stored in the passed <see cref="Intent"/> data.
    /// </summary>
    /// <typeparam name="TResult">The type of the view model result to create.</typeparam>
    public interface IResultMapper<out TResult>
        where TResult : Result
    {
        /// <summary>
        /// Creates a new <typeparamref name="TResult"/> instance based on a set of key/value pairs stored in the <paramref name="data"/>.
        /// </summary>
        /// <param name="data">Contains a set of key/value pairs that is used as source data for the view model result. Can be <see langword="null"/>.</param>
        /// <returns>The view model result instance if the <paramref name="data"/> is not <see langword="null"/>; otherwise, <see langword="null"/>.</returns>
        TResult? Map(Intent? data);
    }
}
