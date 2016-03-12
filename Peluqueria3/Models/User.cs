using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Peluqueria3.Models
{
    public class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("First name")]
        public String firstName { get; set; }

        [StringLength (50)]
        [DisplayName("Last name")]
        public String lastName { get; set; }

        [StringLength(15)]
        [DisplayName("Phone")]
        public String phone { get; set; }

        [DisplayName("Sex")]
        public Sex sex { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "The password is requered")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [DisplayName("Password")]
        public string password { get; set; }

        [DisplayName("Is Admin?")]
        public bool isAdmin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Last logged")]
        public DateTime lastLogged { get; set; }
    }

    public enum Sex
    {
        Male = 1, Female = 2
    }
}