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
using FlexiMvvm.Collections;

namespace FlexiMvvm.Bindings
{
    /// <summary>
    /// Provides a set of static methods for creating bindings on <see cref="PickerViewObservableModel"/> members.
    /// </summary>
    public static class PickerViewObservableModelExtensions
    {
        /// <summary>
        /// One way to source binding on <see cref="PickerViewObservableModel{T}.SelectedCalled"/> event. Row index is passed as a value.
        /// </summary>
        /// <typeparam name="T">The type of the picker view model collection item.</typeparam>
        /// <param name="pickerViewModelReference">The picker view model reference.</param>
        /// <param name="component">The component index to listen. The default is 0.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pickerViewModelReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<PickerViewObservableModel<T>, nint> SelectedBinding<T>(
            this IItemReference<PickerViewObservableModel<T>> pickerViewModelReference,
            nint component = default)
        {
            if (pickerViewModelReference == null)
                throw new ArgumentNullException(nameof(pickerViewModelReference));

            return new TargetItemOneWayToSourceCustomBinding<PickerViewObservableModel<T>, nint, PickerViewItemSelectedEventArgs>(
                pickerViewModelReference,
                (pickerViewModel, handler) => pickerViewModel.SelectedCalled += handler,
                (pickerViewModel, handler) => pickerViewModel.SelectedCalled -= handler,
                (pickerViewModel, canExecuteCommand) => { },
                (pickerViewModel, args) => args.Row,
                (pickerViewModel, args) => args.Component == component,
                () => $"{nameof(PickerViewObservableModel.SelectedCalled)}");
        }
    }
}
