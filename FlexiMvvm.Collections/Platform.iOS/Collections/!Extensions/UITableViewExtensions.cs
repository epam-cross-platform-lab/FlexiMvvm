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
using CoreGraphics;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    // https://spin.atomicobject.com/2017/08/11/swift-extending-uitableviewcontroller/
    public static class UITableViewExtensions
    {
        public static void SizeTableHeaderViewToFit([NotNull] this UITableView tableView)
        {
            if (tableView == null)
                throw new ArgumentNullException(nameof(tableView));

            SizeTableHeaderFooterViewToFit(tableView.TableHeaderView);
            tableView.TableHeaderView = tableView.TableHeaderView;
        }

        public static void SizeTableFooterViewToFit([NotNull] this UITableView tableView)
        {
            if (tableView == null)
                throw new ArgumentNullException(nameof(tableView));

            SizeTableHeaderFooterViewToFit(tableView.TableFooterView);
            tableView.TableFooterView = tableView.TableFooterView;
        }

        private static void SizeTableHeaderFooterViewToFit([CanBeNull] UIView headerFooterView)
        {
            if (headerFooterView != null)
            {
                headerFooterView.SetNeedsLayout();
                headerFooterView.LayoutIfNeeded();

                var height = headerFooterView.SystemLayoutSizeFittingSize(UIView.UILayoutFittingCompressedSize).Height;
                var frame = headerFooterView.Frame;
                frame.Size = new CGSize(frame.Size.Width, height);
                headerFooterView.Frame = frame;
            }
        }

        internal static void SupportPerformBatchUpdates([NotNull] this UITableView tableView, [CanBeNull] Action updates)
        {
            if (UIDevice.CurrentDevice.NotNull().CheckSystemVersion(11, 0))
            {
                tableView.PerformBatchUpdates(updates, null);
            }
            else
            {
                if (updates != null)
                {
                    tableView.BeginUpdates();
                    updates();
                    tableView.EndUpdates();
                }
            }
        }
    }
}
