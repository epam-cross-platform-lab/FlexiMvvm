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
using System.Collections.Specialized;
using Android.Support.V7.Widget;
using Android.Views;
using FlexiMvvm.Collections.Core;
using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public abstract class RecyclerViewObservableAdapter : RecyclerView.Adapter
    {
        protected const int DefaultViewType = 0;

        [CanBeNull]
        [ItemNotNull]
        private DisposableCollection _itemsSubscriptions;

        private protected RecyclerViewObservableAdapter([NotNull] RecyclerView recyclerView)
        {
            RecyclerView = recyclerView ?? throw new ArgumentNullException(nameof(recyclerView));
        }

        public event EventHandler<SelectionChangedEventArgs> ItemClicked;

        [CanBeNull]
        public object ItemsContext { get; set; }

        [NotNull]
        protected RecyclerView RecyclerView { get; }

        [NotNull]
        [ItemNotNull]
        private protected DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        public override int ItemCount => GetItemsMapping().Count;

        public int ItemsCount => GetItemsMapping().ItemsCount;

        public abstract int GetSectionsCount();

        public abstract int GetSectionItemsCount(int section);

        public ItemType GetItemType(int position)
        {
            return GetItemMap(position).Type;
        }

        public IndexPath GetItemIndexPath(int position)
        {
            return GetItemsMapping().GetItemIndexPath(position);
        }

        public override int GetItemViewType(int position)
        {
            var itemMap = GetItemMap(position);

            switch (itemMap.Type)
            {
                case ItemType.Header:
                case ItemType.Footer:
                    return ViewType.GetTarget(itemMap.Type, DefaultViewType);
                case ItemType.Item:
                    return ViewType.GetTarget(itemMap.Type, OnGetItemViewType(itemMap.Item));
                default:
                    throw new ArgumentException($"Unable to get item view type for \"{position}\" position.", nameof(position));
            }
        }

        protected virtual int OnGetItemViewType([CanBeNull] object item)
        {
            return DefaultViewType;
        }

        [NotNull]
        public override RecyclerView.ViewHolder OnCreateViewHolder([NotNull] ViewGroup parent, int viewType)
        {
            var itemType = ViewType.ToItemType(viewType);

            switch (itemType)
            {
                case ItemType.Header:
                    return OnCreateHeaderViewHolder(parent);
                case ItemType.SectionHeader:
                    return OnCreateSectionHeaderViewHolder(parent, ViewType.GetRequested(viewType));
                case ItemType.Item:
                    var viewHolder = OnCreateItemViewHolder(parent, ViewType.GetRequested(viewType));
                    viewHolder.ItemView.NotNull().ClickWeakSubscribe(ItemView_Click);
                    return viewHolder;
                case ItemType.SectionFooter:
                    return OnCreateSectionFooterViewHolder(parent, ViewType.GetRequested(viewType));
                case ItemType.Footer:
                    return OnCreateFooterViewHolder(parent);
                default:
                    throw new ArgumentException($"Unable to create a view holder for \"{viewType}\" view type.", nameof(viewType));
            }
        }

        [NotNull]
        protected virtual RecyclerViewObservableViewHolder OnCreateHeaderViewHolder([NotNull] ViewGroup parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            return new RecyclerViewObservableViewHolder(new View(parent.Context));
        }

        [NotNull]
        protected virtual RecyclerViewObservableViewHolder OnCreateSectionHeaderViewHolder([NotNull] ViewGroup parent, int viewType)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            return new RecyclerViewObservableViewHolder(new View(parent.Context));
        }

        [NotNull]
        protected abstract RecyclerViewObservableViewHolder OnCreateItemViewHolder([NotNull] ViewGroup parent, int viewType);

        [NotNull]
        protected virtual RecyclerViewObservableViewHolder OnCreateSectionFooterViewHolder([NotNull] ViewGroup parent, int viewType)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            return new RecyclerViewObservableViewHolder(new View(parent.Context));
        }

        [NotNull]
        protected virtual RecyclerViewObservableViewHolder OnCreateFooterViewHolder([NotNull] ViewGroup parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            return new RecyclerViewObservableViewHolder(new View(parent.Context));
        }

        public override void OnBindViewHolder([NotNull] RecyclerView.ViewHolder holder, int position)
        {
            var itemMap = GetItemMap(position);
            var observableViewHolder = (RecyclerViewObservableViewHolder)holder;

            switch (itemMap.Type)
            {
                case ItemType.Header:
                case ItemType.Footer:
                    observableViewHolder.Bind(ItemsContext, null);
                    break;
                case ItemType.SectionHeader:
                case ItemType.SectionFooter:
                    observableViewHolder.Bind(ItemsContext, itemMap.Group);
                    break;
                case ItemType.Item:
                    observableViewHolder.Bind(ItemsContext, itemMap.Item);
                    break;
                default:
                    throw new ArgumentException($"Unable to bind a view holder for \"{position}\" position.", nameof(position));
            }
        }

        [NotNull]
        private protected abstract ItemsMapping GetItemsMapping();

        [NotNull]
        private protected ItemMap GetItemMap(int position)
        {
            return GetItemsMapping().ElementAt(position);
        }

        [CanBeNull]
        protected internal abstract object GetItem(int section, int row);

        private protected virtual void RefreshItemsSubscriptions()
        {
            _itemsSubscriptions?.Dispose();
            _itemsSubscriptions = new DisposableCollection();
        }

        protected abstract void ReloadSections([NotNull] NotifyCollectionChangedEventArgs args);

        protected virtual void ReloadSection(int section, [NotNull] NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var itemsMapping = GetItemsMapping();

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    itemsMapping.AddItems(section, args, this);
                    break;
                case NotifyCollectionChangedAction.Move:
                    itemsMapping.MoveItem(section, args, this);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    itemsMapping.ReplaceItems(section, args, this);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    itemsMapping.RemoveItems(section, args, this);
                    break;
                default:
                    itemsMapping.Reload(this);
                    break;
            }
        }

        private void ItemView_Click([NotNull] object sender, [NotNull] EventArgs e)
        {
            var position = RecyclerView.GetChildAdapterPosition((View)sender);

            ItemClicked?.Invoke(this, new SelectionChangedEventArgs(GetItemMap(position).Item));
        }
    }
}
