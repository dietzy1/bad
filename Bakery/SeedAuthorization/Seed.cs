namespace Bakery.Seed;


using System.Security.Claims;
using Models;
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
                FullName = "Jesus Christ the admin"
            };

            var result = userManager.CreateAsync(user, adminPassword).Result;

            if (!result.Succeeded)
            {
                throw new Exception("Failed to seed admin user");
            }

            var adminUser = userManager.FindByNameAsync(adminUsername).Result;


            List<Claim> claims =
            [
                new Claim("IsAdmin", "true"),
                new Claim("Rank", "4")
            ];

            foreach (var claim in claims)
            {
                var claimResult = userManager.AddClaimAsync(adminUser, claim).Result;

                if (!claimResult.Succeeded)
                {
                    throw new System.Exception("Failed to seed admin claim");
                }
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
                UserName = managerUsername,
                FullName = "Zoe the manager"
            };

            var result = userManager.CreateAsync(user, managerPassword).Result;

            if (!result.Succeeded)
            {
                throw new Exception("Failed to seed manager user");
            }

            var managerUser = userManager.FindByNameAsync(managerUsername).Result;

            List<Claim> claims =
            [
                new Claim("IsManager", "true"),
                new Claim("Rank", "3")
            ];

            foreach (var claim in claims)
            {
                var claimResult = userManager.AddClaimAsync(managerUser, claim).Result;

                if (!claimResult.Succeeded)
                {
                    throw new System.Exception("Failed to seed manager claim: ");
                }
            }
        }
    }

    public static void SeedBaker(UserManager<ApiUser> userManager)
    {
        const string bakerUsername = "baker";
        const string bakerPassword = "baker123";

        if (userManager.FindByNameAsync(bakerUsername).Result == null)
        {
            var user = new ApiUser
            {
                UserName = bakerUsername,
                FullName = "Noah the master baker"
            };

            var result = userManager.CreateAsync(user, bakerPassword).Result;

            if (!result.Succeeded)
            {
                throw new System.Exception("Failed to seed baker user");
            }

            var bakerUser = userManager.FindByNameAsync(bakerUsername).Result;

            List<Claim> claims =
            [
                new Claim("IsBaker", "true"),
                new Claim("Rank", "2")
            ];


            foreach (var claim in claims)
            {
                var claimResult = userManager.AddClaimAsync(bakerUser, claim).Result;

                if (!claimResult.Succeeded)
                {
                    throw new System.Exception("Failed to seed baker claim");
                }
            }

        }
    }

    public static void SeedDriver(UserManager<ApiUser> userManager)
    {
        const string driverUsername = "driver";
        const string driverPassword = "driver123";

        if (userManager.FindByNameAsync(driverUsername).Result == null)
        {
            var user = new ApiUser
            {
                UserName = driverUsername,
                FullName = "Star the driver"
            };

            var result = userManager.CreateAsync(user, driverPassword).Result;

            if (!result.Succeeded)
            {
                throw new System.Exception("Failed to seed driver user");
            }

            var driverUser = userManager.FindByNameAsync(driverUsername).Result;

            List<Claim> claims =
            [
                new Claim("IsDriver", "true"),
                new Claim("Rank", "1")
            ];

            foreach (var claim in claims)
            {
                var claimResult = userManager.AddClaimAsync(driverUser, claim).Result;

                if (!claimResult.Succeeded)
                {
                    throw new System.Exception("Failed to seed driver claim");
                }
                throw new Exception("Failed to seed manager claim");
            }
        }
    }
}

