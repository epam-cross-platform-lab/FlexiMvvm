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
using CoreGraphics;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public static class UIColorExtensions
    {
        [NotNull]
        public static UIImage ToImage([NotNull] this UIColor color)
        {
            if (color == null)
                throw new ArgumentNullException(nameof(color));

            var rectangle = new CGRect(0, 0, 1, 1);
            UIGraphics.BeginImageContext(rectangle.Size);
            var context = UIGraphics.GetCurrentContext();
            context.SetFillColor(color.CGColor);
            context.FillRect(rectangle);
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }
    }
}
