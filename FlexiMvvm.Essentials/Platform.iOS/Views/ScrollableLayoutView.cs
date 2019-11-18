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

using CoreGraphics;
using UIKit;

namespace FlexiMvvm.Views
{
    public class ScrollableLayoutView : LayoutView
    {
        private UIScrollView? _scrollView;
        private NSLayoutConstraint? _contentViewWidthConstraint;
        private NSLayoutConstraint? _contentViewHeightConstraint;

        public ScrollableLayoutView()
        {
        }

        public ScrollableLayoutView(LayoutViewConfig config)
            : base(config)
        {
        }

        public ScrollableLayoutView(CGRect frame)
            : base(frame)
        {
        }

        public ScrollableLayoutView(CGRect frame, LayoutViewConfig config)
            : base(frame, config)
        {
        }

        public virtual UIScrollView ScrollView => _scrollView ??= new UIScrollView();

        public virtual NSLayoutConstraint ContentViewWidthConstraint
        {
            get
            {
                return _contentViewWidthConstraint ??= ContentView.WidthAnchor.ConstraintEqualTo(WidthAnchor);
            }
        }

        public virtual NSLayoutConstraint ContentViewHeightConstraint
        {
            get
            {
                return _contentViewHeightConstraint ??= UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                    ? ContentView.HeightAnchor.ConstraintEqualTo(SafeAreaLayoutGuide.HeightAnchor).SetPriority(UILayoutPriority.DefaultLow)
                    : ContentView.HeightAnchor.ConstraintEqualTo(HeightAnchor).SetPriority(UILayoutPriority.DefaultLow);
            }
        }

        protected override void SetupLayout()
        {
            this
                .AddLayoutSubview(ScrollView
                    .AddLayoutSubview(ContentView))
                .AddLayoutSubview(ContentOverlayView);
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

            ContentViewWidthConstraint.SetActive(true);
            ContentViewHeightConstraint.SetActive(true);

            ContentOverlayView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).SetActive(true);
            ContentOverlayView.TopAnchor.ConstraintEqualTo(TopAnchor).SetActive(true);
            ContentOverlayView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).SetActive(true);
            ContentOverlayView.BottomAnchor.ConstraintEqualTo(BottomAnchor).SetActive(true);
        }
    }

    public class ScrollableLayoutView<TTheme> : ScrollableLayoutView
    {
        public ScrollableLayoutView(LayoutViewConfig<TTheme> config)
            : base(config)
        {
        }

        public ScrollableLayoutView(CGRect frame, LayoutViewConfig<TTheme> config)
            : base(frame, config)
        {
        }

        public TTheme Theme => Config.GetTheme<TTheme>();
    }
}
