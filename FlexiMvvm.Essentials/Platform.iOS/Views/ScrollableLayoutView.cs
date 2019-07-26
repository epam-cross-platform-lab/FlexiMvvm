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
using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using UIKit;

namespace FlexiMvvm.Views
{
    [Obsolete("ScrollableLayoutView will be removed soon. Use RootScrollableLayoutView class instead.")]
    public class ScrollableLayoutView : LayoutView
    {
        private UIScrollView? _scrollView;

        public ScrollableLayoutView()
        {
        }

        public ScrollableLayoutView(IDictionary<string, object?> layoutConfig)
            : base(layoutConfig)
        {
        }

        public ScrollableLayoutView(CGRect frame)
            : base(frame)
        {
        }

        public ScrollableLayoutView(CGRect frame, IDictionary<string, object?> layoutConfig)
            : base(frame, layoutConfig)
        {
        }

        public UIScrollView ScrollView => _scrollView ??= new UIScrollView();

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this
                .AddLayoutSubview(ScrollView
                    .AddLayoutSubview(ContentView));
        }

        protected override void SetupLayoutConstraints()
        {
            AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this, false);

            this.AddConstraints(
                ScrollView.FullSizeOf(this));

            ScrollView.AddConstraints(
                ContentView.FullSizeOf(ScrollView));

            this.AddConstraints(
                ContentView.WithSameWidth(this),
                ContentView.WithSameHeight(this).NotNull().SetPriority(UILayoutPriority.DefaultLow));
        }
    }
}
