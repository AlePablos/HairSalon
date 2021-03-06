﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Start Time")]
        public DateTime startTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Time")]
        public DateTime endTime { get; set; }

        [ForeignKey ("User")]
        [DisplayName("User")]
        public int userID { get; set; }

        [DisplayName("Status")]
        public Status status { get; set; } 

        [DisplayName("Work Items")]
        public virtual ICollection<WorkItem> workItems { get; set; }

        public virtual User User { get; set; }
    }

    public enum Status
    {
        Waiting = 0,
        InProgres = 1,
        Finished = 2
    }
}