using FawzyApp.Services.RequestProvider;
using FawzyApp.ViewModels;
using FawzyShared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FawzyApp.ViewModels.ProductVM
{
    public class ProductsPageVM : BaseViewModel
    {
        private readonly IRequestProvider requestProvider;
        private int skip = 0;
        private int take = 10;
        public ObservableCollection<Product> Products { get; set; }
        public ICommand RemainingItemsCommand => new Command(GetProducts);
        public ProductsPageVM()
        {
            Products = new ObservableCollection<Product>();
            requestProvider = DependencyService.Get<IRequestProvider>();
            GetProducts();

        }



        private async void GetProducts()
        {
            // http://192.168.99.13:5005/api/Products/getRange/0/10
            var fullPath = Path.Combine("Products/getRange", skip.ToString(), take.ToString());

            var result = await requestProvider.GetListAsync<List<Product>>(fullPath);
            result.OrderBy(p=>p.Title);
            foreach(var item in result)
            {
                Products.Add(item);
            }
            skip += 10;
            //OnPropertyChanged("Products");
        }


    }
}
