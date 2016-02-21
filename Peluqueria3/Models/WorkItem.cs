using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Peluqueria3.Models
{
    public class WorkItem
    {
        public int ID { get; set; }

        [StringLength(50)]
        public String name { get; set; }

        public double price { get; set; }

        public int duration { get; set; }
    }
}