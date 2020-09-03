using System.Threading.Tasks;
using Data.Dto;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserDto>
    {
        Task<UserDto> CredentialsMatchAsync(string email, string password);
        Task<UserDto> GetByEmailAsync(string email);
    }
}