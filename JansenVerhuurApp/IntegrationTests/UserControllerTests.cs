using System.Threading.Tasks;
using JansenVerhuurAPI.Controllers;
using Xunit;

namespace IntegrationTests
{
    public class UserControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll()
        {
            var response = await Client.GetAsync(ApiRoutes.User.GetAll);
            response.EnsureSuccessStatusCode();
        }
    }
}