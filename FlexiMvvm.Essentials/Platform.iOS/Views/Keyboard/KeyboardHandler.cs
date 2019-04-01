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
using UIKit;

namespace FlexiMvvm.Views.Keyboard
{
    /// <summary>
    /// Default implementation of the <see cref="IKeyboardHandler"/>. Responsible for scrolling the view
    /// to make the invisible or partially visible focused field fully visible when the keyboard appears.
    /// </summary>
    public sealed class KeyboardHandler : IKeyboardHandler
    {
        private readonly UIView _rootView;
        private UIScrollView? _scrollView;
        private NSObject? _keyboardWillShowObserver;
        private NSObject? _keyboardDidShowObserver;
        private NSObject? _keyboardWillHideObserver;
        private NSObject? _keyboardDidHideObserver;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardHandler"/> class.
        /// </summary>
        /// <param name="rootView"><see cref="UIViewController"/>'s root view that contains focusable fields.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rootView"/> is <c>null</c>.</exception>
        public KeyboardHandler(UIView rootView)
        {
            _rootView = rootView ?? throw new ArgumentNullException(nameof(rootView));
        }

        /// <inheritdoc />
        public event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardWillShow;

        /// <inheritdoc />
        public event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardDidShow;

        /// <inheritdoc />
        public event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardWillHide;

        /// <inheritdoc />
        public event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardDidHide;

        /// <summary>
        /// Creates a new instance of the keyboard handler if <paramref name="rootView"/> is not <c>null</c>; otherwise, returns <c>null</c>.
        /// </summary>
        /// <param name="rootView"><see cref="UIViewController"/>'s root view that contains focusable fields.</param>
        /// <returns>The keyboard handler instance.</returns>
        public static KeyboardHandler? Create(UIView? rootView)
        {
            return rootView != null ? new KeyboardHandler(rootView) : null;
        }

        /// <inheritdoc />
        public void RegisterForKeyboardNotifications()
        {
            if (_keyboardWillShowObserver == null)
            {
                _keyboardWillShowObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, KeyboardWillShowHandler);
            }

            if (_keyboardDidShowObserver == null)
            {
                _keyboardDidShowObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyboardDidShowHandler);
            }

            if (_keyboardWillHideObserver == null)
            {
                _keyboardWillHideObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyboardWillHideHandler);
            }

            if (_keyboardDidHideObserver == null)
            {
                _keyboardDidHideObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidHideNotification, KeyboardDidHideHandler);
            }
        }

        /// <inheritdoc />
        public void UnregisterFromKeyboardNotifications()
        {
            if (_keyboardWillShowObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardWillShowObserver);
                _keyboardWillShowObserver = null;
            }

            if (_keyboardDidShowObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardDidShowObserver);
                _keyboardDidShowObserver = null;
            }

            if (_keyboardWillHideObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardWillHideObserver);
                _keyboardWillHideObserver = null;
            }

            if (_keyboardDidHideObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardDidHideObserver);
                _keyboardDidHideObserver = null;
            }
        }

        private void OnKeyboardWillShow(KeyboardVisibilityChangedEventArgs args)
        {
            KeyboardWillShow?.Invoke(this, args);
        }

        private void OnKeyboardDidShow(KeyboardVisibilityChangedEventArgs args)
        {
            KeyboardDidShow?.Invoke(this, args);
        }

        private void OnKeyboardWillHide(KeyboardVisibilityChangedEventArgs args)
        {
            KeyboardWillHide?.Invoke(this, args);
        }

        private void OnKeyboardDidHide(KeyboardVisibilityChangedEventArgs args)
        {
            KeyboardDidHide?.Invoke(this, args);
        }

        private void KeyboardWillShowHandler(NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardWillShow(new KeyboardVisibilityChangedEventArgs(keyboardSize));
        }

        private void KeyboardDidShowHandler(NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardDidShow(new KeyboardVisibilityChangedEventArgs(keyboardSize));

            AdaptScrollView(keyboardSize);
        }

        private void KeyboardWillHideHandler(NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardWillHide(new KeyboardVisibilityChangedEventArgs(keyboardSize));

            RevertScrollView();
        }

        private void KeyboardDidHideHandler(NSNotification notification)
        {
            var keyboardSize = GetKeyboardSize(notification);
            OnKeyboardDidHide(new KeyboardVisibilityChangedEventArgs(keyboardSize));
        }

        private CGSize GetKeyboardSize(NSNotification notification)
        {
            var info = notification.UserInfo;
            var keyboardRect = ((NSValue)info.ObjectForKey(UIKeyboard.FrameEndUserInfoKey)).CGRectValue;

            return keyboardRect.Size;
        }

        private void AdaptScrollView(CGSize keyboardSize)
        {
            var firstResponderInScrollView = _rootView.FindFirstResponderInScrollView();

            if (firstResponderInScrollView != null)
            {
                _scrollView = firstResponderInScrollView.Item2;

                var scrollViewBottomInset = (nfloat)Math.Max(GetScrollViewBottomInset(_scrollView), 0);

                var contentInsets = new UIEdgeInsets(0, 0, keyboardSize.Height - scrollViewBottomInset, 0);
                _scrollView.ContentInset = contentInsets;
                _scrollView.ScrollIndicatorInsets = contentInsets;
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

        private nfloat GetScrollViewBottomInset(UIScrollView scrollView)
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var scrollViewContainer = scrollView.Superview;
            var scrollViewFrameRelativeToWindow = scrollViewContainer.ConvertRectToView(scrollView.Frame, window);
            var scrollViewBottom = scrollViewFrameRelativeToWindow.Y + scrollViewFrameRelativeToWindow.Height;

            return window.Bounds.Height - scrollViewBottom;
        }
    }
}
