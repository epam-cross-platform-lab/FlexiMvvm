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
using Android.Widget;
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    /// <summary>
    /// Provides a set of static methods for creating bindings on <see cref="Spinner"/> members.
    /// </summary>
    public static class SpinnerExtensions
    {
        /// <summary>
        /// One way binding on <see cref="Spinner.Prompt"/> property. Prompt is passed as a value.
        /// </summary>
        /// <param name="spinnerReference">The spinner reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="spinnerReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<Spinner, string?> PromptBinding(
            this IItemReference<Spinner> spinnerReference)
        {
            if (spinnerReference == null)
                throw new ArgumentNullException(nameof(spinnerReference));

            return new TargetItemOneWayCustomBinding<Spinner, string?>(
                spinnerReference,
                (spinner, prompt) => spinner.Prompt = prompt,
                () => $"{nameof(Spinner.Prompt)}");
        }

        /// <summary>
        /// One way binding on <see cref="Spinner.SetPromptId(int)"/> method. Prompt resource ID is passed as a value.
        /// </summary>
        /// <param name="spinnerReference">The spinner reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="spinnerReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<Spinner, int> SetPromptIdBinding(
            this IItemReference<Spinner> spinnerReference)
        {
            if (spinnerReference == null)
                throw new ArgumentNullException(nameof(spinnerReference));

            return new TargetItemOneWayCustomBinding<Spinner, int>(
                spinnerReference,
                (spinner, promptId) => spinner.SetPromptId(promptId),
                () => $"{nameof(Spinner.SetPromptId)}");
        }
    }
}
