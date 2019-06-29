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
    internal class LayoutSubview : UIView
    {
        internal LayoutSubviewEventCapturing EventCapturing { get; set; }

        public override UIView? HitTest(CGPoint point, UIEvent uievent)
        {
            var result = base.HitTest(point, uievent);

            switch (EventCapturing)
            {
                case LayoutSubviewEventCapturing.WhenHasSubviews:
                    return Equals(result) && Subviews.Length == 0 ? null : result;
                case LayoutSubviewEventCapturing.Newer:
                    return Equals(result) ? null : result;
                default:
                    return result;
            }
        }
    }
}
