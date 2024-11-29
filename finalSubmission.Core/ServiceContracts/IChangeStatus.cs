using finalSubmission.Core.Domain.Entities;

namespace finalSubmission.Core.ServiceContracts
{
    public interface IChangeStatus
    {
        public Task<MyTask> ChangeAStatus(string Title, string newStatus);
    }
}
