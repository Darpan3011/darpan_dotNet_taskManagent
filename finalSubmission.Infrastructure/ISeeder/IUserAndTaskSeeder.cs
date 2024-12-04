using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalSubmission.Infrastructure.ISeeder
{
    public interface IUserAndTaskSeeder
    {
        public Task SeedUsersAsync();
    }
}
