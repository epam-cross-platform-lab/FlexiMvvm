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
using FlexiMvvm.Configuration;
using FlexiMvvm.Formatters;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using Microsoft.Extensions.Logging;
using UIKit;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Defines the contract for forward navigation to the <see cref="UIViewController"/>.
    /// </summary>
    /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
    /// <param name="targetView">The target <see cref="UIViewController"/> for navigation.</param>
    /// <param name="animated">Determines if the transition is to be animated.</param>
    public delegate void ViewControllerForwardNavigationDelegate(INavigationView<ILifecycleViewModel> sourceView, UIViewController targetView, bool animated);

    /// <summary>
    /// Provides a set of forward navigation strategies for the <see cref="UIViewController"/>.
    /// </summary>
    public sealed class ViewControllerForwardNavigationStrategy
    {
        private ILogger? _logger;

        private ILogger Logger => _logger ??= FlexiMvvmConfig.Instance.GetLoggerFactory().CreateLogger<ViewControllerForwardNavigationStrategy>();

        /// <summary>
        /// Forward navigation using the provided <paramref name="strategies"/>. Strategies are executed in the order in which they are passed.
        /// </summary>
        /// <param name="strategies">The strategies to execute during the forward navigation.</param>
        /// <returns>The forward navigation delegate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="strategies"/> is <see langword="null"/>.</exception>
        public ViewControllerForwardNavigationDelegate Composite(params ViewControllerForwardNavigationDelegate[] strategies)
        {
            if (strategies == null)
                throw new ArgumentNullException(nameof(strategies));

            return (sourceView, targetViewIntent, requestCode) =>
            {
                foreach (var strategy in strategies)
                {
                    strategy(sourceView, targetViewIntent, requestCode);
                }
            };
        }

        /// <summary>
        /// Forward navigation using the <see cref="UINavigationController.PushViewController(UIViewController, bool)"/> method.
        /// </summary>
        /// <returns>The forward navigation delegate.</returns>
        public ViewControllerForwardNavigationDelegate PushViewController()
        {
            return (sourceView, targetView, animated) =>
            {
                var navigationController = sourceView.GetNavigationController();

                if (navigationController != null)
                {
                    navigationController.PushViewController(targetView, animated);
                }
                else
                {
                    Logger.LogDebug(
                        $"Unable to push '{TypeFormatter.FormatName(targetView.GetType())}' instance due to " +
                        $"'{TypeFormatter.FormatName(sourceView.GetType())}.{nameof(NavigationViewExtensions.GetNavigationController)}' returned 'null' value.");
                }
            };
        }

        /// <summary>
        /// Forward navigation using the <see cref="INavigationView{TViewModel}.PresentViewController(UIViewController, bool, Action?)"/> method.
        /// </summary>
        /// <param name="completionHandler">The method to invoke when the animation completes. Can be <see langword="null"/>.</param>
        /// <returns>The forward navigation delegate.</returns>
        public ViewControllerForwardNavigationDelegate PresentViewController(Action? completionHandler = null)
        {
            return (sourceView, targetView, animated) =>
            {
                sourceView.PresentViewController(targetView, animated, completionHandler);
            };
        }

        /// <summary>
        /// Forward navigation using the <see cref="UINavigationController.SetViewControllers(UIViewController[], bool)"/> method.
        /// </summary>
        /// <param name="viewControllersProvider">The function that takes the target view delegate parameter as input
        /// and returns array of <see cref="UIViewController"/> to set.</param>
        /// <returns>The forward navigation delegate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewControllersProvider"/> is <see langword="null"/>.</exception>
        public ViewControllerForwardNavigationDelegate SetViewControllers(Func<UIViewController, UIViewController[]> viewControllersProvider)
        {
            if (viewControllersProvider == null)
                throw new ArgumentNullException(nameof(viewControllersProvider));

            return (sourceView, targetView, animated) =>
            {
                var navigationController = sourceView.GetNavigationController();

                if (navigationController != null)
                {
                    navigationController.SetViewControllers(viewControllersProvider(targetView), animated);
                }
                else
                {
                    Logger.LogDebug(
                        $"Unable to set view controllers due to " +
                        $"'{TypeFormatter.FormatName(sourceView.GetType())}.{nameof(NavigationViewExtensions.GetNavigationController)}' returned 'null' value.");
                }
            };
        }
    }
}
