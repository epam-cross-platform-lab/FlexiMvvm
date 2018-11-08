// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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

using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core
{
    internal static class BindingModeExtensions
    {
        private const int NotCompatible = -1;

        [NotNull]
        private static readonly int[,] BindingCompatibilityMatrix =
        {
            /*                      | Two-Way                         | One-Way                  | One-Way-To-Source               | One-Time                 */
            /*  Two-Way           */{ (int)BindingMode.TwoWay,          (int)BindingMode.OneWay,   (int)BindingMode.OneWayToSource,  (int)BindingMode.OneTime },
            /*  One-Way           */{ (int)BindingMode.OneWay,          (int)BindingMode.OneWay,   NotCompatible,                    (int)BindingMode.OneTime },
            /*  One-Way-To-Source */{ (int)BindingMode.OneWayToSource,  NotCompatible,             (int)BindingMode.OneWayToSource,  NotCompatible },
            /*  One-Time          */{ (int)BindingMode.OneTime,         (int)BindingMode.OneTime,  NotCompatible,                    (int)BindingMode.OneTime }
        };

        internal static bool TryCombineWith(
            this BindingMode sourceItemBindingMode,
            BindingMode targetItemBindingMode,
            out BindingMode compositeItemBindingMode)
        {
            compositeItemBindingMode = sourceItemBindingMode;
            var finalBindingMode = BindingCompatibilityMatrix[(int)sourceItemBindingMode, (int)targetItemBindingMode];

            if (finalBindingMode != NotCompatible)
            {
                compositeItemBindingMode = (BindingMode)finalBindingMode;

                return true;
            }

            return false;
        }

        internal static bool IsFromSourceToTarget(this BindingMode sourceItemBindingMode)
        {
            return sourceItemBindingMode == BindingMode.OneWay || sourceItemBindingMode == BindingMode.TwoWay || sourceItemBindingMode == BindingMode.OneTime;
        }

        internal static bool IsFromTargetToSource(this BindingMode targetItemBindingMode)
        {
            return targetItemBindingMode == BindingMode.OneWayToSource || targetItemBindingMode == BindingMode.TwoWay;
        }
    }
}
