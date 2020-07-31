using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Dto;
using Services.Exceptions;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

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

        public async Task<User> CreateAsync(User user)
        {
            var result = await _unitOfWork.UserRepository.CreateAsync(_mapper.Map<UserDto>(user));
            return _mapper.Map<User>(result);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var result = await _unitOfWork.UserRepository.GetAsync(user.Id);
            if (result == null) throw new NotFoundException();
            result = await _unitOfWork.UserRepository.UpdateAsync(_mapper.Map<UserDto>(user));
            return _mapper.Map<User>(result);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            if (user == null) return false;
            await _unitOfWork.UserRepository.DeleteAsync(id);
            return true;
        }
    }
}