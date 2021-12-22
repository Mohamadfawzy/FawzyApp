using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FawzyApp.Interfaces
{
    public interface ITextEditor
    {
        void SetBold(View view, int start, int end);
    }
}
