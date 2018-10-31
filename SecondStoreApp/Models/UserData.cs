using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondStoreApp.Models
{
    public class UserData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Wrong phone number format")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Wrong e-mail format.")]
        public string Email { get; set; }
    }
}