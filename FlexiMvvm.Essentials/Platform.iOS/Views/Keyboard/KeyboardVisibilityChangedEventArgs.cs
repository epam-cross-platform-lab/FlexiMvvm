using System;
using CoreGraphics;

namespace FlexiMvvm.Views.Keyboard
{
    /// <summary>
    /// Provides data for the <see cref="IKeyboardHandler"/> class events.
    /// </summary>
    public class KeyboardVisibilityChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardVisibilityChangedEventArgs"/> class.
        /// </summary>
        /// <param name="keyboardSize">The size of the keyboard.</param>
        public KeyboardVisibilityChangedEventArgs(CGSize keyboardSize)
        {
            KeyboardSize = keyboardSize;
        }

        /// <summary>
        /// Gets the size of the keyboard.
        /// </summary>
        public CGSize KeyboardSize { get; }
    }
}
