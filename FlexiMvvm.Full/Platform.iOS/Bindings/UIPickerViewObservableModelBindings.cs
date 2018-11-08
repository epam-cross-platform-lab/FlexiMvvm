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

using System;
using System.Collections.Generic;
using FlexiMvvm.Bindings.Custom;
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class UIPickerViewObservableModelBindings
    {
        [NotNull]
        public static TargetItemBinding<UIPickerViewObservableModel, IEnumerable<object>> ItemsBinding(
            [NotNull] this IItemReference<UIPickerViewObservableModel> pickerViewModelReference)
        {
            if (pickerViewModelReference == null)
                throw new ArgumentNullException(nameof(pickerViewModelReference));

            return new TargetItemOneWayCustomBinding<UIPickerViewObservableModel, IEnumerable<object>>(
                pickerViewModelReference,
                (pickerViewModel, items) => pickerViewModel.NotNull().Items = items,
                () => "Items");
        }

        [NotNull]
        public static TargetItemBinding<UIPickerViewObservableModel, object> SelectedBinding(
            [NotNull] this IItemReference<UIPickerViewObservableModel> pickerViewModelReference)
        {
            if (pickerViewModelReference == null)
                throw new ArgumentNullException(nameof(pickerViewModelReference));

            return new TargetItemOneWayToSourceCustomBinding<UIPickerViewObservableModel, object, SelectionChangedEventArgs>(
                pickerViewModelReference,
                (pickerViewModel, eventHandler) => pickerViewModel.NotNull().SelectedCalled += eventHandler,
                (pickerViewModel, eventHandler) => pickerViewModel.NotNull().SelectedCalled -= eventHandler,
                (pickerViewModel, canExecuteCommand) => { },
                (pickerViewModel, eventArgs) => eventArgs?.Item ?? pickerViewModel.NotNull().SelectedItem,
                () => "Selected");
        }

        [NotNull]
        public static TargetItemBinding<UIPickerViewObservableModel, object> SelectedItemAndSelectedBinding(
            [NotNull] this IItemReference<UIPickerViewObservableModel> pickerViewModelReference)
        {
            if (pickerViewModelReference == null)
                throw new ArgumentNullException(nameof(pickerViewModelReference));

            return new TargetItemTwoWayCustomBinding<UIPickerViewObservableModel, object, SelectionChangedEventArgs>(
                pickerViewModelReference,
                (pickerViewModel, eventHandler) => pickerViewModel.NotNull().SelectedCalled += eventHandler,
                (pickerViewModel, eventHandler) => pickerViewModel.NotNull().SelectedCalled -= eventHandler,
                (pickerViewModel, canExecuteCommand) => { },
                (pickerViewModel, eventArgs) => eventArgs?.Item ?? pickerViewModel.NotNull().SelectedItem,
                (pickerViewModel, selectedItem) => pickerViewModel.NotNull().SelectedItem = selectedItem,
                () => "SelectedItemAndSelected");
        }

        [NotNull]
        public static TargetItemBinding<UIPickerViewObservableModel, object> SelectedItemBinding(
            [NotNull] this IItemReference<UIPickerViewObservableModel> pickerViewModelReference)
        {
            if (pickerViewModelReference == null)
                throw new ArgumentNullException(nameof(pickerViewModelReference));

            return new TargetItemOneWayCustomBinding<UIPickerViewObservableModel, object>(
                pickerViewModelReference,
                (pickerViewModel, selectedItem) => pickerViewModel.NotNull().SelectedItem = selectedItem,
                () => "SelectedItem");
        }
    }
}
