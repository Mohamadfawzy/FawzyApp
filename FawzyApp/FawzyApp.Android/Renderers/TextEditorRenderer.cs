using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using FawzyApp.Controllers;
using FawzyApp.Droid.Renderers;
using FawzyApp.Interfaces;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(TextEditorRenderer))]
namespace FawzyApp.Droid.Renderers
{
    public class TextEditorRenderer : ITextEditor
    {
        FormsEditText Control;
        SpannableStringBuilder span;
        public TextEditorRenderer()
        {
            span = new SpannableStringBuilder();
            
            span.Append(CustomEntryRenderer.entryContext.Text);
        }

        public void SetBold(Xamarin.Forms.View view, int start, int end)
        {
            Control = CustomEntryRenderer.entryContext;
            // var Control = view as CustomEntry;

            //Control.Text = "her your text format";
            //span. = new SpannableStringBuilder(Control.Text);
            //span.Append(Control.Text);
            StyleSpan style = new StyleSpan(TypefaceStyle.Bold);
            span.SetSpan(new ForegroundColorSpan(Android.Graphics.Color.Blue), start, end, 0);
            span.SetSpan(style, start, end, SpanTypes.ExclusiveExclusive);

            Control.SetText(span, TextView.BufferType.Spannable);

        }

        private void stripUnderlines(TextView textView)
        {
            FormattedString formattedString = new FormattedString();

            var builder = new StringBuilder();
            foreach (Span span in formattedString.Spans)
            {
                if (span.Text == null)
                    continue;

                builder.Append(span.Text);
            }

           
        }
    }
}