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

using System.Diagnostics.CodeAnalysis;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using UIKit;

namespace FlexiMvvm.Views
{
    [SuppressMessage("ReSharper", "NotNullMemberIsNotInitialized", Justification = "SetupSubviews is called within constuctor.")]
    public class ScrollableLayoutView : LayoutView
    {
        public ScrollableLayoutView()
        {
        }

        public ScrollableLayoutView(CGRect frame)
            : base(frame)
        {
        }

        [JetBrains.Annotations.NotNull]
        public UIScrollView ScrollView { get; private set; }

        [JetBrains.Annotations.NotNull]
        public UIView ContentView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            ScrollView = new UIScrollView();
            ContentView = new UIView();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(ScrollView
                    .AddLayoutSubview(ContentView));
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ScrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

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
