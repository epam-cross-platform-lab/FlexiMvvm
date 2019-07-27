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

using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace FlexiMvvm.Views
{
    public class RootScrollableLayoutView : RootLayoutView
    {
        private UIScrollView? _scrollView;

        public RootScrollableLayoutView()
        {
        }

        public RootScrollableLayoutView(IDictionary<string, object?> layoutConfig)
            : base(layoutConfig)
        {
        }

        public RootScrollableLayoutView(CGRect frame)
            : base(frame)
        {
        }

        public RootScrollableLayoutView(CGRect frame, IDictionary<string, object?> layoutConfig)
            : base(frame, layoutConfig)
        {
        }

        public UIScrollView ScrollView => _scrollView ??= new UIScrollView();

        protected override void SetupLayout()
        {
            this
                .AddLayoutSubview(ScrollView
                    .AddLayoutSubview(ContentView
                        .AddLayoutSubview(SafeAreaContentView)))
                .AddLayoutSubview(ContentOverlayView
                    .AddLayoutSubview(SafeAreaContentOverlayView));
        }

        protected override void SetupLayoutConstraints()
        {
            AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this, false);

            ScrollView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).SetActive(true);
            ScrollView.TopAnchor.ConstraintEqualTo(TopAnchor).SetActive(true);
            ScrollView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).SetActive(true);
            ScrollView.BottomAnchor.ConstraintEqualTo(BottomAnchor).SetActive(true);

            ContentView.LeadingAnchor.ConstraintEqualTo(ScrollView.LeadingAnchor).SetActive(true);
            ContentView.TopAnchor.ConstraintEqualTo(ScrollView.TopAnchor).SetActive(true);
            ContentView.TrailingAnchor.ConstraintEqualTo(ScrollView.TrailingAnchor).SetActive(true);
            ContentView.BottomAnchor.ConstraintEqualTo(ScrollView.BottomAnchor).SetActive(true);

            ContentView.WidthAnchor.ConstraintEqualTo(WidthAnchor).SetActive(true);
            ContentView.HeightAnchor.ConstraintEqualTo(HeightAnchor).SetPriority(UILayoutPriority.DefaultLow).SetActive(true);

            SafeAreaContentView.LeadingAnchor.ConstraintEqualTo(ContentView.SafeAreaLayoutGuide.LeadingAnchor).SetActive(true);
            SafeAreaContentViewTopConstraint.SetActive(true);
            SafeAreaContentView.TrailingAnchor.ConstraintEqualTo(ContentView.SafeAreaLayoutGuide.TrailingAnchor).SetActive(true);
            SafeAreaContentViewBottomConstraint.SetActive(true);

            ContentOverlayView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).SetActive(true);
            ContentOverlayView.TopAnchor.ConstraintEqualTo(TopAnchor).SetActive(true);
            ContentOverlayView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).SetActive(true);
            ContentOverlayView.BottomAnchor.ConstraintEqualTo(BottomAnchor).SetActive(true);

            SafeAreaContentOverlayView.LeadingAnchor.ConstraintEqualTo(ContentOverlayView.SafeAreaLayoutGuide.LeadingAnchor).SetActive(true);
            SafeAreaContentOverlayViewTopConstraint.SetActive(true);
            SafeAreaContentOverlayView.TrailingAnchor.ConstraintEqualTo(ContentOverlayView.SafeAreaLayoutGuide.TrailingAnchor).SetActive(true);
            SafeAreaContentOverlayViewBottomConstraint.SetActive(true);
        }
    }
}
