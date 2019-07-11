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
using Android.App;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Defines the contract for backward navigation from the <see cref="Activity"/>.
    /// </summary>
    /// <param name="sourceView">The <see cref="Activity"/> from which navigation is performed from.</param>
    public delegate void ActivityBackwardNavigationDelegate(Activity sourceView);

    /// <summary>
    /// Provides a set of backward navigation strategies for the <see cref="Activity"/>.
    /// </summary>
    public sealed class ActivityBackwardNavigationStrategy
    {
        /// <summary>
        /// Backward navigation using the provided <paramref name="strategies"/>. Strategies are executed in the order in which they are passed.
        /// </summary>
        /// <param name="strategies">The strategies to execute during the backward navigation.</param>
        /// <returns>The backward navigation delegate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="strategies"/> is <see langword="null"/>.</exception>
        public ActivityBackwardNavigationDelegate Composite(params ActivityBackwardNavigationDelegate[] strategies)
        {
            if (strategies == null)
                throw new ArgumentNullException(nameof(strategies));

            return (sourceView) =>
            {
                foreach (var strategy in strategies)
                {
                    strategy(sourceView);
                }
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="Activity.Finish"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public ActivityBackwardNavigationDelegate Finish()
        {
            return sourceView =>
            {
                sourceView.Finish();
            };
        }
    }
}
