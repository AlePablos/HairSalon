using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Peluqueria3.Models
{
    public class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        public String firstName { get; set; }

        [StringLength (50)]
        public String lastName { get; set; }

        [StringLength(15)]
        public String phone { get; set; }

        public bool sex { get; set; }  //1: male  0: female

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "The password is requered")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string password { get; set; }

        public bool isAdmin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime lastLogged { get; set; }

    }
}