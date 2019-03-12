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
using FlexiMvvm.Bindings.Custom;
using UIKit;

namespace FlexiMvvm.Bindings
{
    /// <summary>
    /// Provides a set of static methods for creating bindings on <see cref="UIPickerView"/> members.
    /// </summary>
    public static class UIPickerViewExtensions
    {
        /// <summary>
        /// One way binding on <see cref="UIPickerView.ReloadComponent(nint)"/> method. Component index is passed as a value.
        /// </summary>
        /// <param name="pickerViewReference">The picker view reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pickerViewReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<UIPickerView, nint> ReloadComponentBinding(
            this IItemReference<UIPickerView> pickerViewReference)
        {
            if (pickerViewReference == null)
                throw new ArgumentNullException(nameof(pickerViewReference));

            return new TargetItemOneWayCustomBinding<UIPickerView, nint>(
                pickerViewReference,
                (pickerView, component) => pickerView.ReloadComponent(component),
                () => $"{nameof(UIPickerView.ReloadComponent)}");
        }

        /// <summary>
        /// One way binding on <see cref="UIPickerView.Select(nint, nint, bool)"/> method. Row index is passed as a value.
        /// </summary>
        /// <param name="pickerViewReference">The picker view reference.</param>
        /// <param name="component">The component index. The default is 0.</param>
        /// <param name="animated"><c>true</c> to animate the selection by spinning the wheel (component) to the new value; if false, the new selection is shown immediately. The default is <c>true</c>.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pickerViewReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<UIPickerView, nint> SelectBinding(
            this IItemReference<UIPickerView> pickerViewReference,
            nint component = default,
            bool animated = true)
        {
            if (pickerViewReference == null)
                throw new ArgumentNullException(nameof(pickerViewReference));

            return new TargetItemOneWayCustomBinding<UIPickerView, nint>(
                pickerViewReference,
                (pickerView, row) => pickerView.Select(row, component, animated),
                () => $"{nameof(UIPickerView.Select)}");
        }
    }
}
