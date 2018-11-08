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

using FlexiMvvm.ViewModels;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public static class ViewExtensions
    {
        [CanBeNull]
        public static UINavigationController GetNavigationController([NotNull] this IIosView view)
        {
            if (view == null)
                throw new System.ArgumentNullException(nameof(view));

            UINavigationController parentNavigationControllerOrSelf = null;

            if (view is UINavigationController navigationController)
            {
                parentNavigationControllerOrSelf = navigationController;
            }
            else if (view is UIViewController viewController)
            {
                parentNavigationControllerOrSelf = viewController.NavigationController;
            }

            return parentNavigationControllerOrSelf;
        }

        [CanBeNull]
        internal static IIosView<IViewModel> FindParentViewWithModel([NotNull] this UIViewController parent)
        {
            IIosView<IViewModel> parentView = null;
            var parentViewController = parent;

            while (parentView == null && parentViewController != null)
            {
                parentView = parentViewController as IIosView<IViewModel>;
                parentViewController = parentViewController.ParentViewController;
            }

            return parentView;
        }
    }
}
