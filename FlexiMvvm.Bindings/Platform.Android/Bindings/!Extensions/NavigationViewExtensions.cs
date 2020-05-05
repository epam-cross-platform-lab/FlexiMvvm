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
#if __ANDROID_29__
using Google.Android.Material.Navigation;
#else
using Android.Support.Design.Widget;
#endif
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    public static class NavigationViewExtensions
    {
        private const int DefaultCheckedItemId = 0;

#if __ANDROID_28__
        public static TargetItemBinding<NavigationView, int> SetCheckedItemAndNavigationItemSelectedBinding(
            this IItemReference<NavigationView> navigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (navigationViewReference == null)
                throw new ArgumentNullException(nameof(navigationViewReference));

            return new TargetItemTwoWayCustomBinding<NavigationView, int, NavigationView.NavigationItemSelectedEventArgs>(
                navigationViewReference,
                (navigationView, handler) => navigationView.NavigationItemSelected += handler,
                (navigationView, handler) => navigationView.NavigationItemSelected -= handler,
                (navigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        navigationView.Enabled = canExecuteCommand;
                    }
                },
                (navigationView, args) => args != null ? args.MenuItem.ItemId : navigationView.CheckedItem?.ItemId ?? DefaultCheckedItemId,
                (navigationView, id) => navigationView.SetCheckedItem(id),
                () => $"{nameof(NavigationView.NavigationItemSelected)}");
        }
#endif

        public static TargetItemBinding<NavigationView, int> SetCheckedItemBinding(
            this IItemReference<NavigationView> navigationViewReference)
        {
            if (navigationViewReference == null)
                throw new ArgumentNullException(nameof(navigationViewReference));

            return new TargetItemOneWayCustomBinding<NavigationView, int>(
                navigationViewReference,
                (navigationView, id) => navigationView.SetCheckedItem(id),
                () => $"{nameof(NavigationView.SetCheckedItem)}");
        }

        public static TargetItemBinding<NavigationView, int> NavigationItemSelectedBinding(
            this IItemReference<NavigationView> navigationViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (navigationViewReference == null)
                throw new ArgumentNullException(nameof(navigationViewReference));

            return new TargetItemOneWayToSourceCustomBinding<NavigationView, int, NavigationView.NavigationItemSelectedEventArgs>(
                navigationViewReference,
                (navigationView, handler) => navigationView.NavigationItemSelected += handler,
                (navigationView, handler) => navigationView.NavigationItemSelected -= handler,
                (navigationView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        navigationView.Enabled = canExecuteCommand;
                    }
                },
                (navigationView, args) => args.MenuItem.ItemId,
                () => $"{nameof(NavigationView.NavigationItemSelected)}");
        }
    }
}
