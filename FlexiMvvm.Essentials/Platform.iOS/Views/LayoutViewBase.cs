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
using System.Linq;
using CoreGraphics;
using UIKit;

namespace FlexiMvvm.Views
{
    public abstract class LayoutViewBase : UIView
    {
        private IList<NSLayoutConstraint>? _regularWidthConstraints;
        private IList<NSLayoutConstraint>? _regularHeightConstraints;
        private IList<NSLayoutConstraint>? _compatWidthConstraints;
        private IList<NSLayoutConstraint>? _compatHeightConstraints;

        protected LayoutViewBase()
        {
        }

        protected LayoutViewBase(CGRect frame)
            : base(frame)
        {
        }

        public virtual UIView ContentView { get; } = new LayoutSubview(LayoutSubviewEventCapturing.Always);

        public virtual UIView ContentOverlayView { get; } = new LayoutSubview(LayoutSubviewEventCapturing.Newer);

        public IList<NSLayoutConstraint> RegularWidthConstraints => _regularWidthConstraints ??= new List<NSLayoutConstraint>();

        public IList<NSLayoutConstraint> RegularHeightConstraints => _regularHeightConstraints ??= new List<NSLayoutConstraint>();

        public IList<NSLayoutConstraint> CompatWidthConstraints => _compatWidthConstraints ??= new List<NSLayoutConstraint>();

        public IList<NSLayoutConstraint> CompatHeightConstraints => _compatHeightConstraints ??= new List<NSLayoutConstraint>();

        private protected void Initialize()
        {
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

        protected abstract void SetupLayout();

        private protected void SetupLayoutAsNonScrollable()
        {
            this
                .AddLayoutSubview(ContentView)
                .AddLayoutSubview(ContentOverlayView);
        }

        private protected void SetupLayoutAsScrollable(UIScrollView scrollView)
        {
            this
                .AddLayoutSubview(scrollView
                    .AddLayoutSubview(ContentView))
                .AddLayoutSubview(ContentOverlayView);
        }

        protected abstract void SetupLayoutConstraints();

        private protected void SetupLayoutConstraintsAsNonScrollable()
        {
            ContentView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewLeadingConstraint).SetActive(true);
            ContentView.TopAnchor.ConstraintEqualTo(TopAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewTopConstraint).SetActive(true);
            ContentView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewTrailingConstraint).SetActive(true);
            ContentView.BottomAnchor.ConstraintEqualTo(BottomAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewBottomConstraint).SetActive(true);

            ContentOverlayView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewLeadingConstraint).SetActive(true);
            ContentOverlayView.TopAnchor.ConstraintEqualTo(TopAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewTopConstraint).SetActive(true);
            ContentOverlayView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewTrailingConstraint).SetActive(true);
            ContentOverlayView.BottomAnchor.ConstraintEqualTo(BottomAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewBottomConstraint).SetActive(true);
        }

        private protected void SetupLayoutConstraintsAsScrollable(UIScrollView scrollView)
        {
            scrollView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ScrollViewLeadingConstraint).SetActive(true);
            scrollView.TopAnchor.ConstraintEqualTo(TopAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ScrollViewTopConstraint).SetActive(true);
            scrollView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ScrollViewTrailingConstraint).SetActive(true);
            scrollView.BottomAnchor.ConstraintEqualTo(BottomAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ScrollViewBottomConstraint).SetActive(true);

            ContentView.LeadingAnchor.ConstraintEqualTo(scrollView.LeadingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewLeadingConstraint).SetActive(true);
            ContentView.TopAnchor.ConstraintEqualTo(scrollView.TopAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewTopConstraint).SetActive(true);
            ContentView.TrailingAnchor.ConstraintEqualTo(scrollView.TrailingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewTrailingConstraint).SetActive(true);
            ContentView.BottomAnchor.ConstraintEqualTo(scrollView.BottomAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewBottomConstraint).SetActive(true);
            ContentView.WidthAnchor.ConstraintEqualTo(WidthAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentViewWidthConstraint).SetActive(true);

            ContentOverlayView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewLeadingConstraint).SetActive(true);
            ContentOverlayView.TopAnchor.ConstraintEqualTo(TopAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewTopConstraint).SetActive(true);
            ContentOverlayView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewTrailingConstraint).SetActive(true);
            ContentOverlayView.BottomAnchor.ConstraintEqualTo(BottomAnchor).WithIdentifier(LayoutViewConstraintIdentifier.ContentOverlayViewBottomConstraint).SetActive(true);
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

            if (TraitCollection.VerticalSizeClass == UIUserInterfaceSizeClass.Regular)
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

        protected virtual void AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(UIView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            foreach (var subview in view.Subviews)
            {
                if (subview.AutoresizingMask == UIViewAutoresizing.None)
                {
                    subview.TranslatesAutoresizingMaskIntoConstraints = false;
                }

                if (!(subview is LayoutViewBase))
                {
                    AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(subview);
                }
            }
        }
    }

    public abstract class LayoutViewBase<TParameters> : LayoutViewBase
    {
        protected LayoutViewBase(TParameters parameters)
        {
            Parameters = parameters;
        }

        protected LayoutViewBase(TParameters parameters, CGRect frame)
            : base(frame)
        {
            Parameters = parameters;
        }

        protected TParameters Parameters { get; }
    }
}
