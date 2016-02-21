using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Peluqueria3.Models
{
    public class Appointment_WorkItem
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Appointment")]
        public int appointmentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("WorkItem")]
        public int workItemID { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual WorkItem WorkItem { get; set; }
    }
}