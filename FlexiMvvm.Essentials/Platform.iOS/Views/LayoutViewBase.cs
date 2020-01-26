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
    public abstract class LayoutViewBase : UIView
    {
        private UIView? _contentView;
        private UIView? _contentOverlayView;
        private ICollection<NSLayoutConstraint>? _regularWidthConstraints;
        private ICollection<NSLayoutConstraint>? _regularHeightConstraints;
        private ICollection<NSLayoutConstraint>? _compatWidthConstraints;
        private ICollection<NSLayoutConstraint>? _compatHeightConstraints;

        protected LayoutViewBase()
        {
        }

        protected LayoutViewBase(CGRect frame)
            : base(frame)
        {
        }

        public virtual UIView ContentView => _contentView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.Always };

        public virtual UIView ContentOverlayView => _contentOverlayView ??= new LayoutSubview { EventCapturing = LayoutSubviewEventCapturing.Newer };

        public ICollection<NSLayoutConstraint> RegularWidthConstraints => _regularWidthConstraints ??= new Collection<NSLayoutConstraint>();

        public ICollection<NSLayoutConstraint> RegularHeightConstraints => _regularHeightConstraints ??= new Collection<NSLayoutConstraint>();

        public ICollection<NSLayoutConstraint> CompatWidthConstraints => _compatWidthConstraints ??= new Collection<NSLayoutConstraint>();

        public ICollection<NSLayoutConstraint> CompatHeightConstraints => _compatHeightConstraints ??= new Collection<NSLayoutConstraint>();

        protected void Initialize()
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

        protected abstract void SetupLayoutConstraints();

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

    public abstract class LayoutViewBase<TConfig> : LayoutViewBase
    {
        protected LayoutViewBase(TConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        protected LayoutViewBase(TConfig config, CGRect frame)
            : base(frame)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        protected TConfig Config { get; }
    }
}
