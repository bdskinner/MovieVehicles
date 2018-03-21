namespace MovieVehicles.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieVehicles.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MovieVehicles.Models.ApplicationDbContext context)
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


            //Vehicle Information.
            context.Vehicles.AddOrUpdate(v => v.VehicleName,
                new Models.Vehicle()
                {
                    VehicleName = "Greek Fire",
                    Description = "This modified version of a ford fiesta took John Velis on his big adventure through Empire, MI",
                    CreatedBy = "John E. Velis",
                    DateCreated = new DateTime(2010, 3, 1),
                    MovieTitle = "Johnny Vs Big Adventure",
                    MoviePoster = "C:\\johnvadv.jpg",
                    Status = "Housed in the Empire Movie Vehicle Museum."
                },

                new Models.Vehicle()
                {
                    VehicleName = "Zeus's Chariot",
                    Description = "This modified version of a 1986 ford pinto took John Velis on his big adventure through Cedar, MI",
                    CreatedBy = "John E. Velis",
                    DateCreated = new DateTime(2012, 3, 3),
                    MovieTitle = "Johnny Vs Big Adventure: Johnny Goes East",
                    MoviePoster = "C:\\johnvadv2.jpg",
                    Status = "Housed in the Empire Movie Vehicle Museum."
                },

                new Models.Vehicle()
                {
                    VehicleName = "Athens Arrow",
                    Description = "This modified version of a 1989 Mini Cooper took John Velis on his biggest adventure ever to Traverse City, MI",
                    CreatedBy = "John E. Velis",
                    DateCreated = new DateTime(2014, 5, 3),
                    MovieTitle = "Johnny Vs Big Adventure: Ride Johnny Ride",
                    MoviePoster = "C:\\johnvadv3.jpg",
                    Status = "Housed in the Empire Movie Vehicle Museum."
                }
            );

            //Event Information.
            context.Events.AddOrUpdate(ev => ev.EventTitle,
                new Models.Event()
                {
                    EventTitle = "Greek Fire on Display",
                    EventDescription = "The movie car Greek Fire will be displayed at Hagerty Insurance.",
                    EventDate = new DateTime(2018, 4, 1),
                    EventCity = "Traverse City",
                    EventState = "MI",
                    VehicleID = 1
                },

                new Models.Event()
                {
                    EventTitle = "John Velis Greek Fire Q & A",
                    EventDescription = "John Velis will answer questions about creating and using the car Greek Fire in Johnny Vs Big Adventure.",
                    EventDate = new DateTime(2018, 4, 2),
                    EventCity = "Traverse City",
                    EventState = "MI",
                    VehicleID = 1
                },

                new Models.Event()
                {
                    EventTitle = "Battle of the Movie Cars",
                    EventDescription = "Various famous movie vehicles (including Greek Fire) will race at NMCs Elm Parking lot.",
                    EventDate = new DateTime(2018, 4, 4),
                    EventCity = "Traverse City",
                    EventState = "MI",
                    VehicleID = 1
                }
            );

            //Review Information
            context.Reviews.AddOrUpdate(r => r.ReviewTitle,
                new Models.Review()
                {
                    ReviewTitle= "Totally Cool",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 1, 3),
                    ReviewText = "Greek Fire is a totally rad car!!  It was worth paying Johnny V. the $150 to see it.",
                    VehicleID = 1
                },

                new Models.Review()
                {
                    ReviewTitle = "Just OK",
                    FirstName = "Luke",
                    LastName = "Warmwater",
                    ReviewDate = new DateTime(2018, 1, 5),
                    ReviewText = "I thought the care would be more stylish",
                    VehicleID = 1
                },

                new Models.Review()
                {
                    ReviewTitle = "Worth the Trip",
                    FirstName = "Izzy",
                    LastName = "Deadyet",
                    ReviewDate = new DateTime(2018, 1, 7),
                    ReviewText = "The Arrow was pretty cool.  Although I thought John Velis would be taller.",
                    VehicleID = 3
                }
            );
        }
    }
}
