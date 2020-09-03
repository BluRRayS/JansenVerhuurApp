namespace JansenVerhuurAPI.Controllers
{
    public static class ApiRoutes
    {
        public static class User
        {
            public const string GetAll = "/Users";
            public const string Get = "/Users/{id}";
            public const string Create = "/Users/Create";
            public const string Update = "/Users/Update";
            public const string Delete = "/Users/Delete";
        }
        
        public static class Auth
        {
            public const string Login = "/Login";
        }
    }
}