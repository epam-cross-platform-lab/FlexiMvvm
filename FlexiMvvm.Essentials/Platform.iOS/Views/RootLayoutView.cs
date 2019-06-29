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
    public class RootLayoutView : LayoutView
    {
        private UIView? _safeAreaContentView;
        private UIView? _contentOverlayView;
        private UIView? _safeAreaContentOverlayView;
        private FluentLayout? _safeAreaContentViewLeftConstraint;
        private FluentLayout? _safeAreaContentViewTopConstraint;
        private FluentLayout? _safeAreaContentViewRightConstraint;
        private FluentLayout? _safeAreaContentViewBottomConstraint;
        private FluentLayout? _safeAreaContentOverlayViewLeftConstraint;
        private FluentLayout? _safeAreaContentOverlayViewTopConstraint;
        private FluentLayout? _safeAreaContentOverlayViewRightConstraint;
        private FluentLayout? _safeAreaContentOverlayViewBottomConstraint;

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

        public FluentLayout SafeAreaContentViewLeftConstraint => _safeAreaContentViewLeftConstraint ??= SafeAreaContentView.AtLeftOfSafeArea(ContentView);

        public FluentLayout SafeAreaContentViewTopConstraint => _safeAreaContentViewTopConstraint ??= SafeAreaContentView.AtTopOfSafeArea(ContentView);

        public FluentLayout SafeAreaContentViewRightConstraint => _safeAreaContentViewRightConstraint ??= SafeAreaContentView.AtRightOfSafeArea(ContentView);

        public FluentLayout SafeAreaContentViewBottomConstraint => _safeAreaContentViewBottomConstraint ??= SafeAreaContentView.AtBottomOfSafeArea(ContentView);

        public FluentLayout SafeAreaContentOverlayViewLeftConstraint => _safeAreaContentOverlayViewLeftConstraint ??= SafeAreaContentOverlayView.AtLeftOfSafeArea(ContentOverlayView);

        public FluentLayout SafeAreaContentOverlayViewTopConstraint => _safeAreaContentOverlayViewTopConstraint ??= SafeAreaContentOverlayView.AtTopOfSafeArea(ContentOverlayView);

        public FluentLayout SafeAreaContentOverlayViewRightConstraint => _safeAreaContentOverlayViewRightConstraint ??= SafeAreaContentOverlayView.AtRightOfSafeArea(ContentOverlayView);

        public FluentLayout SafeAreaContentOverlayViewBottomConstraint => _safeAreaContentOverlayViewBottomConstraint ??= SafeAreaContentOverlayView.AtBottomOfSafeArea(ContentOverlayView);

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
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            SafeAreaContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentOverlayView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            SafeAreaContentOverlayView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ContentView.FullSizeOf(this));

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
