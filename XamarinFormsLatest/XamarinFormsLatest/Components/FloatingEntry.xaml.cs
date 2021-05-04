using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsLatest.Behaviors;
using XamarinFormsLatest.Model;

namespace XamarinFormsLatest.Components
{
    public partial class FloatingEntry : ContentView
    {
        #region Events
        public event EventHandler<FocusEventArgs> EntryFocused;
        public event EventHandler<FocusEventArgs> EntryUnfocused;
        public event EventHandler<TextChangedEventArgs> TextChanged;
        #endregion


        #region Bindable Properties
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                FEntry.EntryField.Placeholder = (string)newval;
                if (FEntry?.lblPlaceholder != null)
                    FEntry.UpdateComponentSettings();
            }
            catch { }
        });
        public static BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                FEntry.EntryField.HorizontalTextAlignment = (TextAlignment)newval;
            }
            catch { }
        });
        public static BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                FEntry.EntryField.MaxLength = Convert.ToInt32(newval);
            }
            catch { }
        });
        public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var FEntry = (FloatingEntry)bindable;
            try
            {
                if (FEntry?.EntryField != null)
                    FEntry.EntryField.FontSize = Convert.ToDouble(newval);
            }
            catch { }
        });
        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FloatingEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                bool value = (bool)newVal;
                if (value)
                    FEntry.EntryField.Effects.Add(new ShowHidePassEffect());
                FEntry.EntryField.IsPassword = value;
            }
            catch { }
        });
        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(FloatingEntry), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                FEntry.EntryField.Keyboard = (Keyboard)newVal;
            }
            catch { }
        });

        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColorProperty), typeof(Color), typeof(FloatingEntry), defaultValue: Color.Gray, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                if (FEntry?.EntryField != null)
                    FEntry.UpdateComponentSettings();
            }
            catch
            { }
        });
        public static new BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColorProperty), typeof(Color), typeof(FloatingEntry), Color.Transparent, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                if (FEntry?.OutFrame != null)
                    FEntry.UpdateComponentSettings();
            }
            catch { }
        });
        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(FloatingEntry), Color.Black, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                FEntry.EntryField.TextColor = (Color)newVal;
            }
            catch { }
        });

        public new static BindableProperty IsFocusedProperty = BindableProperty.Create(nameof(IsFocused), typeof(bool), typeof(FloatingEntry), false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                if ((bool)newVal)
                    FEntry.EntryField.Focus();
            }
            catch { }
        });
        public static BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(FloatingEntry), true, propertyChanged: (bindable, oldVal, newVal) =>
        {
            //try
            //{
            //    if (bindable is FloatingEntry FEntry)
            //        FEntry.UpdateColorValid((bool)newVal);
            //}
            //catch { }
        });
        public static BindableProperty LabelPlaceHolderTextSizeProperty = BindableProperty.Create(nameof(LabelPlaceHolderTextSizeProperty), typeof(double), typeof(FloatingEntry), 10.0, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                if (FEntry?.lblPlaceholder != null)
                    FEntry.UpdateComponentSettings();
            }
            catch { }
        });
        public static BindableProperty CompletedProperty = BindableProperty.Create(nameof(Completed), typeof(EventHandler), typeof(FloatingEntry), propertyChanged: (bindable, oldValue, newValue) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                FEntry.Completed = (EventHandler)newValue;
            }
            catch { }
        });

        public static BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var FEntry = (FloatingEntry)bindable;
            try
            {
                if (FEntry?.InnFrame != null)
                    FEntry.UpdateComponentSettings();
            }
            catch
            { }
        });

        public static BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var FEntry = (FloatingEntry)bindable;
            try
            {
                if (FEntry?.InnFrame != null)
                    FEntry.UpdateComponentSettings();
            }
            catch { }
        });

        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, defaultValue: Color.Transparent, propertyChanged: (bindable, oldVal, newVal) =>
        {
            try
            {
                var FEntry = (FloatingEntry)bindable;
                if (FEntry?.InnFrame != null)
                    FEntry.UpdateComponentSettings();
            }
            catch
            { }
        });
        public static BindableProperty TextValidationTypeProperty = BindableProperty.Create(nameof(TextValidationType), typeof(TextValidationType), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, defaultValue: TextValidationType.None);
        #endregion

        #region Public Properties

        public new bool IsFocused
        {
            get
            {
                return (bool)GetValue(IsFocusedProperty);
            }
            set
            {
                SetValue(IsFocusedProperty, value);
            }
        }
        public new Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }
        public TextAlignment HorizontalTextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalTextAlignmentProperty, value);
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

        public Color PlaceholderColor
        {
            get
            {
                return (Color)GetValue(PlaceholderColorProperty);
            }
            set
            {
                SetValue(PlaceholderColorProperty, value);
            }
        }
        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public string MaxLength
        {
            get
            {
                return (string)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }

        public EventHandler Completed
        {
            get => null;
            set => EntryField.Completed += value;
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
        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }

        public TextValidationType TextValidationType
        {
            get
            {
                return (TextValidationType)GetValue(TextValidationTypeProperty);
            }
            set
            {
                SetValue(TextValidationTypeProperty, value);
            }
        }
        #endregion

        public FloatingEntry()
        {
            InitializeComponent();
            EntryField.BindingContext = this;
            //EntryField.TextChanged += (s, a) =>
            //{
            //    try
            //    {
            //        if (!Session.Instance.CheckString(lblPlaceholder.Text))
            //            lblPlaceholder.Text = EntryField.Placeholder;
            //        TextChanged?.Invoke(s, a);
            //        lblPlaceholder.IsVisible = Session.Instance.CheckString(a.NewTextValue);
            //        IsValid = CheckValidation(a.NewTextValue);
            //    }
            //    catch
            //    {

            //    }
            //};

            EntryField.Focused += (s, a) =>
            {
                EntryFocused?.Invoke(this, a);

                //lblPlaceholder.IsVisible = true;
            };
            EntryField.Unfocused += (s, a) =>
            {
                EntryUnfocused?.Invoke(this, a);
               // IsValid = CheckValidation(EntryField.Text);
                //lblPlaceholder.IsVisible = Session.Instance.CheckString(EntryField.Text);
            };
            EntryField.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(EntryField.Text) && !EntryField.IsFocused && !string.IsNullOrEmpty(EntryField.Text))
                {
                    lblPlaceholder.IsVisible = true;
                }
            };
            UpdateComponentSettings();
        }

        public void UpdateComponentSettings()
        {
            try
            {
                OutFrame.BackgroundColor = BorderColor;
                lblPlaceholder.TextColor = BorderColor;
                OutFrame.CornerRadius = CornerRadius;
                InnFrame.CornerRadius = CornerRadius;
                lblPlaceholder.Text = EntryField.Placeholder;
                EntryField.BackgroundColor = BackgroundColor;
                ContainerGrid.BackgroundColor = BackgroundColor;
                InnFrame.BackgroundColor = BackgroundColor;
                lblPlaceholder.FontSize = LabelPlaceHolderTextSize;
                InnFrame.Margin = new Thickness(BorderWidth);
                EntryField.PlaceholderColor = PlaceholderColor;
            }
            catch
            {

            }
        }

        //public void UpdateColorValid(bool valid)
        //{
        //    try
        //    {
        //        if (valid)
        //        {
        //            OutFrame.BackgroundColor = BorderColor;
        //            lblPlaceholder.TextColor = BorderColor;
        //        }
        //        else
        //        {
        //            Color color = Color.FromHex(AppContent.EntryInvalidColor);
        //            OutFrame.BackgroundColor = color;
        //            lblPlaceholder.TextColor = color;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //public bool CheckValidation(string data)
        //{
        //    try
        //    {
        //        if (TextValidationType != TextValidationType.None && Session.Instance.CheckString(data))
        //        {
        //            switch (TextValidationType)
        //            {
        //                case TextValidationType.Email:
        //                    return Session.Instance.CheckEmail(data);
        //                case TextValidationType.INPhone:
        //                    return Session.Instance.CheckINPhoneNumber(data);
        //                case TextValidationType.Number:
        //                    return Session.Instance.CheckNumber(data);
        //                case TextValidationType.Text:
        //                    return Session.Instance.CheckString(data);
        //                case TextValidationType.OnlyText:
        //                    return Session.Instance.CheckString(data, true);
        //                default:
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            return true;
        //        }

        //    }
        //    catch
        //    {

        //    }
        //    return true;
        //}
    }
}