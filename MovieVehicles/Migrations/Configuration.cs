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
                    VehiclePhoto = "imagecomingsoon.jpg",
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
                    VehiclePhoto = "imagecomingsoon.jpg",
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
                    VehiclePhoto = "imagecomingsoon.jpg",
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
                    VehiclePhoto = "OriginalDelorean.png",
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
                    VehiclePhoto = "BullittMustang.jpg",
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
                    VehiclePhoto = "Herbie.jpg",
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
                    VehiclePhoto = "General_lee.jpg",
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
                    VehiclePhoto = "BaTumbler_HD.jpg",
                    Status = "Unknown",
                    Make = "None",
                    Model = "None",
                    Year = 2005
                },

                new Models.Vehicle()
                {
                    VehicleName = "James Bond's submersible Lotus",
                    Description = "The Lotus Esprit S1 featured in 'The Spy Who Loved Me' is a 1976 Lotus Esprit S1.  Two Stree legal Esprit S1's were used in the movie as well as several body shells for the underwater scenes.  In the movie the Lotus was not just amphibious, it also contained cannons that spray cement on to pursuing vehicles. It also has wheel arches that turn into fins, a small periscope on the roof enabling 007 to navigate at speed underwater and its other weaponry includes a missile launched from its rear deck, mines, and torpedoes which were all compliments of Q branch.",
                    CreatedBy = "Perry Oceanographic Inc.",
                    MovieTitle = "The Spy Who Loved Me",
                    VehiclePhoto = "lotuss1.jpg",
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
                    VehiclePhoto = "GBBatmobile.jpg",
                    Status = "Sold at auction for $5,000,000 to a private collector (Dave Anderson).",
                    Make = "Lincoln",
                    Model = "Futura",
                    Year = 1955
                },

                new Models.Vehicle()
                {
                    VehicleName = "Tim Burton's Batmobile",
                    Description = "The Batmobile was built upon a Chevrolet Impala chasis with a Chevy V8 engine, and was based on and modified from a 1970 Corvette body when previous development with a Jaguar and Ford Mustang failed. A second car was based on an Oldsmobile Cutlass Convertible.  All gadgets (aside from the Cocoon-mode) on the Batmobile in both movies were fully functional, although the exhaust after-burner could only run for 15 seconds at a time due to the amount of fuel that it consumed.",
                    CreatedBy = "Anton Furst, Tim Burton, Terry Ackland-Snow, John Eveans, Keith Short",
                    MovieTitle = "Batman",
                    VehiclePhoto = "TBBatmobile.gif",
                    Status = "Unknown",
                    Make = "Chevy",
                    Model = "Impala",
                    Year = 1970
                },

                new Models.Vehicle()
                {
                    VehicleName = "Bandit Trans Am",
                    Description = "After seeing an advertisement for the soon-to-be-released 1977 Pontiac Trans Am director Hal Needham knew right away that would be the Bandit's car, or, as Needham referred to it, a character in the movie. He contacted Pontiac and an agreement was made that four 1977 Trans Ams would be provided for the movie. The Trans Ams were actually 1976-model cars with 1977 front ends. (From 1970 to 1976, both the Firebird/Trans Am and Chevrolet Camaro had two round headlights, and in 1977, the Firebird/Trans Am was changed to four square headlights, while the Camaro remained unchanged.) The decals were also changed to 1977-style units, as evidenced by the engine size callouts on the hood scoop being in liters rather than cubic inches, as had been the case in 1976.",
                    CreatedBy = "Pontiac",
                    MovieTitle = "Smokey and the Bandits",
                    VehiclePhoto = "BanditTransAm.jpg",
                    Status = "Destroyed in production of the movie.",
                    Make = "Pontiac",
                    Model = "Trans Am",
                    Year = 1977
                },

                new Models.Vehicle()
                {
                    VehicleName = "Ecto-1",
                    Description = "This modified Cadillac Miller-Meteor Futura Ambulance/Hearse Combination was used in the Ghostbusters and Ghostbusters 2 movies.  The vehicle used for the Ecto-1 was a 1959 Cadillac professional chassis, built by the Miller-Meteor company.  Stephen Dane is credited as a Hardware Consultant for the movies and was the fabricator of the original Ectomobile.",
                    CreatedBy = "Miller-Meteor",
                    MovieTitle = "Ghostbusters",
                    VehiclePhoto = "Ghostbusters-Ecto-1.jpg",
                    Status = "On display in the Hollywood Gallery of the Petersen Automotive Museum in Los Angeles.",
                    Make = "Cadillac",
                    Model = "Miller-Meteor",
                    Year = 1959
                },

                new Models.Vehicle()
                {
                    VehicleName = "James Bond 1964 Aston Martin DB5",
                    Description = "The Aston Martin DB5 is the most famous Aston Martin car due to its use by James Bond in Goldfinger (1964). The car used in the film was the original DB5 prototype, with another standard car used for stunts. Famous for its array of gadgets, the film's script initially had the car armed only with smoke screen. However, the gadgets rapidly increased as crew members began suggesting devices to install in it. For instance, director Guy Hamilton conceived the revolving license plate because he had been getting lots of parking tickets, while his stepson suggested the ejector seat (which he saw on television).",
                    CreatedBy = "Aston Martin",
                    MovieTitle = "Goldfinger",
                    VehiclePhoto = "JB1964AstonMartinDB5.jpg",
                    Status = "Unknown",
                    Make = "Aston Martin",
                    Model = "DB5",
                    Year = 1964
                },

                new Models.Vehicle()
                {
                    VehicleName = "Chitty Chitty Bang Bang Car",
                    Description = "Chitty Chitty Bang Bang is the vintage racing car which features in the book, musical film and stage production of the same name. Writer Ian Fleming took his inspiration for the car from a series of aero-engined racing cars built by Count Louis Zborowski in the early 1920s, christened Chitty Bang Bang.  This fully functional road-going car with UK registration GEN 11 was fitted with a Ford 3000 V6 engine and automatic transmission and allocated a genuine UK registration. ",
                    CreatedBy = "Ken Adam, Frederick Rowland Emett, Alan Mann",
                    MovieTitle = "Chitty Chitty Bang Bang",
                    VehiclePhoto = "Chitty-1.jpg",
                    Status = "Sold at auction to a private collector (Peter Jackson)",
                    Make = "None",
                    Model = "None",
                    Year = 0
                },

                new Models.Vehicle()
                {
                    VehicleName = "James Dean's Mercury",
                    Description = "The car driven by James Dean in the movie, “Rebel Without A Cause,”   was a 49 Mercury.  Customized for the movie, the 49 Mercury was dechromed.  When the movie debuted, James Dean was already dead, and the movie inspired a new generation of teens to love this old classic.  In fact, the 1949 Mercury is considered by most to be one of the most famous movie cars in all time history. ",
                    CreatedBy = "Mercury",
                    MovieTitle = "Rebel Without a Cause",
                    VehiclePhoto = "JamesDeanMercury.jpg",
                    Status = "Dislayed at the National Automobile Museum in Reno, Nevada",
                    Make = "Mercury",
                    Model = "Series 9CM Coupe",
                    Year = 1949
                },

                new Models.Vehicle()
                {
                    VehicleName = "Mad Max Interceptor",
                    Description = "The vehicle started out as a standard white Australian built 1973 Ford Falcon XB GT Hardtop when in 1976, filmmakers Byron Kennedy and George Miller began preproduction on Mad Max. The movie's art director Jon Dowding designed the Interceptor and commissioned Melbourne-based car customizers Graf-X International to modify the GT Falcon. Peter Arcadipane, Ray Beckerley, John Evans, and painter Rod Smythe transformed the car as specified for the film.",
                    CreatedBy = "Ford",
                    MovieTitle = "Mad Max",
                    VehiclePhoto = "MadMaxInterceptor.jpg",
                    Status = "On display at the Miami Auto Museum",
                    Make = "Ford",
                    Model = "Falcon XB GT Coupe",
                    Year = 1973
                },

                new Models.Vehicle()
                {
                    VehicleName = "Knight Industries Two Thousand (KITT)",
                    Description = "KITT is an artificially intelligent electronic computer module in the body of a highly advanced, very mobile, robotic automobile.  KITT is used  by the Foundation for Law and Government (FLAG) and its parent Knight Industries in the Foundation's crime-fighting crusade.",
                    CreatedBy = "Pontiac",
                    MovieTitle = "Knight Rider",
                    VehiclePhoto = "KITT.jpg",
                    Status = "Unknown",
                    Make = "Pontiac",
                    Model = "Firebird Trans Am",
                    Year = 1982
                },

                new Models.Vehicle()
                {
                    VehicleName = "The Orca",
                    Description = "Captained by Eccentric fisherman Quint The Orca was used to persue the killer great whte that was terrorizing a small New England Town",
                    CreatedBy = "Unknown",
                    MovieTitle = "Jaws",
                    VehiclePhoto = "Orca.jpg",
                    Status = "Utilized for further study by Dr. Matthew Hooper at the Woods Hole Oceanagraphic Institute",
                    Make = "None",
                    Model = "None",
                    Year = 0
                },

                new Models.Vehicle()
                {
                    VehicleName = "Steve McQueen's Triumph",
                    Description = "This Triumph TR6 was riden by Steve McQueen to escape from a escape proof prison during World War 2 and make his way across occupied Europe.",
                    CreatedBy = "Triumph",
                    MovieTitle = "The Great Escape",
                    VehiclePhoto = "greatescapetriumph.jpg",
                    Status = "Purchased by private collector (Dick Shepherd)",
                    Make = "Triumph",
                    Model = "TR6",
                    Year = 1961
                },

                new Models.Vehicle()
                {
                    VehicleName = "The Family Truckster",
                    Description = "The Wagon Queen Family Truckster station wagon was created specifically for the film. It is based on a 1979 Ford LTD Country Squire station wagon.[10] The car was designed by George Barris, and it lampooned American cars of the late 1970s. The Truckster features a pale avocado metallic green paint scheme; extensive imitation wood-paneling decals; eight headlights",
                    CreatedBy = "George Barris",
                    MovieTitle = "National Lampoon's Vacation",
                    VehiclePhoto = "FamilyTruckster.jpg",
                    Status = "Unknown",
                    Make = "Ford",
                    Model = "LTD Country Squire",
                    Year = 1979
                },

                new Models.Vehicle()
                {
                    VehicleName = "Milner’s Deuce Coupe",
                    Description = "This 1932 Ford Coupe cruised around town and could beat anyone looking for a race.",
                    CreatedBy = "Ford Motor Co.",
                    MovieTitle = "American Graffiti",
                    VehiclePhoto = "DeuceCoupe.jpg",
                    Status = "Purchased by private collector (Steve Fitch)",
                    Make = "Ford",
                    Model = "Coupe",
                    Year = 1932
                },

                new Models.Vehicle()
                {
                    VehicleName = "Mr. Frye’s Ferrari",
                    Description = "This Ferrari was used by Ferris Bueller and two friends to take day long adventure while skipping school.",
                    CreatedBy = "Ferrari",
                    MovieTitle = "Ferris Bueller's Day Off",
                    VehiclePhoto = "fbferrari.jpg",
                    Status = "Sold at auction to a private collector  in 2015 for $16,830,000",
                    Make = "Ferrari",
                    Model = "250 GT California Spyder SWB",
                    Year = 1961
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
                },

                new Models.Event()
                {
                    EventTitle = "James Dean Mercury at Hagerty Insurance",
                    EventDescription = "The Mercury James drove in Rebel Without a Cause will be on display at Hagerty Insurance.",
                    EventDate = new DateTime(2018, 4, 15),
                    EventCity = "Traverse City",
                    EventState = "MI",
                    VehicleID = 19
                },

                new Models.Event()
                {
                    EventTitle = "Ecto 1 at State Hospital",
                    EventDescription = "Ecto 1 from the movie Ghostbusters will be at the former state hospital and available for rides.",
                    EventDate = new DateTime(2018, 6, 11),
                    EventCity = "Traverse City",
                    EventState = "MI",
                    VehicleID = 16
                },

                new Models.Event()
                {
                    EventTitle = "Orca to Ferry Passengers",
                    EventDescription = "The boat Orca from the movie Jaws will ferry passengers to and from south Manitou Island.",
                    EventDate = new DateTime(2018, 8, 1),
                    EventCity = "Empire",
                    EventState = "MI",
                    VehicleID = 23
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
                },

                new Models.Review()
                {
                    ReviewTitle = "Amazing",
                    FirstName = "Izzy",
                    LastName = "Deadyet",
                    ReviewDate = new DateTime(2018, 3, 8),
                    ReviewText = "KITT was pretty cool.  And he actually talks.",
                    VehicleID = 22
                },

                new Models.Review()
                {
                    ReviewTitle = "Too Cool",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 3, 11),
                    ReviewText = "KITT was awesome and very sleek.  Michael seemed shorter in person.",
                    VehicleID = 22
                },

                new Models.Review()
                {
                    ReviewTitle = "Just like the Movie",
                    FirstName = "Luke",
                    LastName = "Warmwater",
                    ReviewDate = new DateTime(2018, 4, 1),
                    ReviewText = "Got to ride with 'The Bandit' from the movie.  Getting to ride in the actual car was a trip.",
                    VehicleID = 15
                },

                new Models.Review()
                {
                    ReviewTitle = "OK",
                    FirstName = "Izzy",
                    LastName = "Deadyet",
                    ReviewDate = new DateTime(2018, 4, 2),
                    ReviewText = "Got to see the Trans Am from Smokey and the Bandit.  Seemed cooler in the movie than in person.",
                    VehicleID = 15
                },

                new Models.Review()
                {
                    ReviewTitle = "OK",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 2, 2),
                    ReviewText = "A cool car for a day off from school.  Too bad they don't let people take rides.",
                    VehicleID = 27
                },

                new Models.Review()
                {
                    ReviewTitle = "OK",
                    FirstName = "Luke",
                    LastName = "Warmwater",
                    ReviewDate = new DateTime(2018, 5, 15),
                    ReviewText = "Got to go for a ride, totally cool.  I wish I could drive it.",
                    VehicleID = 27
                },

                new Models.Review()
                {
                    ReviewTitle = "OK",
                    FirstName = "Luke",
                    LastName = "Warmwater",
                    ReviewDate = new DateTime(2018, 4, 2),
                    ReviewText = "Got to see it displayed at the maritime academy in Traverse City.  Wish I could take it out in the bay for a spin.",
                    VehicleID = 10
                },   //---

                new Models.Review()
                {
                    ReviewTitle = "Not as Cool",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 6, 13),
                    ReviewText = "Watched the TV show and movie with Adam West.  I remember the car being cooler when I was a kid.",
                    VehicleID = 11
                },

                new Models.Review()
                {
                    ReviewTitle = "Cool",
                    FirstName = "Izzy",
                    LastName = "Deadyet",
                    ReviewDate = new DateTime(2018, 6, 13),
                    ReviewText = "Saw this vehicle at Hagerty Insurance.  Just as cool in person as in the movie.",
                    VehicleID = 6
                },

                new Models.Review()
                {
                    ReviewTitle = "Awesome Just Like Steve McQueen",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 6, 30),
                    ReviewText = "Saw this vehicle at Hagerty Insurance, I can't blame Steve McQueen for wanting to buy it back.",
                    VehicleID = 6
                },

                new Models.Review()
                {
                    ReviewTitle = "Not Sure About the Hype",
                    FirstName = "Luke",
                    LastName = "Warmwater",
                    ReviewDate = new DateTime(2018, 4, 22),
                    ReviewText = "Saw this vehicle at Hagerty Insurance.  Not sure why everyone thinks this is a cool car.",
                    VehicleID = 6
                },

                new Models.Review()
                {
                    ReviewTitle = "Unbelievable",
                    FirstName = "Luke",
                    LastName = "Warmwater",
                    ReviewDate = new DateTime(2018, 6, 1),
                    ReviewText = "Can't believe this motorcycle was used to jump a fence.",
                    VehicleID = 24
                },

                new Models.Review()
                {
                    ReviewTitle = "Runs Like a Champ",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 3, 1),
                    ReviewText = "Got to ride the motorcycle around the track in Cedar, still runs like it was brand new.",
                    VehicleID = 24
                },

                new Models.Review()
                {
                    ReviewTitle = "Classic Bond Car",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 1, 12),
                    ReviewText = "Love the Aston Martins.  They are classic Bond cars.",
                    VehicleID = 17
                },

                new Models.Review()
                {
                    ReviewTitle = "Don't Get It",
                    FirstName = "Izzy",
                    LastName = "Deadyet",
                    ReviewDate = new DateTime(2018, 4, 30),
                    ReviewText = "I saw the James Bond Aston Martin.  I guess I just don't understand why people think it's cool.  It's just a car to me.",
                    VehicleID = 17
                },

                new Models.Review()
                {
                    ReviewTitle = "Time for a Vacation",
                    FirstName = "Warren",
                    LastName = "Peace",
                    ReviewDate = new DateTime(2018, 2, 17),
                    ReviewText = "I was able to see the car at a stop in Empire.  Definately a memorable  car.",
                    VehicleID = 25
                },

                new Models.Review()
                {
                    ReviewTitle = "Room for the Whole Family",
                    FirstName = "Izzy",
                    LastName = "Deadyet",
                    ReviewDate = new DateTime(2017, 11, 12),
                    ReviewText = "I saw this car at a tour stop in Mackinac City.  Kind of cool in a weird way and very roomy inside.",
                    VehicleID = 25
                }
            );
        }
    }
}
