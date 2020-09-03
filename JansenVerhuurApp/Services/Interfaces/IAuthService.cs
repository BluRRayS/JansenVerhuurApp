using System.Threading.Tasks;
using Services.Models;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> CredentialsMatchAsync(string email, string password);
    }
}