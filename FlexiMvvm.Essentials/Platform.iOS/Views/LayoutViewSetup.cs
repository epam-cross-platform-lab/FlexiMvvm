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

using UIKit;

namespace FlexiMvvm.Views
{
    internal static class LayoutViewSetup
    {
        internal static void SetupNonScrollableLayout(UIView rootView, UIView contentView, UIView contentOverlayView)
        {
            rootView
                .AddLayoutSubview(contentView)
                .AddLayoutSubview(contentOverlayView);
        }

        internal static void SetupNonScrollableLayoutConstraints(UIView rootView, UIView contentView, UIView contentOverlayView)
        {
            contentView.LeadingAnchor.ConstraintEqualTo(rootView.LeadingAnchor).SetActive(true);
            contentView.TopAnchor.ConstraintEqualTo(rootView.TopAnchor).SetActive(true);
            contentView.TrailingAnchor.ConstraintEqualTo(rootView.TrailingAnchor).SetActive(true);
            contentView.BottomAnchor.ConstraintEqualTo(rootView.BottomAnchor).SetActive(true);

            contentOverlayView.LeadingAnchor.ConstraintEqualTo(rootView.LeadingAnchor).SetActive(true);
            contentOverlayView.TopAnchor.ConstraintEqualTo(rootView.TopAnchor).SetActive(true);
            contentOverlayView.TrailingAnchor.ConstraintEqualTo(rootView.TrailingAnchor).SetActive(true);
            contentOverlayView.BottomAnchor.ConstraintEqualTo(rootView.BottomAnchor).SetActive(true);
        }

        internal static void SetupScrollableLayout(UIView rootView, UIScrollView scrollView, UIView contentView, UIView contentOverlayView)
        {
            rootView
                .AddLayoutSubview(scrollView
                    .AddLayoutSubview(contentView))
                .AddLayoutSubview(contentOverlayView);
        }

        internal static void SetupScrollableLayoutConstraints(UIView rootView, UIScrollView scrollView, UIView contentView, UIView contentOverlayView)
        {
            scrollView.LeadingAnchor.ConstraintEqualTo(rootView.LeadingAnchor).SetActive(true);
            scrollView.TopAnchor.ConstraintEqualTo(rootView.TopAnchor).SetActive(true);
            scrollView.TrailingAnchor.ConstraintEqualTo(rootView.TrailingAnchor).SetActive(true);
            scrollView.BottomAnchor.ConstraintEqualTo(rootView.BottomAnchor).SetActive(true);

            contentView.LeadingAnchor.ConstraintEqualTo(scrollView.LeadingAnchor).SetActive(true);
            contentView.TopAnchor.ConstraintEqualTo(scrollView.TopAnchor).SetActive(true);
            contentView.TrailingAnchor.ConstraintEqualTo(scrollView.TrailingAnchor).SetActive(true);
            contentView.BottomAnchor.ConstraintEqualTo(scrollView.BottomAnchor).SetActive(true);
            contentView.WidthAnchor.ConstraintEqualTo(rootView.WidthAnchor).SetActive(true);
            contentView.HeightAnchor.ConstraintEqualTo(rootView.HeightAnchor).SetPriority(UILayoutPriority.DefaultLow).SetActive(true);

            contentOverlayView.LeadingAnchor.ConstraintEqualTo(rootView.LeadingAnchor).SetActive(true);
            contentOverlayView.TopAnchor.ConstraintEqualTo(rootView.TopAnchor).SetActive(true);
            contentOverlayView.TrailingAnchor.ConstraintEqualTo(rootView.TrailingAnchor).SetActive(true);
            contentOverlayView.BottomAnchor.ConstraintEqualTo(rootView.BottomAnchor).SetActive(true);
        }
    }
}
