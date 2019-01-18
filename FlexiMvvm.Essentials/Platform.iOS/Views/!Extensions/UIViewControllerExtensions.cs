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
using Cirrious.FluentLayouts.Touch;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public static class UIViewControllerExtensions
    {
        public static void AddChildViewControllerAndView(
            [NotNull] this UIViewController parentViewController,
            [CanBeNull] UIViewController childViewController,
            [NotNull] UIView parentView)
        {
            if (parentViewController == null)
                throw new ArgumentNullException(nameof(parentViewController));
            if (parentView == null)
                throw new ArgumentNullException(nameof(parentView));

            if (childViewController != null)
            {
                parentViewController.AddChildViewController(childViewController);
                childViewController.View.NotNull().Frame = parentView.Bounds;
                parentView.AddSubview(childViewController.View);
                parentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
                parentView.AddConstraints(childViewController.View.FullSizeOf(parentView));
                childViewController.DidMoveToParentViewController(parentViewController);
            }
        }

        public static void RemoveFromParentViewControllerAndView(
            [CanBeNull] this UIViewController childViewController)
        {
            if (childViewController != null)
            {
                childViewController.WillMoveToParentViewController(null);
                childViewController.View.NotNull().RemoveFromSuperview();
                childViewController.RemoveFromParentViewController();
            }
        }
    }
}
