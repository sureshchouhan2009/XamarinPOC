using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormsLatest.Behaviors;

[assembly: ResolutionGroupName("XamarinFormsLatest")]
[assembly: ExportEffect(typeof(ShowHidePassEffect), "ShowHidePassEffect")]
namespace XamarinFormsLatest.iOS.CustomRenderer
{
    public class ShowHidePassEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }
        protected override void OnDetached()
        {
        }
        private void ConfigureControl()
        {
            if (Control != null)
            {
                UITextField vUpdatedEntry = (UITextField)Control;
                var buttonRect = UIButton.FromType(UIButtonType.Custom);
                buttonRect.SetImage(new UIImage("eye_close"), UIControlState.Normal);
                buttonRect.TouchUpInside += (object sender, EventArgs e1) =>
                {
                    if (vUpdatedEntry.SecureTextEntry)
                    {
                        vUpdatedEntry.SecureTextEntry = false;
                        buttonRect.SetImage(new UIImage("eye_open"), UIControlState.Normal);//chnage icon
                    }
                    else
                    {
                        vUpdatedEntry.SecureTextEntry = true;
                        buttonRect.SetImage(new UIImage("eye_close"), UIControlState.Normal);//chnage icon
                    }
                };
                vUpdatedEntry.ShouldChangeCharacters += (textField, range, replacementString) =>
                {
                    string text = vUpdatedEntry.Text;
                    var result = text.Substring(0, (int)range.Location) + replacementString + text.Substring((int)range.Location + (int)range.Length);
                    vUpdatedEntry.Text = result;
                    return false;
                };
                buttonRect.Frame = new CoreGraphics.CGRect(5.0f, -4.0f, 25.0f, 25.0f);
                buttonRect.ContentMode = UIViewContentMode.Right;
                UIView paddingViewRight = new UIView(new System.Drawing.RectangleF(5.0f, -15.0f, 40.0f, 18.0f));
                paddingViewRight.Add(buttonRect);
                paddingViewRight.ContentMode = UIViewContentMode.BottomRight;
                vUpdatedEntry.RightView = paddingViewRight;
                vUpdatedEntry.RightViewMode = UITextFieldViewMode.Always;
                Control.Layer.CornerRadius = 4;
                Control.Layer.BorderColor = new CoreGraphics.CGColor(255, 255, 255);
                Control.Layer.MasksToBounds = true;
                vUpdatedEntry.TextAlignment = UITextAlignment.Left;
            }
        }
    }
}