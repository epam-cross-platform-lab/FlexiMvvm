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
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public class KeyboardHandler
    {
        [NotNull]
        private readonly UIView _rootView;
        [CanBeNull]
        private UIScrollView _scrollView;
        [CanBeNull]
        private NSObject _keyboardWillShowObserver;
        [CanBeNull]
        private NSObject _keyboardDidShowObserver;
        [CanBeNull]
        private NSObject _keyboardWillHideObserver;
        [CanBeNull]
        private NSObject _keyboardDidHideObserver;

        public KeyboardHandler([NotNull] UIView rootView)
        {
            _rootView = rootView ?? throw new ArgumentNullException(nameof(rootView));
        }

        public event EventHandler<KeyboardSizeChangedEventArgs> KeyboardWillShow;

        public event EventHandler<KeyboardSizeChangedEventArgs> KeyboardDidShow;

        public event EventHandler<KeyboardSizeChangedEventArgs> KeyboardWillHide;

        public event EventHandler<KeyboardSizeChangedEventArgs> KeyboardDidHide;

        public void RegisterForKeyboardNotifications()
        {
            if (_keyboardWillShowObserver == null)
            {
                _keyboardWillShowObserver = NSNotificationCenter.DefaultCenter.NotNull().AddObserver(
                    UIKeyboard.WillShowNotification,
                    KeyboardWillShowHandler);
            }

            if (_keyboardDidShowObserver == null)
            {
                _keyboardDidShowObserver = NSNotificationCenter.DefaultCenter.NotNull().AddObserver(
                    UIKeyboard.DidShowNotification,
                    KeyboardDidShowHandler);
            }

            if (_keyboardWillHideObserver == null)
            {
                _keyboardWillHideObserver = NSNotificationCenter.DefaultCenter.NotNull().AddObserver(
                    UIKeyboard.WillHideNotification,
                    KeyboardWillHideHandler);
            }

            if (_keyboardDidHideObserver == null)
            {
                _keyboardDidHideObserver = NSNotificationCenter.DefaultCenter.NotNull().AddObserver(
                    UIKeyboard.DidHideNotification,
                    KeyboardDidHideHandler);
            }
        }

        public void UnregisterFromKeyboardNotifications()
        {
            if (_keyboardWillShowObserver != null)
            {
                NSNotificationCenter.DefaultCenter.NotNull().RemoveObserver(_keyboardWillShowObserver);
                _keyboardWillShowObserver = null;
            }

            if (_keyboardDidShowObserver != null)
            {
                NSNotificationCenter.DefaultCenter.NotNull().RemoveObserver(_keyboardDidShowObserver);
                _keyboardDidShowObserver = null;
            }

            if (_keyboardWillHideObserver != null)
            {
                NSNotificationCenter.DefaultCenter.NotNull().RemoveObserver(_keyboardWillHideObserver);
                _keyboardWillHideObserver = null;
            }

            if (_keyboardDidHideObserver != null)
            {
                NSNotificationCenter.DefaultCenter.NotNull().RemoveObserver(_keyboardDidHideObserver);
                _keyboardDidHideObserver = null;
            }
        }

        protected virtual void OnKeyboardWillShow([NotNull] KeyboardSizeChangedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            KeyboardWillShow?.Invoke(this, e);
        }

        protected virtual void OnKeyboardDidShow([NotNull] KeyboardSizeChangedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            KeyboardDidShow?.Invoke(this, e);
        }

        protected virtual void OnKeyboardWillHide([NotNull] KeyboardSizeChangedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            KeyboardWillHide?.Invoke(this, e);
        }

        protected virtual void OnKeyboardDidHide([NotNull] KeyboardSizeChangedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            KeyboardDidHide?.Invoke(this, e);
        }

        private void KeyboardWillShowHandler([NotNull] NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardWillShow(new KeyboardSizeChangedEventArgs(keyboardSize));
        }

        private void KeyboardDidShowHandler([NotNull] NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardDidShow(new KeyboardSizeChangedEventArgs(keyboardSize));

            AdaptScrollView(keyboardSize);
        }

        private void KeyboardWillHideHandler([NotNull] NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardWillHide(new KeyboardSizeChangedEventArgs(keyboardSize));

            RevertScrollView();
        }

        private void KeyboardDidHideHandler([NotNull] NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardDidHide(new KeyboardSizeChangedEventArgs(keyboardSize));
        }

        private CGSize GetKeyboardSize([NotNull] NSNotification notification)
        {
            var info = notification.UserInfo.NotNull();
            var keyboardRect = ((NSValue)info.ObjectForKey(UIKeyboard.FrameEndUserInfoKey).NotNull()).CGRectValue;

            return keyboardRect.Size;
        }

        private void AdaptScrollView(CGSize keyboardSize)
        {
            var firstResponderInScrollView = _rootView.FindFirstResponderInScrollView();

            if (firstResponderInScrollView != null)
            {
                _scrollView = firstResponderInScrollView.Item2;

                var scrollViewBottomInset = (nfloat)Math.Max(GetScrollViewBottomInset(_scrollView.NotNull()), 0);

                var contentInsets = new UIEdgeInsets(0, 0, keyboardSize.Height - scrollViewBottomInset, 0);
                _scrollView.NotNull().ContentInset = contentInsets;
                _scrollView.NotNull().ScrollIndicatorInsets = contentInsets;
            }
        }

        private void RevertScrollView()
        {
            if (_scrollView != null)
            {
                _scrollView.ContentInset = UIEdgeInsets.Zero;
                _scrollView.ScrollIndicatorInsets = UIEdgeInsets.Zero;
                _scrollView = null;
            }
        }

        private nfloat GetScrollViewBottomInset([NotNull] UIScrollView scrollView)
        {
            var window = UIApplication.SharedApplication.NotNull().KeyWindow.NotNull();
            var scrollViewContainer = scrollView.Superview.NotNull();
            var scrollViewFrameRelativeToWindow = scrollViewContainer.ConvertRectToView(scrollView.Frame, window);
            var scrollViewBottom = scrollViewFrameRelativeToWindow.Y + scrollViewFrameRelativeToWindow.Height;

            return window.Bounds.Height - scrollViewBottom;
        }
    }
}
