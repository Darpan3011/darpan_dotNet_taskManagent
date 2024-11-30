using ContactsManager.Core.Domain.IdentityEntities;
using finalSubmission.Infrastructure.ISeeder;
using Microsoft.AspNetCore.Identity;

namespace finalSubmission.Infrastructure.Seeder
{
    public class RoleSeeder : IRoleSeeder
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleSeeder(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            // add role if not present
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new ApplicationRole { Name = "Admin" });
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new ApplicationRole { Name = "User" });
            }
        }
    }
}
