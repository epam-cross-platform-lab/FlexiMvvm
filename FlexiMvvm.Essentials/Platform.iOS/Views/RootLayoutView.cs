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
    public class RootLayoutView : LayoutView
    {
        private UIView? _safeAreaContentView;
        private UIView? _contentOverlayView;
        private UIView? _safeAreaContentOverlayView;
        private NSLayoutConstraint? _safeAreaContentViewTopConstraint;
        private NSLayoutConstraint? _safeAreaContentViewBottomConstraint;
        private NSLayoutConstraint? _safeAreaContentOverlayViewTopConstraint;
        private NSLayoutConstraint? _safeAreaContentOverlayViewBottomConstraint;

        public RootLayoutView()
        {
        }

        public RootLayoutView(IDictionary<string, object?> layoutConfig)
            : base(layoutConfig)
        {
        }

        public RootLayoutView(CGRect frame)
            : base(frame)
        {
        }

        public RootLayoutView(CGRect frame, IDictionary<string, object?> layoutConfig)
            : base(frame, layoutConfig)
        {
        }

        public UIView SafeAreaContentView => _safeAreaContentView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.WhenHasSubviews };

        public UIView ContentOverlayView => _contentOverlayView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.Newer };

        public UIView SafeAreaContentOverlayView => _safeAreaContentOverlayView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.Newer };

        public NSLayoutConstraint SafeAreaContentViewTopConstraint =>
            _safeAreaContentViewTopConstraint ??= SafeAreaContentView.TopAnchor.ConstraintEqualTo(ContentView.SafeAreaLayoutGuide.TopAnchor);

        public NSLayoutConstraint SafeAreaContentViewBottomConstraint =>
            _safeAreaContentViewBottomConstraint ??= SafeAreaContentView.BottomAnchor.ConstraintEqualTo(ContentView.SafeAreaLayoutGuide.BottomAnchor);

        public NSLayoutConstraint SafeAreaContentOverlayViewTopConstraint =>
            _safeAreaContentOverlayViewTopConstraint ??= SafeAreaContentOverlayView.TopAnchor.ConstraintEqualTo(ContentOverlayView.SafeAreaLayoutGuide.TopAnchor);

        public NSLayoutConstraint SafeAreaContentOverlayViewBottomConstraint =>
            _safeAreaContentOverlayViewBottomConstraint ??= SafeAreaContentOverlayView.BottomAnchor.ConstraintEqualTo(ContentOverlayView.SafeAreaLayoutGuide.BottomAnchor);

        protected override void SetupLayout()
        {
            this
                .AddLayoutSubview(ContentView
                    .AddLayoutSubview(SafeAreaContentView))
                .AddLayoutSubview(ContentOverlayView
                    .AddLayoutSubview(SafeAreaContentOverlayView));
        }

        protected override void SetupLayoutConstraints()
        {
            AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this, false);

            ContentView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).SetActive(true);
            ContentView.TopAnchor.ConstraintEqualTo(TopAnchor).SetActive(true);
            ContentView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).SetActive(true);
            ContentView.BottomAnchor.ConstraintEqualTo(BottomAnchor).SetActive(true);

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
