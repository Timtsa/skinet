using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByEmailAddressAsync(this UserManager<AppUser> input,
         ClaimsPrincipal user)
        {
            var email = user.FindFirst(ClaimTypes.Email);
            return await input.Users.Include(x => x.Address).FirstOrDefaultAsync(x=>x.Email==email.Value);
                                   
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipalAsync(this UserManager<AppUser> input,
         ClaimsPrincipal user)
        {
            var email = user.FindFirst(ClaimTypes.Email);
            return await input.Users.FirstOrDefaultAsync(x=>x.Email==email.Value);
                                   
        }
    }
}