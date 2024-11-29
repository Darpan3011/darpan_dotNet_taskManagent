using ContactsManager.Core.Domain.IdentityEntities;
using finalSubmission.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace finalSubmission.Infrastructure.DbContexts
{
    public class TaskOrderDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public TaskOrderDbContext(DbContextOptions options) : base(options) { }
        public DbSet<MyTask> AllTasksTable { get; set; }

        public DbSet<User> AllUsersTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MyTask>().ToTable("AllTasksTable");
            builder.Entity<User>().ToTable("AllUsersTable");
        }
    }
}
