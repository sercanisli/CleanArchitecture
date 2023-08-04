using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using Application.Features.AuthFeatures.Commands.Login;
using Application.Features.AuthFeatures.Commands.Register;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Services
{
    public class AuthServie : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IJwtProvider _jwtProvider;
        public AuthServie(UserManager<User> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.RefreshToken != request.RefreshToken)
            {
                throw new Exception("Refresh token is not valid");
            }

            if (user.RefreshTokenExpiresDate < DateTime.Now)
            {
                throw new Exception("The refresh token has expired");
            }

            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userManager.Users.Where(u =>
                u.UserName == request.userNameOrEmail || u.Email == request.userNameOrEmail).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result =await _userManager.CheckPasswordAsync(user, request.password);
            if (result==true)
            {
                LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
                return response;
            }

            throw new Exception("Your password is incorrect");
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            List<string> emails = new();
            emails.Add(request.Email);
            
            string body = "";

            //await _mailService.SendMailAsync(emails, body, "Mail confirmation");

        }
    }
}
