

namespace Bakery.Seed;

using System.Security.Claims;
using Bakery.Models;
using Microsoft.AspNetCore.Identity;

public static class SeedAuthorization
{
    public static void SeedAdmin(UserManager<ApiUser> userManager)
    {
        const string adminUsername = "admin";
        const string adminPassword = "admin123";

        if (userManager.FindByNameAsync(adminUsername).Result == null)
        {
            var user = new ApiUser
            {
                UserName = adminUsername,
                FullName = "Admin User"
            };

            IdentityResult result = userManager.CreateAsync(user, adminPassword).Result;

            if (!result.Succeeded)
            {
                throw new System.Exception("Failed to seed admin user");
            }

            var adminUser = userManager.FindByNameAsync(adminUsername).Result;
            var claim = new Claim("IsAdmin", "true");

            var claimResult = userManager.AddClaimAsync(adminUser, claim).Result;

            if (!claimResult.Succeeded)
            {
                throw new System.Exception("Failed to seed admin claim");
            }
        }

    }

    public static void SeedManager(UserManager<ApiUser> userManager)
    {
        const string managerUsername = "manager";
        const string managerPassword = "manager123";

        if (userManager.FindByNameAsync(managerUsername).Result == null)
        {
            var user = new ApiUser
            {
                UserName = managerUsername
            };

            var result = userManager.CreateAsync(user, managerPassword).Result;

            if (!result.Succeeded)
            {
                throw new System.Exception("Failed to seed manager user");
            }

            var managerUser = userManager.FindByNameAsync(managerUsername).Result;
            var claim = new Claim("IsManager", "true");

            var claimResult = userManager.AddClaimAsync(managerUser, claim).Result;

            if (!claimResult.Succeeded)
            {
                throw new System.Exception("Failed to seed manager claim");
            }
        }
    }
}

