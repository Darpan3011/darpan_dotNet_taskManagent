using ContactsManager.Core.Domain.IdentityEntities;
using finalSubmission.Core.Domain.Entities;
using finalSubmission.Infrastructure.DbContexts;
using finalSubmission.Infrastructure.ISeeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace finalSubmission.Infrastructure.Seeder
{
    public class UserAndTaskSeeder : IUserAndTaskSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TaskOrderDbContext _taskOrderDbContext;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserAndTaskSeeder(UserManager<ApplicationUser> userManager, TaskOrderDbContext taskOrderDbContext, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _taskOrderDbContext = taskOrderDbContext;
            _roleManager = roleManager;
        }
        public async Task SeedUsersAsync()
        {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            ApplicationUser adminuser = new ApplicationUser()
            {
                UserName = "admin",
                Id = id,
            };

            IdentityResult adminresult = await _userManager.CreateAsync(adminuser, "Admin301@");

            if (adminresult.Succeeded) {
                await _userManager.AddToRoleAsync(adminuser, "Admin");
                _taskOrderDbContext.AllUsersTable.Add(new User
                {
                    UserId = id,
                    UserName = adminuser.UserName
                });
            }

            ApplicationUser Useruser = new ApplicationUser()
            {
                UserName = "user",
                Id = id2,
            };

            IdentityResult userresult = await _userManager.CreateAsync(Useruser, "User301@");

            if (userresult.Succeeded) {
                await _userManager.AddToRoleAsync(Useruser, "User");
                _taskOrderDbContext.AllUsersTable.Add(new User
                {
                    UserId = id2,
                    UserName = Useruser.UserName
                });
            }

            MyTask? existingTask1 = await _taskOrderDbContext.AllTasksTable.FirstOrDefaultAsync(t => t.Title == "Test");

            if (existingTask1 == null)
            {
                await _taskOrderDbContext.AllTasksTable.AddAsync(new MyTask
                {
                    Title = "Test",
                    Description = "Test Description",
                    UserId = id2,
                    DueDate = DateTime.Now.AddDays(5),
                    Status = Core.Enums.CustomTaskStatus.Completed
                });
            }

            MyTask? existingTask2 = await _taskOrderDbContext.AllTasksTable.FirstOrDefaultAsync(t => t.Title == "Test2");

            if (existingTask2 == null)
            {
                await _taskOrderDbContext.AllTasksTable.AddAsync(new MyTask
                {
                    Title = "Test2",
                    Description = "Test Description 2",
                    UserId = id2,
                    DueDate = DateTime.Now.AddDays(5),
                    Status = Core.Enums.CustomTaskStatus.Pending
                });
            }

            await _taskOrderDbContext.SaveChangesAsync();
        }
    }
}
