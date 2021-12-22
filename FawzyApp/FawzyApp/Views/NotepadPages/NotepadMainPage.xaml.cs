using FawzyApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FawzyApp.Views.NotepadPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotepadMainPage : ContentPage
    {
        public NotepadMainPage()
        {
            InitializeComponent();
        }

        private void MyEntry_Focused(object sender, FocusEventArgs e)
        {
            //Dispatcher.BeginInvokeOnMainThread(() =>
            //{
            //    MyEntry.CursorPosition = 0;
            //    MyEntry.SelectionLength = MyEntry.Text != null ? MyEntry.Text.Length : 0;
            //});
            var d = MyCustomEntry.SelectionLength;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var status = DependencyService.Get<ITextEditor>();
            var cursor = MyCustomEntry.CursorPosition;
            var end = cursor + MyCustomEntry.SelectionLength;
            status.SetBold(MyCustomEntry, MyCustomEntry.CursorPosition, end);
            MyCustomEntry.CursorPosition =  cursor;

            label.Text ="length: " + MyCustomEntry.SelectionLength.ToString() + "cursor: " + MyCustomEntry.CursorPosition;
           
        }
    }
}