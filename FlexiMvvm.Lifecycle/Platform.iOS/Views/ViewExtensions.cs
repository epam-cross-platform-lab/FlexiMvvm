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
using System.Linq;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public static class ViewExtensions
    {
        [CanBeNull]
        public static UINavigationController GetNavigationController([NotNull] this IView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return view.As(
                navigationController => navigationController,
                viewController => viewController.NotNull().NavigationController,
                childViewController => FindParentViewController(childViewController.NotNull()).NavigationController);
        }

        internal static void As(
            [NotNull] this IView view,
            [NotNull] Action<UINavigationController> navigationControllerAction,
            [NotNull] Action<UIViewController> viewControllerAction,
            [NotNull] Action<UIViewController> childViewControllerAction)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (navigationControllerAction == null)
                throw new ArgumentNullException(nameof(navigationControllerAction));
            if (viewControllerAction == null)
                throw new ArgumentNullException(nameof(viewControllerAction));
            if (childViewControllerAction == null)
                throw new ArgumentNullException(nameof(childViewControllerAction));

            if (view is UINavigationController navigationController)
            {
                navigationControllerAction(navigationController);
            }
            else if (view is UIViewController viewController)
            {
                if (IsChildViewController(viewController))
                {
                    childViewControllerAction(viewController);
                }
                else
                {
                    viewControllerAction(viewController);
                }
            }
        }

        [CanBeNull]
        public static T As<T>(
            [NotNull] this IView view,
            [NotNull] Func<UINavigationController, T> navigationControllerFunc,
            [NotNull] Func<UIViewController, T> viewControllerFunc,
            [NotNull] Func<UIViewController, T> childViewControllerFunc)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (navigationControllerFunc == null)
                throw new ArgumentNullException(nameof(navigationControllerFunc));
            if (viewControllerFunc == null)
                throw new ArgumentNullException(nameof(viewControllerFunc));
            if (childViewControllerFunc == null)
                throw new ArgumentNullException(nameof(childViewControllerFunc));

            T result = default;

            if (view is UINavigationController navigationController)
            {
                result = navigationControllerFunc(navigationController);
            }
            else if (view is UIViewController viewController)
            {
                result = IsChildViewController(viewController) ? childViewControllerFunc(viewController) : viewControllerFunc(viewController);
            }

            return result;
        }

        private static bool IsChildViewController([NotNull] UIViewController viewController)
        {
            return viewController.ParentViewController?.ChildViewControllers?.Contains(viewController) ?? false;
        }

        [NotNull]
        private static UIViewController FindParentViewController([NotNull] UIViewController viewController)
        {
            return IsChildViewController(viewController) ? FindParentViewController(viewController.ParentViewController.NotNull()) : viewController;
        }
    }
}
