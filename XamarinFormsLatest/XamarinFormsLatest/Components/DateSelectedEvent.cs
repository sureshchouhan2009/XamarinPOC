using System;

namespace XamarinFormsLatest.Components
{
    public class DateSelectedEvent:EventArgs
    {
        public DateTime selectedDate { get; set; }

        public DateSelectedEvent(DateTime selectedDateargs)
        {
            selectedDate = selectedDateargs;
        }
    }
}