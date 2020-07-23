using JansenVerhuurAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Services
{
    public interface IUserService
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task CreateAsync(User user);
    }
}
