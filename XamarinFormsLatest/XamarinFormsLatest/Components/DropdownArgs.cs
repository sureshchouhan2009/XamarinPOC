using System;
using XamarinFormsLatest.Model;

namespace XamarinFormsLatest.Components
{
    public class DropdownArgs : EventArgs
    {
        public DropDownItem SelectedItem { get; set; }
        public DropdownArgs(DropDownItem Item)
        {
            SelectedItem = Item;
        }
    }
}