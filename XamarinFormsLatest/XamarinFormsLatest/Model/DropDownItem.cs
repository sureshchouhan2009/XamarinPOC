using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsLatest.Model
{
    public class DropDownItem
    {
        public int ID { get; set; } = 0;
        public string ItemName { get; set; } = string.Empty;
        public object Item { get; set; } = new object();
    }
}
