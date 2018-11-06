using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Postal;
using SecondStoreApp.Models;

namespace SecondStoreApp.ViewModels
{
    public class OrderConfirmationEmail : Email
    {

        public string To { get; set; }
        public string From { get; set; }
        public decimal Value { get; set; }
        public int OrderNumber { get; set; }
        public string ImgPath { get; set; }
        public List<OrderPosition> OrderPosition { get; set; }


        public class OrderCompletedEmail : Email
        {
            public string To { get; set; }
            public string From { get; set; }
            public int OrderNumber { get; set; }
        }
    }
}
