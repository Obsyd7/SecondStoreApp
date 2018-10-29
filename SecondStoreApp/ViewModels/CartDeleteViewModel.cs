using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondStoreApp.ViewModels
{
    public class CartDeleteViewModel
    {
        public decimal CartTotalCost { get; set; }
        public int CartItemNumber { get; set; }
        public int DeletedItemNumber { get; set; }
        public int DeletedItemId { get; set; }
    }
}