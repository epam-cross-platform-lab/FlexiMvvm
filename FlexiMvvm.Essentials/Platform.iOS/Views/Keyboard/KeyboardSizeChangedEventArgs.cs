using System;
using CoreGraphics;

namespace FlexiMvvm.Views.Keyboard
{
    public class KeyboardSizeChangedEventArgs : EventArgs
    {
        public KeyboardSizeChangedEventArgs(CGSize keyboardSize)
        {
            KeyboardSize = keyboardSize;
        }

        public CGSize KeyboardSize { get; }
    }
}
