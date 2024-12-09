using Microsoft.AspNetCore.Identity;
using System.Globalization;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Infrastructure.Data.DataSeed
{

    internal class SeedData
        {
            public Microsoft.AspNetCore.Identity.IdentityUser AgentUser { get; set; }
            public Microsoft.AspNetCore.Identity.IdentityUser GuestUser { get; set; }
            public IdentityUser AdminUser { get; set; }
            public Agent Agent { get; set; }
            public Agent AdminAgent { get; set; }
            public Hotel BlackSeaStar { get; set; }
            public Hotel BanskoResort { get; set; }
            public Hotel PortoBelloHotel { get; set; }
            public Room BlackSeaTwoBed { get; set; }
            public Room BlackSeaStudio { get; set; }
            public Room BlackSeaPresidentApart { get; set; }
            public Room BanskoResortTwoBed { get; set; }
            public Room BanskoResortStudio { get; set; }
            public Room BanskoResortPresidentApart { get; set; }
            public Room PortoBelloTwoBed { get; set; }
            public Room PortoBelloStudio { get; set; }
            public Room PortoBelloPresidentApart { get; set; }
            public SeasonalEmployment KitchenHelper { get; set; }
            public SeasonalEmployment HouseKeeper { get; set; }
            public SeasonalEmployment RoomService { get; set; }
            public SeasonalEmployment Receptionist { get; set; }
            public SeasonalEmployment Piccolo { get; set; }
            public SeasonalEmployment ParkingAssistance { get; set; }
            public SeasonalEmployment PoolLifeGuard { get; set; }
            public SeasonalEmployment Waiter { get; set; }
            public SeasonalEmployment Barman { get; set; }
            public SeasonalEmployment DishWasher { get; set; }
            public VacationCategory SeaCategory { get; set; }
            public VacationCategory MountainCategory { get; set; }
            public VacationCategory SpaCategory { get; set; }
            public Vacation BlackSeaStarAllInclusive { get; set; }
            public Vacation BanskoResortAllInclusive { get; set; }
            public Vacation PortoBelloAllInclusive { get; set; }
            public Candidate NewGuestCandidate { get; set; }
            public HotelRoom BstarOne { get; set; }
            public HotelRoom BstarTwo { get; set; }
            public HotelRoom BstarTree { get; set; }
            public HotelRoom BanskoOne { get; set; }
            public HotelRoom BanskoTwo { get; set; }
            public HotelRoom BanskoTree { get; set; }
            public HotelRoom PortoOne { get; set; }
            public HotelRoom PortoTwo { get; set; }
            public HotelRoom PortoTree { get; set; }
            public SeedData()
            {
                SeedUsers();
                SeedAgent();
                SeedHotel();
                SeedVacationCategory();
                SeedRoom();
                SeedSeasonEmploymentOffers();
                SeedVacation();
                SeedCandidate();
                SeedHotelRoom();
            }

            private void SeedUsers()
            {
                var hasher = new PasswordHasher<Microsoft.AspNetCore.Identity.IdentityUser>();
                AgentUser = new Microsoft.AspNetCore.Identity.IdentityUser()
                {
                    Id = "dea12856-c198-4129-b3f3-b893d8395082",
                    UserName = "agent@mail.com",
                    NormalizedUserName = "agent@mail.com",
                    Email = "agent@mail.com",
                    NormalizedEmail = "agent@mail.com"
                };
                AgentUser.PasswordHash = hasher.HashPassword(AgentUser, "agent123");
                GuestUser = new Microsoft.AspNetCore.Identity.IdentityUser()
                {
                    Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                    UserName = "guest@mail.com",
                    NormalizedUserName = "guest@mail.com",
                    Email = "guest@mail.com",
                    NormalizedEmail = "guest@mail.com"
                };
                GuestUser.PasswordHash = hasher.HashPassword(AgentUser, "guest123");
                AdminUser = new IdentityUser()
                {
                    Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                    UserName = "admin@mail.com",
                    NormalizedUserName = "admin@mail.com",
                    Email = "admin@mail.com",
                    NormalizedEmail = "admin@mail.com",
                };
                AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin123");
            }

            private void SeedAgent()
            {
                Agent = new Agent()

                { Id = 1, PhoneNumber = "+359888888888", UserId = AgentUser.Id, IsActive = true };
                AdminAgent = new Agent()

                { Id = 4, PhoneNumber = "+359888888886", UserId = AdminUser.Id, IsActive = true };
            }
            private void SeedCandidate()
            {
                NewGuestCandidate = new Candidate()
                {
                    Id = 1,
                    UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                    PhoneNumber = "+35945566778899",
                    Email = "guest@mail.com",
                    IsAvaileble = true,
                    SeasonalEmploymentId = 1,
                    ShortRepresentAndSkills = "Good skils in work with people, adaptive, foreign langueges: English,German,Russian." +
                    "I am ambisios young person, adaptive and ready to improve in any aspect of the job that you are offering, " +
                    "I am prepeared for new challanges and I want to prove that I am the right choise for your company." +
                    "If you give me chanse I will be happy to prove myself and all the presentation skills that i said. Thank you!"
                };
            }
            private void SeedHotel()
            {
                BlackSeaStar = new Hotel()
                {
                    Id = 1,
                    Name = "Black Sea Star",
                    HotelReview = "Black Sea Star is hotel in old Sozopol town, you can visit and enjoy the rich history and amazing sea.",
                    Spa = true,
                    Pool = true,
                    AllInclusivePrice = 100,
                    ChildrenAnimators = true,
                    Location = "Sozopol, Bulgaria",
                    Capacity = 200,
                    CategoryStars = 3,
                    Rating = 6.6,
                    Image = File.ReadAllBytes(Path.Combine("wwwroot", "images", "blackSea.jpg")),
                    VacationCategoryId = 1
                };
                BanskoResort = new Hotel()
                {
                    Id = 2,
                    Name = "Bansko Resort",
                    HotelReview = "Bansko Resort is hotel in the amazing Pirin mountain. One of the best winter resort in Europe.",
                    Spa = true,
                    Pool = true,
                    AllInclusivePrice = 200,
                    ChildrenAnimators = true,
                    Location = "Bansko, Bulgaria",
                    Capacity = 300,
                    CategoryStars = 4,
                    Rating = 6.8,
                    Image = File.ReadAllBytes(Path.Combine("wwwroot", "images", "banskoResort.jpg")),
                    VacationCategoryId = 2
                };
                PortoBelloHotel = new Hotel()
                {
                    Id = 3,
                    Name = "Porto Bello",
                    HotelReview = "Porto Bello is at Kos iceland-Greece, the born place of Hipocrates. You can enjoy the amazing Egean sea.",
                    Spa = true,
                    Pool = true,
                    AllInclusivePrice = 150,
                    ChildrenAnimators = true,
                    Location = "Kos iceland, Greece",
                    Capacity = 400,
                    CategoryStars = 5,
                    Rating = 8.6,
                    Image = File.ReadAllBytes(Path.Combine("wwwroot", "images", "portoBello.jpg")),
                    VacationCategoryId = 1
                };
            }
            private void SeedRoom()
            {
                BlackSeaTwoBed = new Room()
                {
                    Id = 1,
                    Title = "BSea Two person room",
                    Price = 70.00M,
                    Count = 10
                };
                BlackSeaStudio = new Room()
                {
                    Id = 2,
                    Title = "BSea Studio room",
                    Price = 90.00M,
                    Count = 5
                };
                BlackSeaPresidentApart = new Room()
                {
                    Id = 3,
                    Title = "BanskoPresiden apartmen",
                    Price = 300.00M,
                    Count = 1
                };
                BanskoResortTwoBed = new Room()
                {
                    Id = 4,
                    Title = "Bansko Two bed room",
                    Price = 100.00m,
                    Count = 30
                };
                BanskoResortStudio = new Room()
                {
                    Id = 5,
                    Title = "Bansko Studio",
                    Price = 150.00M,
                    Count = 10
                };
                BanskoResortPresidentApart = new Room()
                {
                    Id = 6,
                    Title = "Bansko President apartment",
                    Price = 800.00M,
                    Count = 2
                };
                PortoBelloTwoBed = new Room()
                {
                    Id = 7,
                    Title = "PBello Two bed room",
                    Price = 120,
                    Count = 35
                };
                PortoBelloStudio = new Room()
                {
                    Id = 8,
                    Title = "PBello Studio",
                    Price = 180,
                    Count = 15
                };
                PortoBelloPresidentApart = new Room()
                {
                    Id = 9,
                    Title = "PBello President apartment",
                    Price = 500.00M,
                    Count = 1
                };

            }
            private void SeedVacationCategory()
            {
                SeaCategory = new VacationCategory()
                {
                    Id = 1,
                    VacationType = "Sea holiday",
                    Description = "Holiday next to the sea."
                };

                MountainCategory = new VacationCategory()
                {
                    Id = 2,
                    VacationType = "Mountain holiday",
                    Description = "Holiday in the mountain"
                };
                SpaCategory = new VacationCategory()
                {
                    Id = 3,
                    VacationType = "Spa holiday",
                    Description = "Vacation in SPA resort"
                };
            }
            private void SeedSeasonEmploymentOffers()
            {
                KitchenHelper = new SeasonalEmployment()
                {
                    Id = 1,
                    Title = "Kitchen helper",
                    Description = "Person who help to the shefs and performs the given tasks",
                    HourlyWage = 5.5M,
                    StartDate = DateTime.ParseExact("06/03/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06/09/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 1,
                    IsActive = true,
                };
                HouseKeeper = new SeasonalEmployment()
                {
                    Id = 2,
                    Title = "House keeper",
                    Description = "Cleaning rooms and common areas and preparing the hotel for the customers",
                    HourlyWage = 5.5M,
                    StartDate = DateTime.ParseExact("06/03/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06/09/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 1,
                    IsActive = true
                };
                RoomService = new SeasonalEmployment()
                {
                    Id = 3,
                    Title = "Room service",
                    Description = "Delivering and service to the hotel customers' room",
                    HourlyWage = 6.5M,
                    StartDate = DateTime.ParseExact("03/03/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("16/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 3,
                    IsActive = true
                };
                Receptionist = new SeasonalEmployment()
                {
                    Id = 4,
                    Title = "Receptionist",
                    Description = "Working to the reception, assistance to the customers problems and questions",
                    HourlyWage = 7.5M,
                    StartDate = DateTime.ParseExact("06/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06/04/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 2,
                    IsActive = true
                };
                Piccolo = new SeasonalEmployment()
                {
                    Id = 5,
                    Title = "Piccolo",
                    Description = "Welcoming and full assistance with customers' luggage",
                    HourlyWage = 3.5M,
                    StartDate = DateTime.ParseExact("03/03/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 3,
                    IsActive = true
                };
                ParkingAssistance = new SeasonalEmployment()
                {
                    Id = 6,
                    Title = "Parking assistance",
                    Description = "Welcoming and parking the cusstomers cars on the hotel parking",
                    HourlyWage = 3.5M,
                    StartDate = DateTime.ParseExact("06/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("09/04/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 2,
                    IsActive = true
                };
                PoolLifeGuard = new SeasonalEmployment()
                {
                    Id = 7,
                    Title = "Lifeguard",
                    Description = "Lifeguard on the hotel pool",
                    HourlyWage = 8.00M,
                    StartDate = DateTime.ParseExact("06/03/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 3,
                    IsActive = true
                };
                Waiter = new SeasonalEmployment()
                {
                    Id = 8,
                    Title = "Waiter",
                    Description = "Waiter at the hotel restorant",
                    HourlyWage = 3.00M,
                    StartDate = DateTime.ParseExact("06/04/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 1,
                    IsActive = true
                };
                Barman = new SeasonalEmployment()
                {
                    Id = 9,
                    Title = "Barman",
                    Description = "Bartendering and enterteiment",
                    HourlyWage = 6.00M,
                    StartDate = DateTime.ParseExact("06/02/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("18/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 3,
                    IsActive = true
                };
                DishWasher = new SeasonalEmployment()
                {
                    Id = 10,
                    Title = "Dishwasher",
                    Description = "Washing the dishes in the kitchen",
                    HourlyWage = 4.50M,
                    StartDate = DateTime.ParseExact("06/04/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("06/10/2025 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    AgentId = 1,
                    HotelId = 1,
                    IsActive = true
                };
            }
            private void SeedVacation()
            {
                BlackSeaStarAllInclusive = new Vacation()
                {
                    Id = 1,
                    Title = "Black Sea Star Sozopol-AllInclusive offer",
                    Price = 800.00M,
                    Capacity = 90,
                    VacationCategoryId = 1,
                    IsActive = true,
                    EnrollmentDeadline = DateTime.ParseExact("06/05/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    StartDate = DateTime.ParseExact("06/06/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("15/06/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    Description = "Ten days all inclusive holiday next to Black sea in one of the oldest towns in Europe." +
                    "Two bed room plus",
                    Location = "Sozopol, Bulgaria",
                    AgentId = 1,
                    HotelId = 1,
                    AllInclusive = true
                };
                BanskoResortAllInclusive = new Vacation()
                {
                    Id = 2,
                    Title = "Bansko Resort-AllInclusive offer",
                    Price = 2000.00M,
                    Capacity = 60,
                    VacationCategoryId = 1,
                    IsActive = true,
                    EnrollmentDeadline = DateTime.ParseExact("06/05/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    StartDate = DateTime.ParseExact("06/06/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("15/06/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    Description = "Ten days all inclusive holiday next to Black sea in one of the oldest towns in Europe." +
                    "Studio room plus",
                    Location = "Sozopol, Bulgaria",
                    AgentId = 1,
                    HotelId = 2,
                    AllInclusive = true
                };
                PortoBelloAllInclusive = new Vacation()
                {
                    Id = 3,
                    Title = "Bansko Resort-AllInclusive offer",
                    Price = 2000.00M,
                    Capacity = 100,
                    VacationCategoryId = 1,
                    IsActive = true,
                    EnrollmentDeadline = DateTime.ParseExact("06/05/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    StartDate = DateTime.ParseExact("06/06/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("15/06/2024 10:00", Constants.DataConstants.DateFormat, CultureInfo.InvariantCulture),
                    Description = "Ten days all inclusive holiday next to Black sea in one of the oldest towns in Europe." +
                    "Studio room plus",
                    Location = "Sozopol, Bulgaria",
                    AgentId = 1,
                    HotelId = 3,
                    AllInclusive = true
                };
            }
            private void SeedHotelRoom()
            {
                BstarOne = new HotelRoom()
                {
                    HotelId = 1,
                    RoomId = 1
                };
                BstarTwo = new HotelRoom()
                {
                    HotelId = 1,
                    RoomId = 2
                };
                BstarTree = new HotelRoom()
                {
                    HotelId = 1,
                    RoomId = 3
                };

                BanskoOne = new HotelRoom()
                {
                    HotelId = 2,
                    RoomId = 4
                };
                BanskoTwo = new HotelRoom()
                {
                    HotelId = 2,
                    RoomId = 5
                };
                BanskoTree = new HotelRoom()
                {
                    HotelId = 2,
                    RoomId = 6
                };
                PortoOne = new HotelRoom()
                {
                    HotelId = 3,
                    RoomId = 7
                };
                PortoTwo = new HotelRoom()
                {
                    HotelId = 3,
                    RoomId = 8
                };
                PortoTree = new HotelRoom()
                {
                    HotelId = 3,
                    RoomId = 9
                };
            }
        }
    }

