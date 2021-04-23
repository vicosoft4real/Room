using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Room.Assignment.Identity.Models;

namespace Room.Assignment.Identity.Seed
{
    /// <summary>
    /// 
    /// </summary>
    public static class UserSeeding
    {
        /// <summary>
        /// Seeds the user asynchronous.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Victor",
                LastName = "Oluwayemi",
                UserName = "vicosoft",
                Email = "vicosoft4real@gmail.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "P@ssw0rd123");
            }
            var applicationUser2 = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                Email = "vicosoft4real@gmail.com",
                EmailConfirmed = true
            };

            var user2 = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user2 == null)
            {
                await userManager.CreateAsync(applicationUser2, "P@ssw0rd123");
            }
        }
    }
}