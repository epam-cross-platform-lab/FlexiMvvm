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
    public class StylizedScrollableLayoutView<TTheme> : LayoutViewBase
    {
        public StylizedScrollableLayoutView(TTheme theme)
        {
            Theme = theme;

            Initialize();
        }

        public StylizedScrollableLayoutView(TTheme theme, CGRect frame)
            : base(frame)
        {
            Theme = theme;

            Initialize();
        }

        public TTheme Theme { get; }

        public virtual UIScrollView ScrollView { get; } = new UIScrollView();

        protected override void SetupLayout()
        {
            SetupLayoutAsScrollable(ScrollView);
        }

        protected override void SetupLayoutConstraints()
        {
            AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this);

            SetupLayoutConstraintsAsScrollable(ScrollView);
        }
    }

    public class StyledScrollableLayoutView<TTheme, TParameters> : LayoutViewBase<TParameters>
    {
        public StyledScrollableLayoutView(TTheme theme, TParameters parameters)
            : base(parameters)
        {
            Theme = theme;

            Initialize();
        }

        public StyledScrollableLayoutView(TTheme theme, TParameters parameters, CGRect frame)
            : base(parameters, frame)
        {
            Theme = theme;

            Initialize();
        }

        public TTheme Theme { get; }

        public virtual UIScrollView ScrollView { get; } = new UIScrollView();

        protected override void SetupLayout()
        {
            SetupLayoutAsScrollable(ScrollView);
        }

        protected override void SetupLayoutConstraints()
        {
            AllSubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this);

            SetupLayoutConstraintsAsScrollable(ScrollView);
        }
    }
}
