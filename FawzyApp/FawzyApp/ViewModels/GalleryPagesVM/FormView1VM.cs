using FawzyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using FawzyApp.ViewModels;

namespace FawzyApp.ViewModels.GalleryPagesVM
{
    public class FormView1VM : BaseViewModel
    {

        public ObservableCollection<Item> Items { get; set; }
        private List<Item> items = new List<Item>()
        {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },

                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
        };

        public FormView1VM()
        {
            GenerateItems();
        }

        private void GenerateItems()
        {
            Items = new ObservableCollection<Item>();
            foreach (var item in items)
            {
                Items.Add(item);
            }
            //OnPropertyChanged("Items");
        }

    }
}
