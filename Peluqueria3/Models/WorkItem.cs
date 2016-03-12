using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Peluqueria3.Models
{
    public class WorkItem
    {
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("Name")]
        public String name { get; set; }

        [DisplayName("Price")]
        public double price { get; set; }

        [DisplayName("Task Duration")]
        public int duration { get; set; }

        public virtual ICollection<Appointment> appointments { get; set; }
    }
}