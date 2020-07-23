using AutoMapper;
using Data;
using Data.Dto;
using JansenVerhuurAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            return _mapper.Map<User>(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>>(users);
        }

        public async Task CreateAsync(User user)
        {
            await _unitOfWork.UserRepository.CreateAsync(_mapper.Map<UserDto>(user));
        }
    }
}
