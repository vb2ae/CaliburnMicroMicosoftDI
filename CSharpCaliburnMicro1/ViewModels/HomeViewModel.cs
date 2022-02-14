using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpCaliburnMicro1.Models;

namespace CSharpCaliburnMicro1.ViewModels
{
    public class HomeViewModel : Screen
    {
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyOfPropertyChange("Title");
            }
        }

        private ProductDataContext db;
        private BindableCollection<Product> _products;

        public HomeViewModel(ProductDataContext context)
        {
            Title = "Welcome to Caliburn.Micro";
            db = context;
            var prods = db.Products.ToList();
            Products = new BindableCollection<Product>();
            Products.AddRange(prods);
        }

        public BindableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyOfPropertyChange("Products");
            }
        }
    }
}

