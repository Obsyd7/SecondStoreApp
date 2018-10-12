using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondStoreApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please, enter first name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, enter last name ")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, enter the street")]
        [StringLength(100)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please, enter the city")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please, enter the postcard")]
        [StringLength(20)]
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