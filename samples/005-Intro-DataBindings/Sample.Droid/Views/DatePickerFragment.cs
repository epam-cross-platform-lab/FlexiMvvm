using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace FlexiMvvm.Views
{
    public class DatePickerFragment : AppCompatDialogFragment, DatePickerDialog.IOnDateSetListener
    {
        private readonly DateTime _initialDate;
        private Action<DateTime> _onDatePicked;

        public DatePickerFragment()
        {
        }

        public DatePickerFragment(Action<DateTime> onDatePicked, DateTime initialDate)
        {
            _initialDate = initialDate;
            _onDatePicked = onDatePicked;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            return new DatePickerDialog(Context, this, _initialDate.Year, _initialDate.Month, _initialDate.Day);
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            // monthOfYear = 0..11
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            _onDatePicked?.Invoke(selectedDate);
        }
    }
}
