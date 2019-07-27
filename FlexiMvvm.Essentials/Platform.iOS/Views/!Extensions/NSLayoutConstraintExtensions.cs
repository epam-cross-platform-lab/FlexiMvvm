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
using UIKit;

namespace FlexiMvvm.Views
{
    public static class NSLayoutConstraintExtensions
    {
        public static NSLayoutConstraint SetActive(this NSLayoutConstraint constraint, bool active)
        {
            if (constraint == null)
                throw new ArgumentNullException(nameof(constraint));

            constraint.Active = active;

            return constraint;
        }

        public static NSLayoutConstraint SetPriority(this NSLayoutConstraint constraint, UILayoutPriority priority)
        {
            if (constraint == null)
                throw new ArgumentNullException(nameof(constraint));

            return SetPriority(constraint, (float)priority);
        }

        public static NSLayoutConstraint SetPriority(this NSLayoutConstraint constraint, float priority)
        {
            if (constraint == null)
                throw new ArgumentNullException(nameof(constraint));

            constraint.Priority = priority;

            return constraint;
        }

        public static NSLayoutConstraint AsSizeClassConstraint(this NSLayoutConstraint constraint, ICollection<NSLayoutConstraint> sizeClassConstraints)
        {
            if (constraint == null)
                throw new ArgumentNullException(nameof(constraint));
            if (sizeClassConstraints == null)
                throw new ArgumentNullException(nameof(sizeClassConstraints));

            sizeClassConstraints.Add(constraint);

            return constraint;
        }
    }
}
