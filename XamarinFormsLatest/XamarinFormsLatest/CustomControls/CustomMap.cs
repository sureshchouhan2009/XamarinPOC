using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace XamarinFormsLatest.CustomControls
{
   public class CustomMap :Map
    {
        public List<CustomPin> customPins { get; set; }
    }
}
