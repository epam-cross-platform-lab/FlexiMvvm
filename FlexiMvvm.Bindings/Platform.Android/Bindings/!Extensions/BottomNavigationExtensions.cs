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
using Android.Support.Design.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class BottomNavigationExtensions
    {
        [NotNull]
        public static TargetItemBinding<BottomNavigationView, int> NavigationItemReselectedBinding(
            [NotNull] this IItemReference<BottomNavigationView> bottomNavigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemOneWayToSourceCustomBinding<BottomNavigationView, int, BottomNavigationView.NavigationItemReselectedEventArgs>(
                bottomNavigationViewReference,
                (bottomNavigationView, eventHandler) => bottomNavigationView.NotNull().NavigationItemReselected += eventHandler,
                (bottomNavigationView, eventHandler) => bottomNavigationView.NotNull().NavigationItemReselected -= eventHandler,
                (bottomNavigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        bottomNavigationView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (bottomNavigationView, eventArgs) => eventArgs.NotNull().Item.NotNull().ItemId,
                () => $"{nameof(BottomNavigationView.NavigationItemReselected)}");
        }

        [NotNull]
        public static TargetItemBinding<BottomNavigationView, int> NavigationItemSelectedBinding(
            [NotNull] this IItemReference<BottomNavigationView> bottomNavigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemOneWayToSourceCustomBinding<BottomNavigationView, int, BottomNavigationView.NavigationItemSelectedEventArgs>(
                bottomNavigationViewReference,
                (bottomNavigationView, eventHandler) => bottomNavigationView.NotNull().NavigationItemSelected += eventHandler,
                (bottomNavigationView, eventHandler) => bottomNavigationView.NotNull().NavigationItemSelected -= eventHandler,
                (bottomNavigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        bottomNavigationView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (bottomNavigationView, eventArgs) => eventArgs.NotNull().Item.NotNull().ItemId,
                () => $"{nameof(BottomNavigationView.NavigationItemSelected)}");
        }

        [NotNull]
        public static TargetItemBinding<BottomNavigationView, int> SelectedItemIdAndNavigationItemSelectedBinding(
            [NotNull] this IItemReference<BottomNavigationView> bottomNavigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemTwoWayCustomBinding<BottomNavigationView, int, BottomNavigationView.NavigationItemSelectedEventArgs>(
                bottomNavigationViewReference,
                (bottomNavigationView, eventHandler) => bottomNavigationView.NotNull().NavigationItemSelected += eventHandler,
                (bottomNavigationView, eventHandler) => bottomNavigationView.NotNull().NavigationItemSelected -= eventHandler,
                (bottomNavigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        bottomNavigationView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (bottomNavigationView, eventArgs) => eventArgs?.Item.NotNull().ItemId ?? bottomNavigationView.NotNull().SelectedItemId,
                (bottomNavigationView, selectedItemId) => bottomNavigationView.NotNull().SelectedItemId = selectedItemId,
                () => $"{nameof(BottomNavigationView.SelectedItemId)}And{nameof(BottomNavigationView.NavigationItemSelected)}");
        }

        [NotNull]
        public static TargetItemBinding<BottomNavigationView, int> SelectedItemIdBinding(
            [NotNull] this IItemReference<BottomNavigationView> bottomNavigationViewReference)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemOneWayCustomBinding<BottomNavigationView, int>(
                bottomNavigationViewReference,
                (bottomNavigationView, selectedItemId) => bottomNavigationView.NotNull().SelectedItemId = selectedItemId,
                () => $"{nameof(BottomNavigationView.SelectedItemId)}");
        }
    }
}
