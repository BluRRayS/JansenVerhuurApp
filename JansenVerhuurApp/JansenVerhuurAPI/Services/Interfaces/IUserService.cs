using JansenVerhuurAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
