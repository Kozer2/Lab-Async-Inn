﻿using Async_Inn.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Inn.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration configuration;
        private readonly SignInManager<ApplicationUser> signInManager;

        public JwtTokenService(IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        public async Task<string> GetToken(ApplicationUser user, TimeSpan expiresIn)
        {
            var principal = await signInManager.CreateUserPrincipalAsync(user);
            if (principal == null)
                return null;


            var signingKey = GetSecurityKey(configuration);
            return "token!"; 
        }
            
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secret = configuration["JWT:Secret"];

            if (secret == null)
                throw new InvalidOperationException("JWT:Secret is missing!");

            var secretBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(secretBytes);
        }


    }
}
