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
using FlexiMvvm.Bindings.Custom.Core;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings.Custom
{
    public class UIViewTapBinding : TargetItemBinding<UIView, object>, ITargetItemCommandListener<UIView>
    {
        [NotNull]
        private readonly Action<UIView, bool> _handleCanExecuteCommandChanged;
        private readonly int _numberOfTapsRequired;
        private readonly int _numberOfTouchesRequired;
        [CanBeNull]
        private WeakReference<UITapGestureRecognizer> _tapGestureRecognizerWeakReference;

        public UIViewTapBinding(
            [NotNull] IItemReference<UIView> itemReference,
            [NotNull] Action<UIView, bool> handleCanExecuteCommandChanged,
            int numberOfTapsRequired = 1,
            int numberOfTouchesRequired = 1)
            : base(itemReference, () => "Tap")
        {
            _handleCanExecuteCommandChanged = handleCanExecuteCommandChanged ?? throw new ArgumentNullException(nameof(handleCanExecuteCommandChanged));
            _numberOfTapsRequired = numberOfTapsRequired;
            _numberOfTouchesRequired = numberOfTouchesRequired;
        }

        protected internal override BindingMode BindingMode { get; } = BindingMode.OneWayToSource;

        protected internal override void SubscribeToEvents(UIView item)
        {
            base.SubscribeToEvents(item);

            var tapGestureRecognizer = new UITapGestureRecognizer(HandleTap)
            {
                NumberOfTapsRequired = (nuint)_numberOfTapsRequired,
                NumberOfTouchesRequired = (nuint)_numberOfTouchesRequired
            };

            item.AddGestureRecognizer(tapGestureRecognizer);
            _tapGestureRecognizerWeakReference = new WeakReference<UITapGestureRecognizer>(tapGestureRecognizer);
        }

        protected internal override void UnsubscribeFromEvents(UIView item)
        {
            base.UnsubscribeFromEvents(item);

            if (_tapGestureRecognizerWeakReference != null && _tapGestureRecognizerWeakReference.TryGetTarget(out var tapGestureRecognizer))
            {
                item.RemoveGestureRecognizer(tapGestureRecognizer);
            }
        }

        protected internal override bool TryGetValue(UIView item, out object value)
        {
            value = default;

            return true;
        }

        public void HandleCanExecuteCommandChanged(UIView item, bool canExecute)
        {
            _handleCanExecuteCommandChanged(item, canExecute);
        }

        private void HandleTap()
        {
            if (TryGetItem(out var item) && TryGetValue(item, out var value))
            {
                RaiseValueChanged(value);
            }
        }
    }
}
