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
    public class LayoutView : UIView
    {
        private UIView? _contentView;

        public LayoutView()
        {
            Initialize(null);
        }

        public LayoutView(IDictionary<string, object?> layoutConfig)
        {
            if (layoutConfig == null)
                throw new ArgumentNullException(nameof(layoutConfig));

            Initialize(layoutConfig);
        }

        public LayoutView(CGRect frame)
            : base(frame)
        {
            Initialize(null);
        }

        public LayoutView(CGRect frame, IDictionary<string, object?> layoutConfig)
            : base(frame)
        {
            if (layoutConfig == null)
                throw new ArgumentNullException(nameof(layoutConfig));

            Initialize(layoutConfig);
        }

        protected IDictionary<string, object?>? LayoutConfig { get; private set; }

        public UIView ContentView => _contentView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.Always };

        private void Initialize(IDictionary<string, object?>? layoutConfig)
        {
            LayoutConfig = layoutConfig;

            SetupSubviews();
            SetupSubviewsConstraints();
            SetupLayout();
            SetupLayoutConstraints();
        }

        protected virtual void SetupSubviews()
        {
        }

        protected virtual void SetupSubviewsConstraints()
        {
        }

        protected virtual void SetupLayout()
        {
            this
                .AddLayoutSubview(ContentView);
        }

        protected virtual void SetupLayoutConstraints()
        {
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ContentView.FullSizeOf(this));
        }
    }
}
