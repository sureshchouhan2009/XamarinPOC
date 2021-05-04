using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsLatest.Model;

namespace XamarinFormsLatest.Components
{
    public partial class DropDownComponent : ContentView
    {
        public static readonly BindableProperty DropDownTextProperty =
          BindableProperty.Create(nameof(DropDownText), typeof(string), typeof(DropDownComponent), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
          {
              var bind = (DropDownComponent)bindable;
              if (newval != null)
              {
                  var Title = (string)newval;
                  if (!string.IsNullOrEmpty(Title))
                  {
                      bind.Title.Text = Title;
                      bind.lblPlaceholder.IsVisible = Title != bind.lblPlaceholder.Text;
                  }
                  else
                  {
                      bind.Title.Text = bind.lblPlaceholder.Text;
                      bind.lblPlaceholder.IsVisible = false;
                  }
              }

          });

        public event EventHandler<DropdownArgs> ItemSelected;
        public string DropDownText
        {
            get { return (string)GetValue(DropDownTextProperty); }
            set { SetValue(DropDownTextProperty, value); }
        }


        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }
        public static readonly BindableProperty EnabledProperty =
            BindableProperty.Create(nameof(Enabled), typeof(bool), typeof(DropDownComponent), defaultValue: true, defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
            {
                var bind = (DropDownComponent)bindable;
                if (newval != null)
                {
                    bool enable = (bool)newval;
                   // bind.InnFrame.BackgroundColor = enable ? bind.DropDownBackGroundColor : Color.FromHex(AppContent.DisableColor);
                    //bind.Title.BackgroundColor = enable ? bind.DropDownBackGroundColor : Color.FromHex(AppContent.DisableColor);
                    bind.IsEnabled = enable;
                }

            });

        public List<DropDownItem> ItemSource
        {
            get { return (List<DropDownItem>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }
        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(nameof(ItemSource), typeof(List<DropDownItem>), typeof(DropDownComponent), defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty DropDownBackGroundColorProperty =
         BindableProperty.Create(nameof(DropDownBackGroundColor), typeof(Color), typeof(DropDownComponent), defaultValue: Color.Transparent, defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
         {
             if (bindable is DropDownComponent bind && newval != null)
             {

                 if (newval is Color BG && bind?.InnFrame!=null)
                 {
                     bind.InnFrame.BackgroundColor = BG;
                 }
             }

         });

        public Color DropDownBackGroundColor
        {
            get { return (Color)GetValue(DropDownBackGroundColorProperty); }
            set { SetValue(DropDownBackGroundColorProperty, value); }
        }
        public static BindableProperty DropDownPlaceholderProperty = BindableProperty.Create(nameof(DropDownPlaceholder), typeof(string), typeof(DropDownComponent), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            try
            {
                if (bindable is DropDownComponent bind && newval != null)
                {
                    if (newval is string str && bind?.lblPlaceholder!= null)
                    {
                        bind.lblPlaceholder.Text = str;
                    }
                }
            }
            catch { }
        });
        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(DropDownComponent), defaultBindingMode: BindingMode.TwoWay, defaultValue: Color.Transparent, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                if (bindable is DropDownComponent bind && bind?.InnFrame != null)
                    bind.UpdateComponentSettings();
            }
            catch
            { }
        });
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(DropDownComponent), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            try
            {
                if (bindable is DropDownComponent bind && bind?.InnFrame  != null)
                    bind.UpdateComponentSettings();
            }
            catch { }
        });
        public static BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(DropDownComponent), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            try
            {
                if (bindable is DropDownComponent bind && bind?.InnFrame != null)
                    bind.UpdateComponentSettings();
            }
            catch
            { }
        });
        public static BindableProperty LabelPlaceHolderTextSizeProperty = BindableProperty.Create(nameof(LabelPlaceHolderTextSizeProperty), typeof(double), typeof(FloatingEntry), 10.0, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                if (bindable is DropDownComponent bind && bind?.lblPlaceholder != null)
                    bind.UpdateComponentSettings();
            }
            catch { }
        });
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }
        public string DropDownPlaceholder
        {
            get
            {
                return (string)GetValue(DropDownPlaceholderProperty);
            }
            set
            {
                SetValue(DropDownPlaceholderProperty, value);
            }
        }
        public int CornerRadius
        {
            get
            {
                return (int)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
        public int BorderWidth
        {
            get
            {
                return (int)GetValue(BorderWidthProperty);
            }
            set
            {
                SetValue(BorderWidthProperty, value);
            }
        }
        [TypeConverter(typeof(FontSizeConverter))]
        public double LabelPlaceHolderTextSize
        {
            get
            {
                return (double)GetValue(LabelPlaceHolderTextSizeProperty);
            }
            set
            {
                SetValue(LabelPlaceHolderTextSizeProperty, value);
            }
        }

        public DropDownComponent()
        {
            InitializeComponent();
            UpdateComponentSettings();
        }

        public async void DropdownClicked(object sender, EventArgs e)
        {
            try
            {
                //DropdownView DDC = new DropdownView(ItemSource, DropDownPlaceholder);
                //DDC.Close += (s, args) =>
                //{
                //    if (args is DropDownItem Item)
                //    {
                //        Device.BeginInvokeOnMainThread(() =>
                //        {
                //            ItemSelected(null, new DropdownArgs(Item));
                //        });
                //    }
                //};
                //await PopupNavigation.Instance.PushAsync(DDC);
            }
            catch
            { }
        }
        public void UpdateComponentSettings()
        {
            try
            {

                OutFrame.BackgroundColor = BorderColor;
                lblPlaceholder.TextColor = BorderColor;
                OutFrame.CornerRadius = CornerRadius;
                InnFrame.CornerRadius = CornerRadius;
                lblPlaceholder.Text = DropDownPlaceholder;
                Title.BackgroundColor = BackgroundColor;
                ContainerGrid.BackgroundColor = BackgroundColor;
                InnFrame.BackgroundColor = BackgroundColor;
                lblPlaceholder.FontSize = LabelPlaceHolderTextSize;
                InnFrame.Margin = new Thickness(BorderWidth);
                lblPlaceholder.IsVisible = DropDownText != DropDownPlaceholder;
            }
            catch
            {

            }
        }
    }
}