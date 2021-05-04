using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormsLatest.CustomControls;
using XamarinFormsLatest.iOS.CustomRenderer;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]

namespace XamarinFormsLatest.iOS.CustomRenderer
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        //public static void Init() { }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);

                if (Control != null)
                {
                    Control.Layer.BorderWidth = 0;
                    Control.BorderStyle = UITextBorderStyle.None;
                    UITextField textField = Control;
                    // No auto-correct
                    textField.AutocorrectionType = UITextAutocorrectionType.No;
                    textField.SpellCheckingType = UITextSpellCheckingType.No;
                    textField.AutocapitalizationType = UITextAutocapitalizationType.None;

                    // Misc.
                    textField.ClearButtonMode = UITextFieldViewMode.Never;
                    textField.ClearsOnBeginEditing = false;
                    textField.ClearsOnInsertion = false;
                    textField.AdjustsFontSizeToFitWidth = false;
                    textField.KeyboardAppearance = UIKeyboardAppearance.Default;
                }
            }
            catch
            {

            }
        }
    }
}