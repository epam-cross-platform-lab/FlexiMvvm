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
using System.Windows.Input;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    /// <summary>
    /// Provides a set of static methods for creating bindings on <see cref="AdapterView"/> members.
    /// </summary>
    public static class AdapterViewExtensions
    {
        /// <summary>
        /// One way to source binding on <see cref="AdapterView.ItemSelected"/> event. Item position is passed as a value.
        /// </summary>
        /// <param name="adapterViewReference">The adapter view reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AdapterView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="adapterViewReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<AdapterView, int> ItemSelectedBinding(
            this IItemReference<AdapterView> adapterViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (adapterViewReference == null)
                throw new ArgumentNullException(nameof(adapterViewReference));

            return new TargetItemOneWayToSourceCustomBinding<AdapterView, int, AdapterView.ItemSelectedEventArgs>(
                adapterViewReference,
                (adapterView, handler) => adapterView.ItemSelected += handler,
                (adapterView, handler) => adapterView.ItemSelected -= handler,
                (adapterView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        adapterView.Enabled = canExecuteCommand;
                    }
                },
                (adapterView, args) => args.Position,
                () => $"{nameof(AdapterView.ItemSelected)}");
        }

        /// <summary>
        /// One way to source binding on <see cref="AdapterView.NothingSelected"/> event. <c>null</c> is passed as a value.
        /// </summary>
        /// <param name="adapterViewReference">The adapter view reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AdapterView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="adapterViewReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<AdapterView, object> NothingSelectedBinding(
            this IItemReference<AdapterView> adapterViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (adapterViewReference == null)
                throw new ArgumentNullException(nameof(adapterViewReference));

            return new TargetItemOneWayToSourceCustomBinding<AdapterView, object, AdapterView.NothingSelectedEventArgs>(
                adapterViewReference,
                (adapterView, handler) => adapterView.NothingSelected += handler,
                (adapterView, handler) => adapterView.NothingSelected -= handler,
                (adapterView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        adapterView.Enabled = canExecuteCommand;
                    }
                },
                (adapterView, args) => null,
                () => $"{nameof(AdapterView.NothingSelected)}");
        }

        /// <summary>
        /// One way binding on <see cref="AdapterView.SetSelection(int)"/> method. Item position is passed as a value.
        /// </summary>
        /// <param name="adapterViewReference">The adapter view reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="adapterViewReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<AdapterView, int> SetSelectionBinding(
            this IItemReference<AdapterView> adapterViewReference)
        {
            if (adapterViewReference == null)
                throw new ArgumentNullException(nameof(adapterViewReference));

            return new TargetItemOneWayCustomBinding<AdapterView, int>(
                adapterViewReference,
                (adapterView, position) => adapterView.SetSelection(position),
                () => $"{nameof(AdapterView.SetSelection)}");
        }

        /// <summary>
        /// Two way binding on <see cref="AdapterView.SetSelection(int)"/> method and <see cref="AdapterView.ItemSelected"/> event. Item position is passed as a value.
        /// </summary>
        /// <param name="adapterViewReference">The adapter view reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AdapterView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="adapterViewReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<AdapterView, int> SetSelectionAndItemSelectedBinding(
            this IItemReference<AdapterView> adapterViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (adapterViewReference == null)
                throw new ArgumentNullException(nameof(adapterViewReference));

            return new TargetItemTwoWayCustomBinding<AdapterView, int, AdapterView.ItemSelectedEventArgs>(
                adapterViewReference,
                (adapterView, handler) => adapterView.ItemSelected += handler,
                (adapterView, handler) => adapterView.ItemSelected -= handler,
                (adapterView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        adapterView.Enabled = canExecuteCommand;
                    }
                },
                (adapterView, args) => args?.Position ?? adapterView.SelectedItemPosition,
                (adapterView, position) => adapterView.SetSelection(position),
                () => $"{nameof(AdapterView.SetSelection)}And{nameof(AdapterView.ItemSelected)}");
        }
    }
}
