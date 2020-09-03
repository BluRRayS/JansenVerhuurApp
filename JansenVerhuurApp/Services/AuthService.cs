using System.Threading.Tasks;
using AutoMapper;
using Data;
using Services.Helpers;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<bool> CredentialsMatchAsync(string email, string password)
        {
            email = email.ToLower();
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            var encryption = new Encryption();
            password = encryption.Hash(password + user.Salt);
            user = await _unitOfWork.UserRepository.CredentialsMatchAsync(email, password);
            return user != null;
        }
    }
}