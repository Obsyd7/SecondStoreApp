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

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Please, enter first name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, enter last name ")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, enter the street")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please, enter the city")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please, enter the postcard")]
        [StringLength(6)]
        public string Postcode { get; set; }


        [Required(ErrorMessage = "Please, enter your phone number.")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
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