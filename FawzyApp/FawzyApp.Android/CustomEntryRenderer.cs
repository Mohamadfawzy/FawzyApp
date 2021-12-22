using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using FawzyApp.Controllers;
using FawzyApp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace FawzyApp.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public static FormsEditText entryContext;
        public CustomEntryRenderer(Context context) : base(context)
        {
        } // end constructor
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
            //Control.Text = "her your text format";
            //var s = new SpannableStringBuilder(Control.Text);
            //StyleSpan style = new StyleSpan(TypefaceStyle.Bold);
            //s.SetSpan(style,0,5,SpanTypes.Composing);

            //Control.SetText(s, TextView.BufferType.Spannable);

            //Control.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Italic);
            // dismiss the keyboard 
            // inputmethodmanager imm = (inputmethodmanager)this.context.getsystemservice(context.inputmethodservice);
            //imm.hidesoftinputfromwindow(this.control.windowtoken, 0);

            // this is hs hgt hvhkl hasth sdfgjh  is friv vy

            entryContext = Control;
        }

    }
}