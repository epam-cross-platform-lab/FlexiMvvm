using System;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using Foundation;
using Sample.iOS.Themes;
using UIKit;

namespace Sample.iOS.Views
{
    public class LanguagesView : LayoutView
    {
        private Action<string> _onLanguageSelected;

        public LanguagesView(Action<string> onLanguageSelected)
        {
            _onLanguageSelected = onLanguageSelected;
        }

        public UITableView Languages { get; private set; } 

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = Theme.Colors.BackgroundColor;

            Languages = new UITableView();
            Languages.Source = new LanguagesTableViewSource(new string[] { "English", "Español" }, _onLanguageSelected);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            AddSubview(Languages);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                Languages.AtLeftOf(this, Theme.Dimensions.Inset2x),
                Languages.AtTopOfSafeArea(this, Theme.Dimensions.Inset2x),
                Languages.AtRightOf(this, Theme.Dimensions.Inset2x),
                Languages.AtBottomOfSafeArea(this, Theme.Dimensions.Inset2x));
        }
    }

    public class LanguagesTableViewSource : UITableViewSource
    {
        private const string CellIdentifier = "TableCell";
        private string[] _tableItems;
        private Action<string> _onTap;

        public LanguagesTableViewSource(string[] items, Action<string> onTap)
        {
            _tableItems = items;
            _onTap = onTap;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _tableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = _tableItems[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

            cell.TextLabel.Text = item;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _onTap?.Invoke(_tableItems[indexPath.Row]);
        }
    }
}
