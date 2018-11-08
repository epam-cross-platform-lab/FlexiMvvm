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
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class UITableViewObservableSourceBaseBindings
    {
        [NotNull]
        public static TargetItemBinding<UITableViewObservableSourceBase, object> RowDeselectedBinding(
            [NotNull] this IItemReference<UITableViewObservableSourceBase> tableViewSourceReference)
        {
            if (tableViewSourceReference == null)
                throw new ArgumentNullException(nameof(tableViewSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<UITableViewObservableSourceBase, object, SelectionChangedEventArgs>(
                tableViewSourceReference,
                (tableViewSource, eventHandler) => tableViewSource.NotNull().RowDeselectedCalled += eventHandler,
                (tableViewSource, eventHandler) => tableViewSource.NotNull().RowDeselectedCalled -= eventHandler,
                (tableViewSource, canExecuteCommand) => { },
                (tableViewSource, eventArgs) => eventArgs?.Item,
                () => "RowDeselected");
        }

        [NotNull]
        public static TargetItemBinding<UITableViewObservableSourceBase, object> RowSelectedBinding(
            [NotNull] this IItemReference<UITableViewObservableSourceBase> tableViewSourceReference)
        {
            if (tableViewSourceReference == null)
                throw new ArgumentNullException(nameof(tableViewSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<UITableViewObservableSourceBase, object, SelectionChangedEventArgs>(
                tableViewSourceReference,
                (tableViewSource, eventHandler) => tableViewSource.NotNull().RowSelectedCalled += eventHandler,
                (tableViewSource, eventHandler) => tableViewSource.NotNull().RowSelectedCalled -= eventHandler,
                (tableViewSource, canExecuteCommand) => { },
                (tableViewSource, eventArgs) => eventArgs?.Item,
                () => "RowSelected");
        }
    }
}
