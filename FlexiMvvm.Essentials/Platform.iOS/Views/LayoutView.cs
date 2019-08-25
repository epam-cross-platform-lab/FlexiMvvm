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
using System.Collections.ObjectModel;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace FlexiMvvm.Views
{
    public class LayoutView : UIView
    {
        private UIView? _contentView;
        private UIView? _contentOverlayView;
        private ICollection<NSLayoutConstraint>? _regularWidthConstraints;
        private ICollection<NSLayoutConstraint>? _regularHeightConstraints;
        private ICollection<NSLayoutConstraint>? _compatWidthConstraints;
        private ICollection<NSLayoutConstraint>? _compatHeightConstraints;

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

        public virtual UIView ContentView => _contentView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.Always };

        public virtual UIView ContentOverlayView => _contentOverlayView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.Newer };

        public ICollection<NSLayoutConstraint> RegularWidthConstraints => _regularWidthConstraints ??= new Collection<NSLayoutConstraint>();

        public ICollection<NSLayoutConstraint> RegularHeightConstraints => _regularHeightConstraints ??= new Collection<NSLayoutConstraint>();

        public ICollection<NSLayoutConstraint> CompatWidthConstraints => _compatWidthConstraints ??= new Collection<NSLayoutConstraint>();

        public ICollection<NSLayoutConstraint> CompatHeightConstraints => _compatHeightConstraints ??= new Collection<NSLayoutConstraint>();

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
                .AddLayoutSubview(ContentView)
                .AddLayoutSubview(ContentOverlayView);
        }

        protected virtual void SetupLayoutConstraints()
        {
            AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this, false);

            ContentView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).SetActive(true);
            ContentView.TopAnchor.ConstraintEqualTo(TopAnchor).SetActive(true);
            ContentView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).SetActive(true);
            ContentView.BottomAnchor.ConstraintEqualTo(BottomAnchor).SetActive(true);

            ContentOverlayView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).SetActive(true);
            ContentOverlayView.TopAnchor.ConstraintEqualTo(TopAnchor).SetActive(true);
            ContentOverlayView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).SetActive(true);
            ContentOverlayView.BottomAnchor.ConstraintEqualTo(BottomAnchor).SetActive(true);
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            base.TraitCollectionDidChange(previousTraitCollection);

            if (TraitCollection.HorizontalSizeClass == UIUserInterfaceSizeClass.Regular)
            {
                if (_compatWidthConstraints != null)
                {
                    NSLayoutConstraint.DeactivateConstraints(_compatWidthConstraints.ToArray());
                }

                if (_regularWidthConstraints != null)
                {
                    NSLayoutConstraint.ActivateConstraints(_regularWidthConstraints.ToArray());
                }
            }
            else if (TraitCollection.HorizontalSizeClass == UIUserInterfaceSizeClass.Compact)
            {
                if (_regularWidthConstraints != null)
                {
                    NSLayoutConstraint.DeactivateConstraints(_regularWidthConstraints.ToArray());
                }

                if (_compatWidthConstraints != null)
                {
                    NSLayoutConstraint.ActivateConstraints(_compatWidthConstraints.ToArray());
                }
            }
            else if (TraitCollection.VerticalSizeClass == UIUserInterfaceSizeClass.Regular)
            {
                if (_compatHeightConstraints != null)
                {
                    NSLayoutConstraint.DeactivateConstraints(_compatHeightConstraints.ToArray());
                }

                if (_regularHeightConstraints != null)
                {
                    NSLayoutConstraint.ActivateConstraints(_regularHeightConstraints.ToArray());
                }
            }
            else if (TraitCollection.VerticalSizeClass == UIUserInterfaceSizeClass.Compact)
            {
                if (_regularHeightConstraints != null)
                {
                    NSLayoutConstraint.DeactivateConstraints(_regularHeightConstraints.ToArray());
                }

                if (_compatHeightConstraints != null)
                {
                    NSLayoutConstraint.ActivateConstraints(_compatHeightConstraints.ToArray());
                }
            }
        }

        protected virtual void AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(UIView view, bool includePassedView = true)
        {
            if (includePassedView && view.AutoresizingMask == UIViewAutoresizing.None)
            {
                view.TranslatesAutoresizingMaskIntoConstraints = false;
            }

            foreach (var subview in view.Subviews)
            {
                AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(subview);
            }
        }
    }
}
