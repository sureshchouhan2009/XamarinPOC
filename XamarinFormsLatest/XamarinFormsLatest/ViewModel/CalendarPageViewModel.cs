using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinFormsLatest.ViewModel
{
    public class CalendarPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        private DateTime _selectedDate;
        public DateTime SelectedDate 
        {
            get { return _selectedDate; }
            set 
            {
                _selectedDate = value;
                var args = new PropertyChangedEventArgs(nameof(_selectedDate));
                PropertyChanged?.Invoke(this, args);
            }
        }
         private string textfromVM ="Default Text";
        public string TextfromVM
        {
            get { return textfromVM; }
            set 
            {
                textfromVM = value;
                var args = new PropertyChangedEventArgs(nameof(_selectedDate));
                PropertyChanged.Invoke(this, args);
            }
        }

        public CalendarPageViewModel()
        {
            SelectedDate = DateTime.Now.AddDays(5);


        }
    }
}
