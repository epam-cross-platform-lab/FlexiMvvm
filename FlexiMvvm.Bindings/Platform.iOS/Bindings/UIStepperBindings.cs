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
    public static class UIStepperBindings
    {
        [NotNull]
        public static TargetItemBinding<UIStepper, bool> AutoRepeatBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, bool>(
                stepperReference,
                (stepper, autoRepeat) => stepper.NotNull().AutoRepeat = autoRepeat,
                () => "AutoRepeat");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, bool> ContinuousBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, bool>(
                stepperReference,
                (stepper, continuous) => stepper.NotNull().Continuous = continuous,
                () => "Continuous");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, double> MaximumValueBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, double>(
                stepperReference,
                (stepper, maximumValue) => stepper.NotNull().MaximumValue = maximumValue,
                () => "MaximumValue");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, double> MinimumValueBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, double>(
                stepperReference,
                (stepper, minimumValue) => stepper.NotNull().MinimumValue = minimumValue,
                () => "MinimumValue");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, UIImage> SetBackgroundImageBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference,
            UIControlState controlState = UIControlState.Normal)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, UIImage>(
                stepperReference,
                (stepper, image) => stepper.NotNull().SetBackgroundImage(image, controlState),
                () => "SetBackgroundImage");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, UIImage> SetDecrementImageBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference,
            UIControlState controlState = UIControlState.Normal)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, UIImage>(
                stepperReference,
                (stepper, image) => stepper.NotNull().SetDecrementImage(image, controlState),
                () => "SetDecrementImage");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, UIImage> SetDividerImageBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference,
            UIControlState leftState = UIControlState.Normal,
            UIControlState rightState = UIControlState.Normal)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, UIImage>(
                stepperReference,
                (stepper, image) => stepper.NotNull().SetDividerImage(image, leftState, rightState),
                () => "SetDividerImage");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, UIImage> SetIncrementImageBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference,
            UIControlState controlState = UIControlState.Normal)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, UIImage>(
                stepperReference,
                (stepper, image) => stepper.NotNull().SetIncrementImage(image, controlState),
                () => "SetIncrementImage");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, double> StepValueBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, double>(
                stepperReference,
                (stepper, stepValue) => stepper.NotNull().StepValue = stepValue,
                () => "StepValue");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, double> ValueBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, double>(
                stepperReference,
                (stepper, value) => stepper.NotNull().Value = value,
                () => "Value");
        }

        [NotNull]
        public static TargetItemBinding<UIStepper, bool> WrapsBinding(
            [NotNull] this IItemReference<UIStepper> stepperReference)
        {
            if (stepperReference == null)
                throw new ArgumentNullException(nameof(stepperReference));

            return new TargetItemOneWayCustomBinding<UIStepper, bool>(
                stepperReference,
                (stepper, wraps) => stepper.NotNull().Wraps = wraps,
                () => "Wraps");
        }
    }
}
