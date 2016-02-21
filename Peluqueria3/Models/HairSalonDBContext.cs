using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Peluqueria3.Models
{
    public class HairSalonDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Appointment_WorkItem> Appointments_WorkItems { get; set; }
    }
}