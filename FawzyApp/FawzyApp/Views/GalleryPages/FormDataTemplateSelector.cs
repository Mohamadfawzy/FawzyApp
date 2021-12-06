using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace FawzyApp.Views.GalleryPages
{
    public class FormDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FormEmpty { get; set; }
        public DataTemplate Form0 { get; set; }
        public DataTemplate Form1 { get; set; }
        public DataTemplate Form2 { get; set; }
        public DataTemplate Form3 { get; set; }
        public DataTemplate Form4 { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //return ((FormModel)item).Position == 0 ? Form0 : Form1;
            switch (((FormModel)item).Position)
            {
                case 0:
                    return Form0;
                case 1:
                    return Form1;
                case 2:
                    return Form2;
                case 3:
                    return Form3;
            }
            return FormEmpty;
        }
    }
}
