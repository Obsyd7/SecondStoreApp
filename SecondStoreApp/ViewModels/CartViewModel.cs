using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondStoreApp.Models;

namespace SecondStoreApp.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> OrderPosition { get; set; }
        public decimal TotalPrice { get; set; }
    }
}