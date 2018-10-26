using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondStoreApp.Models
{
    public class CartItem
    {
        public Course Course { get; set; }
        public int Number { get; set; }
        public decimal Value { get; set; }
    }
}