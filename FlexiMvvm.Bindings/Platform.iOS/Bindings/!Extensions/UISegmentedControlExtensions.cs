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
    public static class UISegmentedControlExtensions
    {
        public static TargetItemBinding<UISegmentedControl, nint> SelectedSegmentAndValueChangedBinding(
            this IItemReference<UISegmentedControl> segmentedControlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (segmentedControlReference == null)
                throw new ArgumentNullException(nameof(segmentedControlReference));

            return new TargetItemTwoWayCustomBinding<UISegmentedControl, nint>(
                segmentedControlReference,
                (segmentedControl, handler) => segmentedControl.ValueChanged += handler,
                (segmentedControl, handler) => segmentedControl.ValueChanged -= handler,
                (segmentedControl, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        segmentedControl.Enabled = canExecuteCommand;
                    }
                },
                segmentedControl => segmentedControl.SelectedSegment,
                (segmentedControl, selectedSegment) =>
                {
                    var selectedSegmentOldValue = segmentedControl.SelectedSegment;
                    segmentedControl.SelectedSegment = selectedSegment;
                    var selectedSegmentChanged = selectedSegmentOldValue != segmentedControl.SelectedSegment;

                    if (selectedSegmentChanged)
                    {
                        segmentedControl.SendActionForControlEvents(UIControlEvent.ValueChanged);
                    }
                },
                () => $"{nameof(UISegmentedControl.SelectedSegment)}And{nameof(UISegmentedControl.ValueChanged)}");
        }

        public static TargetItemBinding<UISegmentedControl, nint> SelectedSegmentBinding(
            this IItemReference<UISegmentedControl> segmentedControlReference)
        {
            if (segmentedControlReference == null)
                throw new ArgumentNullException(nameof(segmentedControlReference));

            return new TargetItemOneWayCustomBinding<UISegmentedControl, nint>(
                segmentedControlReference,
                (segmentedControl, selectedSegment) =>
                {
                    var selectedSegmentOldValue = segmentedControl.SelectedSegment;
                    segmentedControl.SelectedSegment = selectedSegment;
                    var selectedSegmentChanged = selectedSegmentOldValue != segmentedControl.SelectedSegment;

                    if (selectedSegmentChanged)
                    {
                        segmentedControl.SendActionForControlEvents(UIControlEvent.ValueChanged);
                    }
                },
                () => $"{nameof(UISegmentedControl.SelectedSegment)}");
        }

        public static TargetItemBinding<UISegmentedControl, nint> ValueChangedBinding(
            this IItemReference<UISegmentedControl> segmentedControlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (segmentedControlReference == null)
                throw new ArgumentNullException(nameof(segmentedControlReference));

            return new TargetItemOneWayToSourceCustomBinding<UISegmentedControl, nint>(
                segmentedControlReference,
                (segmentedControl, handler) => segmentedControl.ValueChanged += handler,
                (segmentedControl, handler) => segmentedControl.ValueChanged -= handler,
                (segmentedControl, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        segmentedControl.Enabled = canExecuteCommand;
                    }
                },
                segmentedControl => segmentedControl.SelectedSegment,
                () => $"{nameof(UISegmentedControl.ValueChanged)}");
        }
    }
}
