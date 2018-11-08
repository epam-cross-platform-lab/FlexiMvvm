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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class UIPageViewControllerObservableDataSource : UIPageViewControllerDataSource
    {
        protected const int CurrentItemNotSetIndex = -1;
        protected const int CurrentItemDefaultIndex = 0;

        [NotNull]
        private readonly WeakReference<UIPageViewController> _pageViewControllerWeakReference;
        [NotNull]
        private readonly Func<object, UIViewController> _viewControllerFactory;
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<object> _items;
        private int _currentItemIndex = CurrentItemNotSetIndex;
        [CanBeNull]
        private DisposableCollection _itemsSubscriptions;
        [CanBeNull]
        private List<UIViewController> _viewControllers;
        [CanBeNull]
        private UIViewController _emptyViewController;

        public UIPageViewControllerObservableDataSource(
            [NotNull] UIPageViewController pageViewController,
            [NotNull] Func<object, UIViewController> viewControllerFactory)
        {
            if (pageViewController == null)
                throw new ArgumentNullException(nameof(pageViewController));
            if (viewControllerFactory == null)
                throw new ArgumentNullException(nameof(viewControllerFactory));

            _pageViewControllerWeakReference = new WeakReference<UIPageViewController>(pageViewController);
            _viewControllerFactory = viewControllerFactory;
        }

        public event EventHandler<IndexChangedEventArgs> CurrentItemIndexChanged;

        [CanBeNull]
        [ItemCanBeNull]
        public IEnumerable<object> Items
        {
            get => _items;
            set
            {
                if (!ReferenceEquals(_items, value))
                {
                    _items = value;

                    RefreshItemsSubscriptions();
                    ReloadViewControllers(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
        }

        private int ItemsCount => Items?.Count() ?? 0;

        public int CurrentItemIndex
        {
            get => GetCurrentItemIndex();
            set
            {
                var currentItemOldIndex = GetCurrentItemIndex();

                if (SetCurrentItemIndex(value, false))
                {
                    SetCurrentViewController(currentItemOldIndex, value, currentItemOldIndex != CurrentItemNotSetIndex);
                }
            }
        }

        [NotNull]
        private DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        [NotNull]
        private List<UIViewController> ViewControllers => _viewControllers ?? (_viewControllers = new List<UIViewController>());

        [NotNull]
        private UIViewController EmptyViewController => _emptyViewController ?? (_emptyViewController = new UIViewController());

        private int GetCurrentItemIndex()
        {
            return _currentItemIndex;
        }

        private bool SetCurrentItemIndex(int index, bool raiseEvent = true)
        {
            var isIndexChanged = _currentItemIndex != index;
            var isIndexInRange = ItemsCount > 0
                ? index > CurrentItemNotSetIndex && index < ItemsCount
                : index == CurrentItemNotSetIndex;

            if (isIndexChanged && isIndexInRange)
            {
                _currentItemIndex = index;

                if (raiseEvent)
                {
                    CurrentItemIndexChanged?.Invoke(this, new IndexChangedEventArgs(_currentItemIndex));
                }

                return true;
            }

            return false;
        }

        [CanBeNull]
        public override UIViewController GetPreviousViewController(
            [NotNull] UIPageViewController pageViewController,
            [NotNull] UIViewController referenceViewController)
        {
            var index = ViewControllers.IndexOf(referenceViewController);
            SetCurrentItemIndex(index);
            var previousItemIndex = index > 0 ? index - 1 : CurrentItemNotSetIndex;

            return GetViewController(previousItemIndex);
        }

        [CanBeNull]
        public override UIViewController GetNextViewController(
            [NotNull] UIPageViewController pageViewController,
            [NotNull] UIViewController referenceViewController)
        {
            var index = ViewControllers.IndexOf(referenceViewController);
            SetCurrentItemIndex(index);
            var nextItemIndex = index < ItemsCount - 1 ? index + 1 : CurrentItemNotSetIndex;

            return GetViewController(nextItemIndex);
        }

        [CanBeNull]
        private UIViewController GetViewController(int index)
        {
            return index == CurrentItemNotSetIndex ? null : ViewControllers.ElementAt(index);
        }

        private void SetCurrentViewController(int currentItemOldIndex, int currentItemNewIndex, bool animated)
        {
            if (_pageViewControllerWeakReference.TryGetTarget(out var pageViewController))
            {
                pageViewController.DataSource = null;
                pageViewController.DataSource = this;

                var viewController = GetViewController(currentItemNewIndex) ?? EmptyViewController;
                var direction = GetNavigationDirection(currentItemOldIndex, currentItemNewIndex);
                SetCurrentViewController(pageViewController, viewController, direction, animated);
            }
        }

        protected virtual void SetCurrentViewController(
            [NotNull] UIPageViewController pageViewController,
            [NotNull] UIViewController viewController,
            UIPageViewControllerNavigationDirection direction,
            bool animated)
        {
            if (pageViewController == null)
                throw new ArgumentNullException(nameof(pageViewController));
            if (viewController == null)
                throw new ArgumentNullException(nameof(viewController));

            pageViewController.SetViewControllers(new[] { viewController }, direction, animated, null);
        }

        private UIPageViewControllerNavigationDirection GetNavigationDirection(int currentItemOldIndex, int currentItemNewIndex)
        {
            if (currentItemNewIndex >= currentItemOldIndex)
            {
                return CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
                    ? UIPageViewControllerNavigationDirection.Reverse
                    : UIPageViewControllerNavigationDirection.Forward;
            }

            return CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
                ? UIPageViewControllerNavigationDirection.Forward
                : UIPageViewControllerNavigationDirection.Reverse;
        }

        private void RefreshItemsSubscriptions()
        {
            _itemsSubscriptions?.Dispose();
            _itemsSubscriptions = new DisposableCollection();

            if (Items is INotifyCollectionChanged observableItems)
            {
                observableItems.CollectionChangedWeakSubscribe(Items_CollectionChanged).DisposeWith(ItemsSubscriptions);
            }
        }

        private void Items_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            ReloadViewControllers(e);
        }

        protected virtual void ReloadViewControllers([NotNull] NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var currentItemOldIndex = GetCurrentItemIndex();
            var animated = false;

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    ViewControllers.InsertRange(args.NewStartingIndex, CreateViewControllers(args.NewItems));
                    RefreshCurrentItemIndexOnAdd(currentItemOldIndex);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    ViewControllers.RemoveRange(args.OldStartingIndex, args.OldItems.NotNull().Count);
                    RefreshCurrentItemIndexOnRemove(currentItemOldIndex, args.OldStartingIndex, args.OldItems.Count);
                    animated = ShouldAnimateItemsRemoving(currentItemOldIndex, args.OldStartingIndex, args.OldItems.Count);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    ViewControllers.RemoveRange(args.OldStartingIndex, args.OldItems.NotNull().Count);
                    ViewControllers.InsertRange(args.NewStartingIndex, CreateViewControllers(args.NewItems));
                    break;
                case NotifyCollectionChangedAction.Move:
                    throw new NotSupportedException("Move operation is not supported.");
                default:
                    ViewControllers.Clear();
                    ViewControllers.AddRange(CreateViewControllers(Items));
                    RefreshCurrentItemIndexOnReset();
                    break;
            }

            var currentItemNewIndex = GetCurrentItemIndex();
            SetCurrentViewController(currentItemOldIndex, currentItemNewIndex, animated);
        }

        private void RefreshCurrentItemIndexOnAdd(int currentItemOldIndex)
        {
            if (currentItemOldIndex == CurrentItemNotSetIndex && ItemsCount > 0)
            {
                SetCurrentItemIndex(CurrentItemDefaultIndex);
            }
        }

        private void RefreshCurrentItemIndexOnRemove(int currentItemOldIndex, int removedItemsStartingIndex, int removedItemsCount)
        {
            var removedItemsEndIndex = removedItemsStartingIndex + removedItemsCount - 1;
            var currentItemIndex = currentItemOldIndex;
            var isCurrentItemOldIndexInRemovedItemsRange =
                removedItemsStartingIndex <= currentItemOldIndex && currentItemOldIndex <= removedItemsEndIndex;

            if (isCurrentItemOldIndexInRemovedItemsRange)
            {
                currentItemIndex = Math.Min(ItemsCount - 1, removedItemsStartingIndex);
            }
            else
            {
                if (currentItemOldIndex > removedItemsEndIndex)
                {
                    currentItemIndex = currentItemOldIndex - removedItemsCount;
                }
            }

            SetCurrentItemIndex(currentItemIndex);
        }

        private void RefreshCurrentItemIndexOnReset()
        {
            SetCurrentItemIndex(ItemsCount == 0 ? CurrentItemNotSetIndex : CurrentItemDefaultIndex);
        }

        private bool ShouldAnimateItemsRemoving(int currentItemOldIndex, int removedItemsStartingIndex, int removedItemsCount)
        {
            return removedItemsStartingIndex <= currentItemOldIndex && currentItemOldIndex < removedItemsStartingIndex + removedItemsCount;
        }

        [NotNull]
        private List<UIViewController> CreateViewControllers([CanBeNull] IEnumerable items)
        {
            var viewControllers = new List<UIViewController>();

            if (items != null)
            {
                foreach (var item in items)
                {
                    viewControllers.Add(_viewControllerFactory(item));
                }
            }

            return viewControllers;
        }
    }
}
