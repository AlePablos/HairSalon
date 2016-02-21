namespace Peluqueria3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Peluqueria3.Models.HairSalonDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Peluqueria3.Models.HairSalonDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(i => i.email,

                new Models.User
                {
                    ID = 0,
                    firstName = "Alejandro",
                    lastName = "Pablos",
                    phone = "291 5034232",
                    sex = true,
                    email = "alepablos@gmail.com",
                    password = "root",
                    isAdmin = true,
                    lastLogged = DateTime.Parse("1-1-2016")
                }
               
            );

            context.WorkItems.AddOrUpdate(i => i.name,

                new Models.WorkItem
                {
                    ID = 0,
                    name = "Corte",
                    price = 60.89,
                    duration = 30
                },

                new Models.WorkItem
                {
                    ID = 1,
                    name = "Peinado",
                    price = 70,
                    duration = 45
                },

                new Models.WorkItem
                {
                    ID = 3,
                    name = "Tintura",
                    price = 100.50,
                    duration = 60
                }

            );

            context.Appointments.AddOrUpdate(i => i.startTime);
        }
    }
}
