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
                    MovieTitle = "Johnny Vs Big Adventure",
                    MoviePoster = "C:\\johnvadv.jpg",
                    Status = "Housed in the Empire Movie Vehicle Museum.",
                    Make = "Ford",
                    Model = "Fiesta",
                    Year = 1988
                },

                new Models.Vehicle()
                {
                    VehicleName = "Zeus's Chariot",
                    Description = "This modified version of a 1986 ford pinto took John Velis on his big adventure through Cedar, MI",
                    CreatedBy = "John E. Velis",
                    MovieTitle = "Johnny Vs Big Adventure: Johnny Goes East",
                    MoviePoster = "C:\\johnvadv2.jpg",
                    Status = "Housed in the Empire Movie Vehicle Museum.",
                    Make = "Ford",
                    Model = "Pinto",
                    Year = 1986
                },

                new Models.Vehicle()
                {
                    VehicleName = "Athens Arrow",
                    Description = "This modified version of a 1989 Mini Cooper took John Velis on his biggest adventure ever to Traverse City, MI",
                    CreatedBy = "John E. Velis",
                    MovieTitle = "Johnny Vs Big Adventure: Ride Johnny Ride",
                    MoviePoster = "C:\\johnvadv3.jpg",
                    Status = "Housed in the Empire Movie Vehicle Museum.",
                    Make = "Mini",
                    Model = "Cooper",
                    Year = 1989
                },

                // ------------------------------------------------------------------------

                new Models.Vehicle()
                {
                    VehicleName = "Doc Brown's Time Machine",
                    Description = "Doc Brown's Time Machine went through several variations before settling on a stock 1981 Delorean DMC-12 which was modified during production of the first Back to the Future.   movie.  Equipment was added to the back of the vehicle as well as the vents for exhaust.  Switches, circuits, and panels were added to the interior as well for the time travel electronics.",
                    CreatedBy = "Andrew Probert ,Ron Cobb",
                    MovieTitle = "Back to the Future",
                    MoviePoster = "C:\\OriginalDelorean.jpg",
                    Status = "Universal Studios permanently loans the film's iconic DMC-12 to L.A.'s Petersen Automotive Museum. The DeLorean that teleported Michael J. Fox in the first installment of the Back to the Future trilogy was unveiled at an event at the Petersen Automotive Museum in Los Angeles Wednesday evening.",
                    Make = "Delorean",
                    Model = "DMC-12",
                    Year = 1981
                },

                new Models.Vehicle()
                {
                    VehicleName = "Bullitt Mustang",
                    Description = "This stock 1968 Ford Mustang GT390 was driven in the movie by Steve McQueen, including in the famous car chase.",
                    CreatedBy = "Ford Motor Co.",
                    MovieTitle = "Bullitt",
                    MoviePoster = "C:\\BuliittMustang.jpg",
                    Status = "Owned by a private owner (Robert Kiernan Jr.)",
                    Make = "Ford",
                    Model = "Mustang GT390",
                    Year = 1968
                },

                new Models.Vehicle()
                {
                    VehicleName = "Herbie",
                    Description = "This 1963 Volkswagen Beetle, was a character that is featured in several Walt Disney motion pictures starting with the 1968 feature film The Love Bug. He has a mind of his own and is capable of driving himself, and is also a serious contender in auto racing competitions. Throughout most of the franchise, Herbie is distinguished by red, white and blue racing stripes from front to back bumper, a racing-style number 53 on the front luggage compartment lid, doors, and engine lid, and a yellow-on-black '63 California license plate with the registration 'OFP 857'.",
                    CreatedBy = "Volkswagen",
                    MovieTitle = "Herbie the Love Bug",
                    MoviePoster = "C:\\Herbie.jpg",
                    Status = "Housed at the John Staluppi’s  Cars of Dreams Museum",
                    Make = "Volkswagen",
                    Model = "Beetle",
                    Year = 1963
                },

                new Models.Vehicle()
                {
                    VehicleName = "The General Lee",
                    Description = "The General Lee (sometimes referred to as simply 'the General') is the name given to a 1969 Dodge Charger driven in the Dukes of Hazzard movie and television series The Dukes of Hazzard by the Duke.  boys, Bo and Luke.   It is known for its signature horn, its police chases, stunts—especially its long jumps—and for having its doors welded shut, leaving the Dukes to climb in and out through the windows.",
                    CreatedBy = "Dodge",
                    MovieTitle = "The Dukes of Hazzard",
                    MoviePoster = "C:\\General_lee.jpg",
                    Status = "The 18  Dodge Chargers remaining after the series ended were sold to private owners.",
                    Make = "Dodge",
                    Model = "Charger",
                    Year = 1969
                },

                new Models.Vehicle()
                {
                    VehicleName = "The Tumbler",
                    Description = " the Tumbler, a prototype armored tank designed as a bridging vehicle for the military, includes weaponry and the ability to boost into a rampless jump.",
                    CreatedBy = "Nathan Crowley, Christopher Nolan",
                    MovieTitle = "Batman Begins",
                    MoviePoster = "C:\\BaTumbler_HD.jpg",
                    Status = "Unknown",
                    Make = "Unknown",
                    Model = "Unknown",
                    Year = 2005
                },

                new Models.Vehicle()
                {
                    VehicleName = "James Bond?s submersible Lotus",
                    Description = "The Lotus Esprit S1 featured in 'The Spy Who Loved Me' is a 1976 Lotus Esprit S1.  Two Stree legal Esprit S1's were used in the movie as well as several body shells for the underwater scenes.  In the movie the Lotus was not just amphibious, it also contained cannons that spray cement on to pursuing vehicles. It also has wheel arches that turn into fins, a small periscope on the roof enabling 007 to navigate at speed underwater and its other weaponry includes a missile launched from its rear deck, mines, and torpedoes which were all compliments of Q branch.",
                    CreatedBy = "Perry Oceanographic Inc.",
                    MovieTitle = "The Spy Who Loved Me",
                    MoviePoster = "C:\\lotuss1.jpg",
                    Status = "Sold at auction in Sept. 2013 for £550,000 to a private collector.",
                    Make = "Lotus",
                    Model = "S1",
                    Year = 1976
                },

                new Models.Vehicle()
                {
                    VehicleName = "George Barris Batmobile",
                    Description = "Taking approxiately 3 weeks to build the original batmobile was created from a 1955 Lincoln Futura.  This vehicle would be used  was used in the TV series and first movie starring Adam West and Burt Ward.  ",
                    CreatedBy = "George Barris",
                    MovieTitle = "Batman: The Movie",
                    MoviePoster = "C:\\",
                    Status = "Sold at auction for $5,000,000 to a private collector (Dave Anderson).",
                    Make = "Lincoln",
                    Model = "Futura",
                    Year = 1955
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
