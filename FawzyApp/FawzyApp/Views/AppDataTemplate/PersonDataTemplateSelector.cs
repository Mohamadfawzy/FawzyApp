using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FawzyApp.Views.AppDataTemplate
{
    public class PersonDataTemplateSelector : DataTemplateSelector
    {
		public DataTemplate ValidTemplate { get; set; }

		public DataTemplate InvalidTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return ((Person)item).DateOfBirth.Year >= 1980 ? ValidTemplate : InvalidTemplate;
		}
	}
}
