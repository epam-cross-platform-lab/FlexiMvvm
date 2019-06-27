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
using FlexiMvvm.Collections;

namespace FlexiMvvm.Bindings
{
    public static class TableViewObservableSourceExtensions
    {
        public static TargetItemBinding<TableViewObservableSource, object> RowDeselectedBinding(
            this IItemReference<TableViewObservableSource> tableViewSourceReference)
        {
            if (tableViewSourceReference == null)
                throw new ArgumentNullException(nameof(tableViewSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<TableViewObservableSource, object, SelectionChangedEventArgs>(
                tableViewSourceReference,
                (tableViewSource, handler) => tableViewSource.RowDeselectedCalled += handler,
                (tableViewSource, handler) => tableViewSource.RowDeselectedCalled -= handler,
                (tableViewSource, canExecuteCommand) => { },
                (tableViewSource, args) => args?.Item,
                () => $"{nameof(TableViewObservableSource.RowDeselected)}");
        }

        public static TargetItemBinding<TableViewObservableSource, object> RowSelectedBinding(
            this IItemReference<TableViewObservableSource> tableViewSourceReference)
        {
            if (tableViewSourceReference == null)
                throw new ArgumentNullException(nameof(tableViewSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<TableViewObservableSource, object, SelectionChangedEventArgs>(
                tableViewSourceReference,
                (tableViewSource, handler) => tableViewSource.RowSelectedCalled += handler,
                (tableViewSource, handler) => tableViewSource.RowSelectedCalled -= handler,
                (tableViewSource, canExecuteCommand) => { },
                (tableViewSource, args) => args?.Item,
                () => $"{nameof(TableViewObservableSource.RowSelected)}");
        }
    }
}
