using System.Net.Http;
using JansenVerhuurAPI;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient Client;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            Client = appFactory.CreateClient();
        }
    }
}