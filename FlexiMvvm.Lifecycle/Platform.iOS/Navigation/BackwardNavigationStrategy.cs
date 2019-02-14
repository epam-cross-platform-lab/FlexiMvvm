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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Defines the contract for backward navigation.
    /// </summary>
    /// <param name="navigationController">The source view navigation controller.</param>
    /// <param name="sourceView">The source view from which navigation is performed from.</param>
    /// <param name="animated">Determines if the transition is to be animated.</param>
    public delegate void BackwardNavigationDelegate([NotNull] UINavigationController navigationController, [NotNull] INavigationView<IViewModel> sourceView, bool animated);

    /// <summary>
    /// Provides a set of backward navigation strategies.
    /// </summary>
    public sealed class BackwardNavigationStrategy
    {
        /// <summary>
        /// Backward navigation using <see cref="UINavigationController.PopViewController(bool)"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        [NotNull]
        public BackwardNavigationDelegate PopViewController()
        {
            return (navigationController, sourceView, animated) =>
            {
                navigationController.NotNull().PopViewController(animated);
            };
        }

        /// <summary>
        /// Backward navigation using <see cref="UINavigationController.PopToViewController(UIViewController, bool)"/> method.
        /// </summary>
        /// <param name="targetView">The target view for navigation.</param>
        /// <returns>The backward navigation delegate.</returns>
        [NotNull]
        public BackwardNavigationDelegate PopToViewController([NotNull] UIViewController targetView)
        {
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            return (navigationController, sourceView, animated) =>
            {
                navigationController.NotNull().PopToViewController(targetView, animated);
            };
        }

        /// <summary>
        /// Backward navigation using <see cref="UINavigationController.PopToRootViewController(bool)"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        [NotNull]
        public BackwardNavigationDelegate PopToRootViewController()
        {
            return (navigationController, sourceView, animated) =>
            {
                navigationController.NotNull().PopToRootViewController(animated);
            };
        }

        /// <summary>
        /// Backward navigation using <see cref="INavigationView{TViewModel}.DismissViewController(bool, Action)"/> method.
        /// </summary>
        /// <param name="completionHandler">The method to invoke when the animation completes.</param>
        /// <returns>The backward navigation delegate.</returns>
        [NotNull]
        public BackwardNavigationDelegate DismissViewController([CanBeNull] Action completionHandler = null)
        {
            return (navigationController, sourceView, animated) =>
            {
                sourceView.NotNull().DismissViewController(animated, completionHandler);
            };
        }
    }
}
