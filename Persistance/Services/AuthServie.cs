using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AuthFeatures.Commands.Register;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Persistance.Services
{
    public class AuthServie:IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        public AuthServie(UserManager<User> userManager, IMapper mapper, IMailService mailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
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
