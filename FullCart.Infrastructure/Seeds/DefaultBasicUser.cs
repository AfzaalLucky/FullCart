using FullCart.Application.Enums;
using FullCart.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace FullCart.Infrastructure.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "customer",
                Email = "customer.fullcart@yopmail.com",
                FirstName = "Full",
                LastName = "Cart",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pa$$word123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Customer.ToString());
                }

            }
        }
    }
}
