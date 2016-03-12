using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peluqueria3.Controllers
{
    public class AppointmentWithWorkItems
    {
        public int id { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public int user { get; set; }

        public List<int?> workItems { get; set; }
    }
}