using System;
using UIKit;

namespace Sample.iOS.Themes
{
    internal static class Theme
    {
        public static UILabel AsRegularBodyStyle(this UILabel label, string text = null)
        {
            label.TextColor = Colors.LabelBodyColor;
            label.Lines = 1;
            label.LineBreakMode = UILineBreakMode.Clip;
            label.TextAlignment = UITextAlignment.Natural;
            label.Text = text;
            label.Font = UIFont.SystemFontOfSize(14);

            return label;
        }

        public static UILabel AsEmphasizedBodyStyle(this UILabel label, string text = null)
        {
            label.TextColor = Colors.ForegroundColor;
            label.Lines = 1;
            label.LineBreakMode = UILineBreakMode.Clip;
            label.TextAlignment = UITextAlignment.Natural;
            label.Text = text;
            label.Font = UIFont.SystemFontOfSize(16);

            return label;
        }

        public static UITextField AsTextFieldStyle(this UITextField textField, string placeHolder = null)
        {
            textField.Placeholder = placeHolder;
            textField.TintColor = Colors.TintColor;

            return textField;
        }

        public static UIButton AsRegularButtonStyle(this UIButton button, string title = null)
        {
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(Colors.ButtonColor, UIControlState.Normal);
            button.Layer.MasksToBounds = true;

            return button;
        }

        public static class Colors
        {
            public static readonly UIColor ForegroundColor = UIColor.DarkTextColor;
            public static readonly UIColor BackgroundColor = UIColor.White;
            public static readonly UIColor LabelBodyColor = UIColor.LightGray;
            public static readonly UIColor TintColor = UIColor.DarkGray;
            public static readonly UIColor ButtonColor = UIColor.Blue;
        }

        public static class Dimensions
        {
            public static readonly nfloat LabelBodyHeight = 18;
            public static readonly nfloat TextFieldRegularHeight = 36;
            public static readonly nfloat ButtonRegularHeight = 20;

            public static readonly nfloat Inset1x = 8;
            public static readonly nfloat Inset2x = 16;
            public static readonly nfloat Inset3x = 24;
            public static readonly nfloat Inset6x = 48;
        }
    }
}
