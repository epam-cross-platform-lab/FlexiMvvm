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
using Cirrious.FluentLayouts.Touch;
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
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ScrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            SafeAreaContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentOverlayView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            SafeAreaContentOverlayView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ScrollView.FullSizeOf(this));

            ScrollView.AddConstraints(
                ContentView.FullSizeOf(ScrollView));

            this.AddConstraints(
                ContentView.WithSameWidth(this),
                ContentView.WithSameHeight(this).SetPriority(UILayoutPriority.DefaultLow));

            ContentView.AddConstraints(
                SafeAreaContentViewLeftConstraint,
                SafeAreaContentViewTopConstraint,
                SafeAreaContentViewRightConstraint,
                SafeAreaContentViewBottomConstraint);

            this.AddConstraints(
                ContentOverlayView.FullSizeOf(this));

            ContentOverlayView.AddConstraints(
                SafeAreaContentOverlayViewLeftConstraint,
                SafeAreaContentOverlayViewTopConstraint,
                SafeAreaContentOverlayViewRightConstraint,
                SafeAreaContentOverlayViewBottomConstraint);
        }
    }
}
