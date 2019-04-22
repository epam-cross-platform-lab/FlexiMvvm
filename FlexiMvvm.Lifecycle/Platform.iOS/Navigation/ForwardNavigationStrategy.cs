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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Defines the contract for forward navigation.
    /// </summary>
    /// <param name="navigationController">The source view navigation controller.</param>
    /// <param name="targetView">The target view for navigation.</param>
    /// <param name="animated">Determines if the transition is to be animated.</param>
    public delegate void ForwardNavigationDelegate([NotNull] UINavigationController navigationController, [NotNull] UIViewController targetView, bool animated);

    /// <summary>
    /// Provides a set of forward navigation strategies.
    /// </summary>
    public sealed class ForwardNavigationStrategy
    {
        /// <summary>
        /// Forward navigation using <see cref="UINavigationController.PushViewController(UIViewController, bool)"/> method.
        /// </summary>
        /// <returns>The forward navigation delegate.</returns>
        [NotNull]
        public ForwardNavigationDelegate PushViewController()
        {
            return (navigationController, targetView, animated) =>
            {
                navigationController.NotNull().PushViewController(targetView.NotNull(), animated);
            };
        }

        /// <summary>
        /// Forward navigation using <see cref="UIViewController.PresentViewController(UIViewController, bool, Action)"/> method.
        /// </summary>
        /// <param name="completionHandler">The method to invoke when the animation completes.</param>
        /// <returns>The forward navigation delegate.</returns>
        [NotNull]
        public ForwardNavigationDelegate PresentViewController([CanBeNull] Action completionHandler = null)
        {
            return (navigationController, targetView, animated) =>
            {
                navigationController.NotNull().PresentViewController(targetView.NotNull(), animated, completionHandler);
            };
        }

        /// <summary>
        /// Forward navigation using <see cref="UINavigationController.SetViewControllers(UIViewController[], bool)"/> method.
        /// </summary>
        /// <returns>The forward navigation delegate.</returns>
        [NotNull]
        public ForwardNavigationDelegate SetViewControllers()
        {
            return (navigationController, targetView, animated) =>
            {
                navigationController.NotNull().SetViewControllers(new UIViewController[] { targetView.NotNull() }, animated);
            };
        }

        /// <summary>
        /// Forward navigation using <see cref="UINavigationController.SetViewControllers(UIViewController[], bool)"/> method.
        /// </summary>
        /// <param name="viewControllers">The array of view controllers to be set. Target view delegate parameter will be ignored.</param>
        /// <returns>The forward navigation delegate.</returns>
        [NotNull]
        public ForwardNavigationDelegate SetViewControllers([CanBeNull] UIViewController[] viewControllers)
        {
            return (navigationController, targetView, animated) =>
            {
                navigationController.NotNull().SetViewControllers(viewControllers, animated);
            };
        }
    }
}
