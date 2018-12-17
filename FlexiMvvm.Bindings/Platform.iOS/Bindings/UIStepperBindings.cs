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
        /// <summary>
        /// One way binding on <see cref="UIStepper.AutoRepeat"/> property.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIStepper.AutoRepeat"/> property.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.Continuous"/> property.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIStepper.Continuous"/> property.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.MaximumValue"/> property.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIStepper.MaximumValue"/> property.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.MinimumValue"/> property.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIStepper.MinimumValue"/> property.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.SetBackgroundImage"/> method.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <param name="controlState">Second parameter for <see cref="UIStepper.SetBackgroundImage"/> method.</param>
        /// <returns>One way binding on <see cref="UIStepper.SetBackgroundImage"/> method.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.SetDecrementImage"/> method.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <param name="controlState">Second parameter for <see cref="UIStepper.SetDecrementImage"/> method.</param>
        /// <returns>One way binding on <see cref="UIStepper.SetDecrementImage"/> method.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.SetDividerImage"/> method.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <param name="leftState">Second parameter for <see cref="UIStepper.SetDividerImage"/> method.</param>
        /// <param name="rightState">Third parameter for <see cref="UIStepper.SetDividerImage"/> method.</param>
        /// <returns>One way binding on <see cref="UIStepper.SetDividerImage"/> method.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.SetIncrementImage"/> method.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <param name="controlState">Second parameter for <see cref="UIStepper.SetIncrementImage"/> method.</param>
        /// <returns>One way binding on <see cref="UIStepper.SetIncrementImage"/> method.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.StepValue"/> property.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIStepper.StepValue"/> property.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.Value"/> property.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIStepper.Value"/> property.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIStepper.Wraps"/> property.
        /// </summary>
        /// <param name="stepperReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIStepper.Wraps"/> property.</returns>
        /// <exception cref="ArgumentNullException">stepperReference is null.</exception>
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
