using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Peluqueria3.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime startTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime endTime { get; set; }

        [ForeignKey ("User")]
        public int userID { get; set; }



        public virtual User User { get; set; }
    }
}