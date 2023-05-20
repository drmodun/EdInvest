using Microsoft.EntityFrameworkCore;
using Shared.Hash;
using Shared.Models;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Data.Entities
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //temporary generated countries without real flags, will add later 
            var categories = new List<Category>()
            {
                new Category
                {
                    Name = "IT",
                     Description = "Everything connected to the field of informatics and IT",
                     Id = Guid.NewGuid(),

                },
                new Category
                {
                     Name = "Maths",
                     Description = "Everything connected to the field of Maths from calculus to applied matheatics",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Phyisics",
                     Description = "Everything connected to the field of Phyisics from quantum mechanics to experimental phyisics",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Chemistry",
                     Description = "Everything connected to the field of Chemistry from organic chemistry to inorganic chemistry",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Biology",
                     Description = "Everything connected to the field of Biology from molecular biology to zoology",
                     Id = Guid.NewGuid(),
                },
                new Category
                {
                    Name = "Economics",
                     Description = "Everything connected to the field of Economics from microeconomics to macroeconomics",
                     Id = Guid.NewGuid(),
                }
            };
            var subcategories = new List<Subcategory>()
            {
                new Subcategory
                {
                    CategoryId = categories[0].Id,
                    Id = Guid.NewGuid(),
                    Name = "Frontend development",
                    Description = "Educational projects related to frontend development"
                },
                new Subcategory
                {
                    CategoryId = categories[0].Id,
                    Id = Guid.NewGuid(),
                    Name = "Backend development",
                    Description = "Educational projects related to backend development"
                },
                //write a few more subcategories related to infromatics
                new Subcategory
                {
                    CategoryId = categories[1].Id,
                    Id = Guid.NewGuid(),
                    Name = "Calculus",
                    Description = "Educational projects related to calculus"
                },
                new Subcategory
                {
                    CategoryId = categories[1].Id,
                    Id = Guid.NewGuid(),
                    Name = "Applied mathematics",
                    Description = "Educational projects related to applied mathematics"
                },
                //write a few more subcategories related to maths
                new Subcategory
                {
                    CategoryId = categories[2].Id,
                    Id = Guid.NewGuid(),
                    Name = "Quantum mechanics",
                    Description = "Educational projects related to quantum mechanics"
                },
                new Subcategory
                {
                    CategoryId = categories[2].Id,
                    Id = Guid.NewGuid(),
                    Name = "Experimental physics",
                    Description = "Educational projects related to experimental physics"
                },
                //write a few more subcategories related to physics
                new Subcategory
                {
                    CategoryId = categories[3].Id,
                    Id = Guid.NewGuid(),
                    Name = "Organic chemistry",
                    Description = "Educational projects related to organic chemistry"
                },
                new Subcategory
                {
                    CategoryId = categories[3].Id,
                    Id = Guid.NewGuid(),
                    Name = "Inorganic chemistry",
                    Description = "Educational projects related to inorganic chemistry"
                },
                //write a few more subcategories related to chemistry
                new Subcategory
                {
                    CategoryId = categories[4].Id,
                    Id = Guid.NewGuid(),
                    Name = "Molecular biology",
                    Description = "Educational projects related to molecular biology"
                },
                new Subcategory
                {
                    CategoryId = categories[4].Id,
                    Id = Guid.NewGuid(),
                    Name = "Zoology",
                    Description = "Educational projects related to zoology"
                },
                //write a few more subcategories related to biology
                new Subcategory
                {
                    CategoryId = categories[5].Id,
                    Id = Guid.NewGuid(),
                    Name = "Microeconomics",
                    Description = "Educational projects related to microeconomics"
                },
                new Subcategory
                {
                    CategoryId = categories[5].Id,
                    Id = Guid.NewGuid(),
                    Name = "Macroeconomics",
                    Description = "Educational projects related to macroeconomics"
                },
                //write a few more subcategories related to economics
            };

            var investors = new List<Investor>()
            {
                new Investor
                {
                    Name = "FakeCompany",
                    Description = "Descriptiojn of a fake company",
                    UpdatedAt = DateTime.UtcNow,

                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" }
                    },

                    Email = "fakecompany@gmail.com",

                    LocationName = "Split",
                    Id = Guid.NewGuid(),
                    NumberOfEmployees = 10,
                    Password = HashHelper.Hash("passWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XUkyGFGbqMDuzt1u3xhGAkTtS"

                },
                new Investor
                {
                    Name = "FakeAdmiinCompany",
                    Description = "Descriptiojn of a fake company",

                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" },
                        {"admin" , "true" }

                    },

                    Email = "fakecompany1@gmail.com",
                    UpdatedAt = DateTime.UtcNow,

                    LocationName = "Zagreb",
                    Id = Guid.NewGuid(),
                    NumberOfEmployees = 10,
                    Password = HashHelper.Hash("PassWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XukyGFGbqMDuzt1u3xhGAkTtS"
                },
                new Investor
                {
                    Name = "Investor",
                    Description = "Descriptiojn of a fake investor",
                    UpdatedAt = DateTime.UtcNow,

                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" }
                    },
                    Email = "investor@gmail.com",

                    LocationName = "London",
                    Id = Guid.NewGuid(),
                    NumberOfEmployees = 10,
                    Password = HashHelper.Hash("password"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XukygFGbqMDuzt1u3xhGAkTtS"
                }
            };
            var organisations = new List<Organisation>()
            {
                //implement a few more organisation

                new Organisation
                {
                    Name = "Fake event organisator",
                    Description = "Descriptiojn of a fake event organisator",

                    Type = Shared.Enums.UserType.Organisation,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" }
                    },

                    Email = "evets@gmail.com",
                    UpdatedAt = DateTime.UtcNow,
                    LocationName = "Split",
                    Id = Guid.NewGuid(),
                    NumberOfMembers = 10,
                    Password = HashHelper.Hash("passWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK5oN6XUkyGFGbqMDuzt1u3xhGAkTtS"

                },
                new Organisation
                {
                    Name = "RandomCourseCompany",
                    Description = "Descriptiojn of a fake company",
                    UpdatedAt = DateTime.UtcNow,

                    Type = Shared.Enums.UserType.Organisation,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" },
                        {"admin" , "true" }

                    },

                    Email = "fakecourse@gmail.com",

                    LocationName = "Hvar",
                    Id = Guid.NewGuid(),
                    NumberOfMembers = 10,
                    Password = HashHelper.Hash("PassWord"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GSnK58N6XukyGFGbqMDuzt1u3xhGAkTtS"
                },
                new Organisation
                {
                    Name = "Organisation",
                    Description = "Descriptiojn of a fake organisation",

                    Type = Shared.Enums.UserType.Investor,
                    Claims = new Dictionary<string, string>()
                    {
                        {"trusted_member" , "true" },
                    },
                    Email = "organisation@gmail.com",
                    UpdatedAt = DateTime.UtcNow,
                    LocationName = "London",
                    Id = Guid.NewGuid(),
                    NumberOfMembers = 10,
                    Password = HashHelper.Hash("password"),
                    ProfilePicture = "pfp",
                    SocialLinks = new Dictionary<string, string>()
                    {
                        {"facebook" , "facebook.com" }
                    },
                    WalletAddress = "1GsnK58N6XukygFGbqMDuzt1u3xhGAkTtS"
                }
            };
            var applications = new List<Application>()
            {
                new Application
                {
                    Id = Guid.NewGuid(),
                     Name = "LearnApp",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",

                     Features = new List<string>()
                     {
                         "Good learinng experience",
                         "Amazing customer support"
                     },
                     AppPurpose = "To teach people how to learn",
                     CategoryId = categories[0].Id,


                     Description = "The greatest learnign app to exist",
                     EstimatedNumberOfUsers = 1000000,
                     EstimatedRelease = DateTime.UtcNow.AddDays(365),
                     OrganisationId = organisations[1].Id,
                     Markets = new List<string>(){ "Android", "Ios"},
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Application,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
                new Application{
                Id = Guid.NewGuid(),
                     Name = "TeachApp",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",

                     Features = new List<string>()
                     {
                         "Good teaching experience",
                         "Amazing customer support"
                     },
                     AppPurpose = "To teach people how to teach",
                     CategoryId = categories[2].Id,


                     Description = "The greatest teaching app to exist",
                     EstimatedNumberOfUsers = 1000000,
                     EstimatedRelease = DateTime.UtcNow.AddDays(365),
                     OrganisationId = organisations[1].Id,
                     Markets = new List<string>(){ "Android", "Ios"},
                     SubcategoryId = subcategories[7].Id,
                     Type = Shared.Enums.ItemType.Application,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                }

            };
            var events = new List<Event>()
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                     Name = "LearnConference",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",
                     Location = "Zagreb",
                     Activities = new Dictionary<string, string>()
                     {
                         {"12am", "pizza" },
                         {"1pm", "Work" }
                     },
                     NotableAttendees = new List<string>()
                     {
                         "CEO"
                     },
                     NotableSpeakers = new List<string>()
                     {
                         "Lead dev"
                     },
                     Date = DateTime.UtcNow.AddDays(30),
                     CategoryId = categories[3].Id,


                     Description = "The greatest learning event to exist",
                     ExpectedAttendance = 1999,
                     Capacity = 3000,
                     OrganisationId = organisations[0].Id,
                     TicketPrice = 100,
                     SubcategoryId = subcategories[10].Id,
                     Type = Shared.Enums.ItemType.Event,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
                new Event
                {
                    Id = Guid.NewGuid(),
                     Name = "designConference",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",

                     Location = "Split",
                     Activities = new Dictionary<string, string>()
                     {
                         {"12am", "pizza" },
                         {"1pm", "Work" }
                     },
                     NotableAttendees = new List<string>()
                     {
                         "CEO"
                     },
                     NotableSpeakers = new List<string>()
                     {
                         "Lead designer"
                     },
                     Date = DateTime.UtcNow.AddDays(30),
                     CategoryId = categories[3].Id,


                     Description = "The greatest design event to exist",
                     ExpectedAttendance = 1999,
                     Capacity = 3000,
                     OrganisationId = organisations[0].Id,
                     TicketPrice = 100,
                     SubcategoryId = subcategories[11].Id,
                     Type = Shared.Enums.ItemType.Event,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
            };
            var courses = new List<Course>()
            {
                new Course
                {
                    Id = Guid.NewGuid(),
                     Name = "Webapi Course",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",

                     Curriculum = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "Webapi" }
                     },
                     ExpectedApplicants = 100000,
                     ExpectedGraduates = 100,
                     EndDate = DateTime.UtcNow.AddDays(182.5),
                     StartDate = DateTime.UtcNow.AddDays(82.5),


                     CategoryId = categories[1].Id,


                     Description = "The greatest course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[3].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
               new Course
                {
                    Id = Guid.NewGuid(),
                     Name = "React Course",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",

                     Curriculum = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "React" }
                     },
                     ExpectedApplicants = 100000,
                     ExpectedGraduates = 100,
                     EndDate = DateTime.UtcNow.AddDays(182.5),
                     StartDate = DateTime.UtcNow.AddDays(82.5),


                     CategoryId = categories[0].Id,


                     Description = "The greatest course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
            };
            var onlineCourses = new List<OnlineCourse>()
            {
                new OnlineCourse
                {
                     Id = Guid.NewGuid(),
                     Name = "React online Course",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",

                     Lessons = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "React" }
                     },
                     AvarageDuration = 12,
                     LessonsDate = new List<DateTime>
                     {
                         DateTime.UtcNow.AddDays(2),
                         DateTime.UtcNow.AddDays(3),
                         DateTime.UtcNow.AddDays(4)
                     },
                     LinksToChannels = new Dictionary<string, string>()
                     {
                         {"youtube", "stuff" },
                         {"facebook", "morestruff" }
                     },
                     ExpectedAudience = 100,



                     CategoryId = categories[0].Id,


                     Description = "The greatest online course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
                new OnlineCourse
                {
                     Id = Guid.NewGuid(),
                     Name = "Webapi online Course",
                     Goal = 10000,
                 MainWebsite = "https://randomwebsite.com",

                     Lessons = new Dictionary<string, string>()
                     {
                         {"1st lesson", "Github" },
                         {"2nd lesson", "Wrbapi" }
                     },
                     AvarageDuration = 12,
                     LessonsDate = new List<DateTime>
                     {
                         DateTime.UtcNow.AddDays(2),
                         DateTime.UtcNow.AddDays(3),
                         DateTime.UtcNow.AddDays(4)
                     },
                     LinksToChannels = new Dictionary<string, string>()
                     {
                         {"youtube", "stuff" },
                         {"facebook", "morestruff" }
                     },
                     ExpectedAudience = 100,



                     CategoryId = categories[0].Id,


                     Description = "The greatest online course to exist",
                     OrganisationId = organisations[0].Id,
                     SubcategoryId = subcategories[0].Id,
                     Type = Shared.Enums.ItemType.Course,
                     Images = new List<string>() { "pfp", "stuffaboutapp"},
                     Prices = new List<decimal>() {10, 100, 1000},
                     Tiers = new Dictionary<string, string>
                     {
                         {"Bronze", "Basic tier" },
                         {"Silver", "Middle tier" },
                         {"Gold", "Best tier" }
                     },
                     UpdatedAt = DateTime.UtcNow,

                },
            };
            var investments = new List<Investments>()
            {
                new Investments
                {
                    Amount = 10,

                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[0].Id,
                    ItemId = applications[0].Id,
                    Tier = 1
                },
                new Investments
                {
                    Amount = 100,

                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[1].Id,
                    ItemId = events[0].Id,
                    Tier = 2
                },new Investments
                {
                    Amount = 10000,

                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[1].Id,
                    ItemId = onlineCourses[0].Id,
                    Tier = 3
                },
                 new Investments
                {
                    Amount = 20,
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[2].Id,
                    ItemId = applications[1].Id,
                    Tier = 1
                },
                new Investments
                {
                    Amount = 200,
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[0].Id,
                    ItemId = events[1].Id,
                    Tier = 2
                },
                new Investments
                {
                    Amount = 20000,
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[0].Id,
                    ItemId = onlineCourses[1].Id,
                    Tier = 3
                },
                new Investments
                {
                    Amount = 30,
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[1].Id,
                    ItemId = applications[1].Id,
                    Tier = 1
                },
                new Investments
                {
                    Amount = 300,
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[2].Id,
                    ItemId = events[1].Id,
                    Tier = 2
                },
                new Investments
                {
                    Amount = 30000,
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[0].Id,
                    ItemId = courses[1].Id,
                    Tier = 3
                },
                new Investments
                {
                    Amount = 40,
                    UpdatedAt= DateTime.UtcNow,
                    InvestorId = investors[2].Id,
                    ItemId = applications[0].Id,
                    Tier = 1
                }

            };




            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Subcategory>().HasData(subcategories);
            modelBuilder.Entity<Investor>().
                HasData(investors);
            modelBuilder.Entity<Organisation>().HasData(organisations);
            modelBuilder.Entity<Application>().HasData(applications);
            modelBuilder.Entity<OnlineCourse>().HasData(onlineCourses);
            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<Investments>().HasData(investments);




        }

    }
}

