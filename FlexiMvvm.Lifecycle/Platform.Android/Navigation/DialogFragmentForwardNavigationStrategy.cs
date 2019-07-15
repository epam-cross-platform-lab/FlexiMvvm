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
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace FlexiMvvm.Navigation
{
    using Android.Support.V4.App;

    /// <summary>
    /// Defines the contract for forward navigation to the <see cref="DialogFragment"/>.
    /// </summary>
    /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
    /// <param name="sourceViewFragmentManager">The <see cref="FragmentManager"/> of the source view.</param>
    /// <param name="targetView">The target <see cref="DialogFragment"/> for navigation.</param>
    public delegate void DialogFragmentForwardNavigationDelegate(INavigationView<ILifecycleViewModel> sourceView, FragmentManager sourceViewFragmentManager, DialogFragment targetView);

    /// <summary>
    /// Provides a set of forward navigation strategies for the <see cref="DialogFragment"/>.
    /// </summary>
    public sealed class DialogFragmentForwardNavigationStrategy
    {
        /// <summary>
        /// The default tag used for showing the <see cref="DialogFragment"/>.
        /// </summary>
        public const string DialogFragmentTag = "Dialog";

        /// <summary>
        /// Forward navigation using the provided <paramref name="strategies"/>. Strategies are executed in the order in which they are passed.
        /// </summary>
        /// <param name="strategies">The strategies to execute during the forward navigation.</param>
        /// <returns>The forward navigation delegate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="strategies"/> is <see langword="null"/>.</exception>
        public DialogFragmentForwardNavigationDelegate Composite(params DialogFragmentForwardNavigationDelegate[] strategies)
        {
            if (strategies == null)
                throw new ArgumentNullException(nameof(strategies));

            return (sourceView, sourceViewFragmentManager, targetView) =>
            {
                foreach (var strategy in strategies)
                {
                    strategy(sourceView, sourceViewFragmentManager, targetView);
                }
            };
        }

        /// <summary>
        /// Forward navigation using the <see cref="DialogFragment.Show(FragmentManager, string?)"/> method.
        /// <para>
        /// The default value for tag is <see cref="DialogFragmentTag"/> value.
        /// </para>
        /// </summary>
        /// <returns>The forward navigation delegate.</returns>
        public DialogFragmentForwardNavigationDelegate Show()
        {
            return (sourceView, sourceViewFragmentManager, targetView) =>
            {
                targetView.Show(sourceViewFragmentManager, DialogFragmentTag);
            };
        }

        /// <summary>
        /// Forward navigation using the <see cref="DialogFragment.Show(FragmentManager, string?)"/> method.
        /// </summary>
        /// <param name="tag">The tag for this fragment, as per <see cref="FragmentTransaction.Add(Fragment, string?)"/>. Can be <see langword="null"/>.</param>
        /// <returns>The forward navigation delegate.</returns>
        public DialogFragmentForwardNavigationDelegate Show(string? tag)
        {
            return (sourceView, sourceViewFragmentManager, targetView) =>
            {
                targetView.Show(sourceViewFragmentManager, tag);
            };
        }

#if __ANDROID_28__
        /// <summary>
        /// Forward navigation using the <see cref="DialogFragment.ShowNow(FragmentManager, string?)"/> method.
        /// <para>
        /// The default value for tag is <see cref="DialogFragmentTag"/> value.
        /// </para>
        /// </summary>
        /// <returns>The forward navigation delegate.</returns>
        public DialogFragmentForwardNavigationDelegate ShowNow()
        {
            return (sourceView, sourceViewFragmentManager, targetView) =>
            {
                targetView.ShowNow(sourceViewFragmentManager, DialogFragmentTag);
            };
        }

        /// <summary>
        /// Forward navigation using the <see cref="DialogFragment.ShowNow(FragmentManager, string?)"/> method.
        /// </summary>
        /// <param name="tag">The tag for this fragment, as per <see cref="FragmentTransaction.Add(Fragment, string?)"/>. Can be <see langword="null"/>.</param>
        /// <returns>The forward navigation delegate.</returns>
        public DialogFragmentForwardNavigationDelegate ShowNow(string? tag)
        {
            return (sourceView, sourceViewFragmentManager, targetView) =>
            {
                targetView.ShowNow(sourceViewFragmentManager, tag);
            };
        }
#endif
    }
}
