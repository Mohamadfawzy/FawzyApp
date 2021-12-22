using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FawzyApp.Controllers
{
    public class CustomEntry : Entry
    {
        #region BindableProperty
        public static readonly BindableProperty IsPresentedProperty =
            BindableProperty.Create(
                nameof(IsPresented),
                typeof(bool),
                typeof(CustomEntry),
                false,
                BindingMode.TwoWay,
                null);
        #endregion
        public bool IsPresented
        {
            get => (bool)GetValue(IsPresentedProperty);
            set
            {
                bool old = IsPresented;
                SetValue(IsPresentedProperty, value);
                if (!value) //false
                {
                   //
                }
                else // true
                {
                    //
                }
            }
        }

    }
}
