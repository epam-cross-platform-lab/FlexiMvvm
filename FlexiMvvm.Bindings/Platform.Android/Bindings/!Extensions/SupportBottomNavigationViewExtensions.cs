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

namespace FlexiMvvm.Bindings
{
    public static class SupportBottomNavigationViewExtensions
    {
        public static TargetItemBinding<BottomNavigationView, int> NavigationItemReselectedBinding(
            this IItemReference<BottomNavigationView> bottomNavigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemOneWayToSourceCustomBinding<BottomNavigationView, int, BottomNavigationView.NavigationItemReselectedEventArgs>(
                bottomNavigationViewReference,
                (bottomNavigationView, handler) => bottomNavigationView.NavigationItemReselected += handler,
                (bottomNavigationView, handler) => bottomNavigationView.NavigationItemReselected -= handler,
                (bottomNavigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        bottomNavigationView.Enabled = canExecuteCommand;
                    }
                },
                (bottomNavigationView, args) => args.Item.ItemId,
                () => $"{nameof(BottomNavigationView.NavigationItemReselected)}");
        }

        public static TargetItemBinding<BottomNavigationView, int> NavigationItemSelectedBinding(
            this IItemReference<BottomNavigationView> bottomNavigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemOneWayToSourceCustomBinding<BottomNavigationView, int, BottomNavigationView.NavigationItemSelectedEventArgs>(
                bottomNavigationViewReference,
                (bottomNavigationView, handler) => bottomNavigationView.NavigationItemSelected += handler,
                (bottomNavigationView, handler) => bottomNavigationView.NavigationItemSelected -= handler,
                (bottomNavigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        bottomNavigationView.Enabled = canExecuteCommand;
                    }
                },
                (bottomNavigationView, args) => args.Item.ItemId,
                () => $"{nameof(BottomNavigationView.NavigationItemSelected)}");
        }

        public static TargetItemBinding<BottomNavigationView, int> SelectedItemIdAndNavigationItemSelectedBinding(
            this IItemReference<BottomNavigationView> bottomNavigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemTwoWayCustomBinding<BottomNavigationView, int, BottomNavigationView.NavigationItemSelectedEventArgs>(
                bottomNavigationViewReference,
                (bottomNavigationView, handler) => bottomNavigationView.NavigationItemSelected += handler,
                (bottomNavigationView, handler) => bottomNavigationView.NavigationItemSelected -= handler,
                (bottomNavigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        bottomNavigationView.Enabled = canExecuteCommand;
                    }
                },
                (bottomNavigationView, args) => args != null ? args.Item.ItemId : bottomNavigationView.SelectedItemId,
                (bottomNavigationView, selectedItemId) => bottomNavigationView.SelectedItemId = selectedItemId,
                () => $"{nameof(BottomNavigationView.SelectedItemId)}And{nameof(BottomNavigationView.NavigationItemSelected)}");
        }

        public static TargetItemBinding<BottomNavigationView, int> SelectedItemIdBinding(
            this IItemReference<BottomNavigationView> bottomNavigationViewReference)
        {
            if (bottomNavigationViewReference == null)
                throw new ArgumentNullException(nameof(bottomNavigationViewReference));

            return new TargetItemOneWayCustomBinding<BottomNavigationView, int>(
                bottomNavigationViewReference,
                (bottomNavigationView, selectedItemId) => bottomNavigationView.SelectedItemId = selectedItemId,
                () => $"{nameof(BottomNavigationView.SelectedItemId)}");
        }
    }
}
