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
using FlexiMvvm.Views;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Navigation.Generic
{
    public delegate void BackwardNavigationDelegate(UINavigationController navigationController, IIosView fromView, bool animated);

    public class BackwardNavigationStrategy
    {
        [NotNull]
        public BackwardNavigationDelegate Combine([CanBeNull] params BackwardNavigationDelegate[] navigationStrategies)
        {
            return (navigationController, fromView, animated) =>
            {
                if (navigationStrategies != null)
                {
                    foreach (var navigationStrategy in navigationStrategies)
                    {
                        navigationStrategy(navigationController, fromView, animated);
                    }
                }
            };
        }

        [NotNull]
        public BackwardNavigationDelegate Default()
        {
            return (navigationController, fromView, animated) =>
            {
                if (fromView.NotNull().IsBeingPresented)
                {
                    fromView.DismissViewController(animated, null);
                }
                else
                {
                    navigationController.NotNull().PopViewController(animated);
                }
            };
        }

        [NotNull]
        public BackwardNavigationDelegate PopViewController()
        {
            return (navigationController, fromView, animated) =>
            {
                navigationController.NotNull().PopViewController(animated);
            };
        }

        [NotNull]
        public BackwardNavigationDelegate PopToViewController([NotNull] UIViewController toView)
        {
            if (toView == null)
                throw new ArgumentNullException(nameof(toView));

            return (navigationController, fromView, animated) =>
            {
                navigationController.NotNull().PopToViewController(toView, animated);
            };
        }

        [NotNull]
        public BackwardNavigationDelegate PopToRootViewController()
        {
            return (navigationController, fromView, animated) =>
            {
                navigationController.NotNull().PopToRootViewController(animated);
            };
        }
    }
}
