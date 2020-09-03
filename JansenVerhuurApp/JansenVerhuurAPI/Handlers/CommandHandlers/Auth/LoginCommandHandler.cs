using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JansenVerhuurAPI.Commands.Auth;
using JansenVerhuurAPI.Options;
using JansenVerhuurAPI.Responses;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace JansenVerhuurAPI.Handlers.CommandHandlers.Auth
{
    public class LoginCommandHandler: IRequestHandler<LoginCommand, AuthenticationResponse>
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly JwtOptions _jwtOptions;

        public LoginCommandHandler(IUserService userService, IAuthService authService, JwtOptions jwtOptions)
        {
            _authService = authService;
            _userService = userService;
            _jwtOptions = jwtOptions;
        }

        public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

            if (user == null)
            {
                return new AuthenticationResponse()
                {
                    Errors = new[] {"User does not exist"}
                };
            }

            var userHasValidPassword = await _authService.CredentialsMatchAsync(request.Email,request.Password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResponse
                {
                    Errors = new[] {"User/password combination is wrong"}
                };
            }

            return new AuthenticationResponse()
            {
                Success = true,
                Token = GenerateJsonWebToken(user)
            };
        }
        
        private string GenerateJsonWebToken(Services.Models.User user)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(
                expires: DateTime.Now.Add(_jwtOptions.TokenLifetime),    
                signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
        
    }
}