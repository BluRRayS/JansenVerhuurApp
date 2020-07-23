using AutoMapper;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Domain;
using JansenVerhuurAPI.Responses;
using JansenVerhuurAPI.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Queries.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userService.CreateAsync(user);
            return _mapper.Map<UserResponse>(user);
        }
    }
}
