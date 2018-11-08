// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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

namespace FlexiMvvm.Navigation.Generic
{
    public delegate void ForwardNavigationDelegate(UINavigationController navigationController, UIViewController toView, bool animated);

    public class ForwardNavigationStrategy
    {
        [NotNull]
        public ForwardNavigationDelegate Combine([CanBeNull] params ForwardNavigationDelegate[] navigationStrategies)
        {
            return (navigationController, toView, animated) =>
            {
                if (navigationStrategies != null)
                {
                    foreach (var navigationStrategy in navigationStrategies)
                    {
                        navigationStrategy(navigationController, toView, animated);
                    }
                }
            };
        }

        [NotNull]
        public ForwardNavigationDelegate Default()
        {
            return (navigationController, toView, animated) =>
            {
                if (toView is UINavigationController)
                {
                    navigationController.NotNull().PresentViewController(toView.NotNull(), animated, null);
                }
                else
                {
                    navigationController.NotNull().PushViewController(toView.NotNull(), animated);
                }
            };
        }

        [NotNull]
        public ForwardNavigationDelegate Push()
        {
            return (navigationController, toView, animated) =>
            {
                navigationController.NotNull().PushViewController(toView.NotNull(), animated);
            };
        }

        [NotNull]
        public ForwardNavigationDelegate Present([CanBeNull] Action completionHandler)
        {
            return (navigationController, toView, animated) =>
            {
                navigationController.NotNull().PresentViewController(toView.NotNull(), animated, completionHandler);
            };
        }

        [NotNull]
        public ForwardNavigationDelegate SetViewControllers()
        {
            return (navigationController, toView, animated) =>
            {
                navigationController.NotNull().SetViewControllers(new[] { toView.NotNull() }, animated);
            };
        }

        [NotNull]
        public ForwardNavigationDelegate SetViewControllers([CanBeNull] UIViewController[] viewControllers)
        {
            return (navigationController, toView, animated) =>
            {
                navigationController.NotNull().SetViewControllers(viewControllers, animated);
            };
        }
    }
}
