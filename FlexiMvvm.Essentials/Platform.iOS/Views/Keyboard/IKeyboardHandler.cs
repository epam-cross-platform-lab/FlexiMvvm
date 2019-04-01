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

namespace FlexiMvvm.Views.Keyboard
{
    /// <summary>
    /// Defines the contract for a keyboard handler that is responsible for scrolling the view
    /// to make the invisible or partially visible focused field fully visible when the keyboard appears.
    /// </summary>
    public interface IKeyboardHandler
    {
        /// <summary>
        /// Occurs when the keyboard is going to be shown.
        /// </summary>
        event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardWillShow;

        /// <summary>
        /// Occurs when the keyboard is shown.
        /// </summary>
        event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardDidShow;

        /// <summary>
        /// Occurs when the keyboard is going to be hidden.
        /// </summary>
        event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardWillHide;

        /// <summary>
        /// Occurs when the keyboard is hidden.
        /// </summary>
        event EventHandler<KeyboardVisibilityChangedEventArgs> KeyboardDidHide;

        /// <summary>
        /// Starts listening to keyboard notifications for processing by the handler.
        /// </summary>
        void RegisterForKeyboardNotifications();

        /// <summary>
        /// Stops listening to keyboard notifications. The handler will no longer process them.
        /// </summary>
        void UnregisterFromKeyboardNotifications();
    }
}
