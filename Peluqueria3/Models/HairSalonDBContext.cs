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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                        .HasMany<WorkItem>(s => s.workItems)
                        .WithMany(c => c.appointments)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("AppointmentRefId");
                            cs.MapRightKey("WorkItemRefId");
                            cs.ToTable("WorkItemAppointments");
                        });

        }
    }
}