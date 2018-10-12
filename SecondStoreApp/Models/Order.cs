using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondStoreApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }
        public OrderState OrderState { get; set; }
        public decimal OrderValue { get; set; }

        public List<OrderPosition> OrderPosition { get; set; }
    }

    public enum OrderState
    {
        NewOrder,
        OrderFulfilled

    }
}