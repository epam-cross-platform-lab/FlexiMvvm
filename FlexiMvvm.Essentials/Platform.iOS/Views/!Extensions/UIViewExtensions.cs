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
using UIKit;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides a set of static methods for the <see cref="UIViewExtensions"/>.
    /// </summary>
    public static class UIViewExtensions
    {
        /// <summary>
        /// Adds the <paramref name="childView"/> to the <paramref name="parentView"/>.
        /// </summary>
        /// <param name="parentView">The parent view.</param>
        /// <param name="childView">The child view.</param>
        /// <returns>The parent view instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parentView"/> or <paramref name="childView"/> is <c>null</c>.</exception>
        public static UIView AddLayoutSubview(this UIView parentView, UIView childView)
        {
            if (parentView == null)
                throw new ArgumentNullException(nameof(parentView));
            if (childView == null)
                throw new ArgumentNullException(nameof(childView));

            parentView.AddSubview(childView);

            return parentView;
        }

        public static UIView AddLayoutSubviewIf(this UIView parentView, bool condition, UIView childView)
        {
            if (parentView == null)
                throw new ArgumentNullException(nameof(parentView));

            if (condition)
            {
                if (childView == null)
                    throw new ArgumentNullException(nameof(childView));

                parentView.AddSubview(childView);
            }

            return parentView;
        }

        internal static Tuple<UIView, UIScrollView>? FindFirstResponderInScrollView(this UIView rootView)
        {
            return FindFirstResponderInScrollView(rootView, null);
        }

        private static Tuple<UIView, UIScrollView>? FindFirstResponderInScrollView(UIView view, UIScrollView? scrollView)
        {
            if (view is UIScrollView uiScrollView)
            {
                scrollView = uiScrollView;
            }

            if (view.IsFirstResponder)
            {
                return scrollView != null ? new Tuple<UIView, UIScrollView>(view, scrollView) : null;
            }

            if (view.Subviews != null)
            {
                foreach (var subview in view.Subviews)
                {
                    var firstResponderInScrollView = FindFirstResponderInScrollView(subview, scrollView);

                    if (firstResponderInScrollView != null)
                    {
                        return firstResponderInScrollView;
                    }
                }
            }

            return null;
        }
    }
}
