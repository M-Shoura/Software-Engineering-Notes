using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Services.Contract;

namespace Talabat.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplicationUser user , UserManager<ApplicationUser> userManager)
        {
            // Token consists of (seperated by dots) : 
            // 1 - Header  (we don't make the header)
            // 2 - Payload 
            // 3 - Signature


            // We will start making the claims (registered and private claims) : 

            // Private Claims (User-defined) : 
            var privateClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.DisplayName),        
                new Claim(ClaimTypes.Email,user.Email)
                
                // first parameter can be "Name" or "Email" but it's better to use static class ClaimTypes that contains constants
                
                // Note : Remember the table created in the database "UserClaims" and "RoleClaims" , we can add these as claims here .. 
                //        and also we can add the roles of the user as claims 

                // What is the purpose of doing this ? information exchange , means that we put data inside the auth header instead of making
                // an endpoint that returns this data 
            };

            var userRoles = await userManager.GetRolesAsync(user);

            foreach(var role in userRoles)
            {
                privateClaims.Add( new Claim ( ClaimTypes.Role, role ) );
            }


            // Registered Claims : created when making an object of the token (sent in constructor)



            // Signature : 

            // put the key in the app settings , to change it while the app is running without opening the source code and making any change
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AuthKey"]));



            // making the token object : 
            
            var token = new JwtSecurityToken(                          // passing parameters in the constructor by name 
                audience: _configuration["JWT:ValidAudience"],
                issuer: _configuration["JWT:ValidIssuer"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationsInDays"] ?? "0")),
                claims: privateClaims , 
                signingCredentials: new SigningCredentials(authKey , SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
