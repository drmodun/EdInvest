namespace API.Routes
{
    public static class AppRoutes
    {
        private const string Base = "api";
        public static class Application
        {
            public const string GetAll = Base + $"/applications";
            public const string Get = Base + $"/applications/{{id:Guid}}";
            public const string Create = Base + $"/applications";
            public const string Update = Base + $"/applications/{{id:Guid}}";
            public const string Delete = Base + $"/applications/{{id:Guid}}";
        }
        public static class User
        {
            public const string GetAll = Base + $"/users";
            public const string Get = Base + $"/users/{{id:Guid}}";
            public const string Create = Base + $"/users";
            public const string Update = Base + $"/users/{{id:Guid}}";
            public const string Delete = Base + $"/users/{{id:Guid}}";
        }
        public static class Category
        {
            public const string GetAll = Base + $"/categories";
            public const string Get = Base + $"/categories/{{id:Guid}}";
            public const string Create = Base + $"/categories";
            public const string Update = Base + $"/categories/{{id:Guid}}";
            public const string Delete = Base + $"/categories/{{id:Guid}}";
        }
        public static class Subcategory
        {
            public const string GetAll = Base + $"/subcategories";
            public const string Get = Base + $"/subcategories/{{id:Guid}}";
            public const string Create = Base + $"/subcategories";
            public const string Update = Base + $"/subcategories/{{id:Guid}}";
            public const string Delete = Base + $"/subcategories/{{id:Guid}}";
        }
        public static class Items
        {
            public const string GetAll = Base + $"/items";
            public const string Get = Base + $"/items/{{id:Guid}}";
            public const string Create = Base + $"/items";
            public const string Update = Base + $"/items/{{id:Guid}}";
            public const string Delete = Base + $"/items/{{id:Guid}}";
        }
        public static class Investments
        {
            public const string GetAll = Base + $"/investments";
            public const string Get = Base + $"/{{InvestorId:Guid}}/{{CourseId:Guid}}";
            public const string Update = Base + $"/{{InvestorId:Guid}}/{{CourseId:Guid}}";
            public const string Delete = Base + $"/{{InvestorId:Guid}}/{{CourseId:Guid}}";
            public const string Create = Base + $"/{{InvestorId:Guid}}/{{CourseId:Guid}}";
            
        }
        public static class Country
        {
            public const string GetAll = Base + $"/countries";
            public const string Get = Base + $"/countries/{{id:Guid}}";
            public const string Create = Base + $"/countries";
            public const string Update = Base + $"/countries/{{id:Guid}}";
            public const string Delete = Base + $"/countries/{{id:Guid}}";
        }
        //add other routes later
    }
}