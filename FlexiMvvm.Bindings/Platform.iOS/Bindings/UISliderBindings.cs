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
    public static class UISliderBindings
    {
        [NotNull]
        public static TargetItemBinding<UISlider, bool> ContinuousBinding(
            [NotNull] this IItemReference<UISlider> sliderReference)
        {
            if (sliderReference == null)
                throw new ArgumentNullException(nameof(sliderReference));

            return new TargetItemOneWayCustomBinding<UISlider, bool>(
                sliderReference,
                (slider, continuous) => slider.NotNull().Continuous = continuous,
                () => "Continuous");
        }

        [NotNull]
        public static TargetItemBinding<UISlider, float> MaxValueBinding(
            [NotNull] this IItemReference<UISlider> sliderReference)
        {
            if (sliderReference == null)
                throw new ArgumentNullException(nameof(sliderReference));

            return new TargetItemOneWayCustomBinding<UISlider, float>(
                sliderReference,
                (slider, maxValue) => slider.NotNull().MaxValue = maxValue,
                () => "MaxValue");
        }

        [NotNull]
        public static TargetItemBinding<UISlider, float> MinValueBinding(
            [NotNull] this IItemReference<UISlider> sliderReference)
        {
            if (sliderReference == null)
                throw new ArgumentNullException(nameof(sliderReference));

            return new TargetItemOneWayCustomBinding<UISlider, float>(
                sliderReference,
                (slider, minValue) => slider.NotNull().MinValue = minValue,
                () => "MinValue");
        }

        [NotNull]
        public static TargetItemBinding<UISlider, float> ValueAndValueChangedBinding(
            [NotNull] this IItemReference<UISlider> sliderReference,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (sliderReference == null)
                throw new ArgumentNullException(nameof(sliderReference));

            return new TargetItemTwoWayCustomBinding<UISlider, float>(
                sliderReference,
                (slider, eventHandler) => slider.ValueChanged += eventHandler,
                (slider, eventHandler) => slider.ValueChanged -= eventHandler,
                (slider, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        slider.NotNull().Enabled = canExecuteCommand;
                    }
                },
                slider => slider.Value,
                (slider, value) => slider.NotNull().SetValue(value, animated),
                () => "ValueAndValueChanged");
        }

        [NotNull]
        public static TargetItemBinding<UISlider, float> ValueBinding(
            [NotNull] this IItemReference<UISlider> sliderReference)
        {
            if (sliderReference == null)
                throw new ArgumentNullException(nameof(sliderReference));

            return new TargetItemOneWayCustomBinding<UISlider, float>(
                sliderReference,
                (slider, value) => slider.NotNull().Value = value,
                () => "Value");
        }

        [NotNull]
        public static TargetItemBinding<UISlider, float> ValueChangedBinding(
            [NotNull] this IItemReference<UISlider> sliderReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (sliderReference == null)
                throw new ArgumentNullException(nameof(sliderReference));

            return new TargetItemOneWayToSourceCustomBinding<UISlider, float>(
                sliderReference,
                (slider, eventHandler) => slider.ValueChanged += eventHandler,
                (slider, eventHandler) => slider.ValueChanged -= eventHandler,
                (slider, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        slider.NotNull().Enabled = canExecuteCommand;
                    }
                },
                slider => slider.Value,
                () => "ValueChanged");
        }

        [NotNull]
        public static TargetItemBinding<UISlider, float> SetValueBinding(
            [NotNull] this IItemReference<UISlider> sliderReference,
            bool animated = true)
        {
            if (sliderReference == null)
                throw new ArgumentNullException(nameof(sliderReference));

            return new TargetItemOneWayCustomBinding<UISlider, float>(
                sliderReference,
                (slider, value) => slider.NotNull().SetValue(value, animated),
                () => "SetValue");
        }
    }
}
