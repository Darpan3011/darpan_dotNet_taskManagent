using finalSubmission.Core.Domain.Entities;

namespace finalSubmission.Core.ServiceContracts
{
    public interface IDeleteTask
    {
        public Task<bool> DeleteATask(string Title);
    }
}
