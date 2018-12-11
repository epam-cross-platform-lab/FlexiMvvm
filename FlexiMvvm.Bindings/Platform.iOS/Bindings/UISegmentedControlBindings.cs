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
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UISegmentedControlBindings
    {
        /// <summary>
        /// Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UISegmentedControl.SelectedSegment"/> property.
        /// </summary>
        /// <param name="segmentedControlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UISegmentedControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UISegmentedControl.SelectedSegment"/> property.</returns>
        /// <exception cref="ArgumentNullException">segmentedControlReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISegmentedControl, nint> SelectedSegmentAndValueChangedBinding(
            [NotNull] this IItemReference<UISegmentedControl> segmentedControlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (segmentedControlReference == null)
                throw new ArgumentNullException(nameof(segmentedControlReference));

            return new TargetItemTwoWayCustomBinding<UISegmentedControl, nint>(
                segmentedControlReference,
                (segmentedControl, eventHandler) => segmentedControl.NotNull().ValueChanged += eventHandler,
                (segmentedControl, eventHandler) => segmentedControl.NotNull().ValueChanged -= eventHandler,
                (segmentedControl, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        segmentedControl.NotNull().Enabled = canExecuteCommand;
                    }
                },
                segmentedControl => segmentedControl.NotNull().SelectedSegment,
                (segmentedControl, selectedSegment) =>
                {
                    var selectedSegmentOldValue = segmentedControl.NotNull().SelectedSegment;
                    segmentedControl.SelectedSegment = selectedSegment;
                    var selectedSegmentChanged = selectedSegmentOldValue != segmentedControl.SelectedSegment;

                    if (selectedSegmentChanged)
                    {
                        segmentedControl.SendActionForControlEvents(UIControlEvent.ValueChanged);
                    }
                },
                () => "SelectedSegmentAndValueChanged");
        }

        /// <summary>
        /// Binding on <see cref="UISegmentedControl.SelectedSegment"/> property.
        /// </summary>
        /// <param name="segmentedControlReference">The item reference.</param>
        /// <returns>Binding on <see cref="UISegmentedControl.SelectedSegment"/> property.</returns>
        /// <exception cref="ArgumentNullException">segmentedControlReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISegmentedControl, nint> SelectedSegmentBinding(
            [NotNull] this IItemReference<UISegmentedControl> segmentedControlReference)
        {
            if (segmentedControlReference == null)
                throw new ArgumentNullException(nameof(segmentedControlReference));

            return new TargetItemOneWayCustomBinding<UISegmentedControl, nint>(
                segmentedControlReference,
                (segmentedControl, selectedSegment) =>
                {
                    var selectedSegmentOldValue = segmentedControl.NotNull().SelectedSegment;
                    segmentedControl.SelectedSegment = selectedSegment;
                    var selectedSegmentChanged = selectedSegmentOldValue != segmentedControl.SelectedSegment;

                    if (selectedSegmentChanged)
                    {
                        segmentedControl.SendActionForControlEvents(UIControlEvent.ValueChanged);
                    }
                },
                () => "SelectedSegment");
        }
    }
}
