using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
    public static class ApplicationIdentityDataSeed
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            // We will not make a json file to seed data , but we will seed the ONLY ONE user here

            if(!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    DisplayName = "Mahmoud Shoura",
                    Email = "mahmoud.shoura.dev@gmail.com",
                    UserName = "mahmoud.shoura.dev",
                    PhoneNumber = "0112233445566"
                };

                await userManager.CreateAsync(user,"P@ssw0rd");
            }
        }
    }
}
