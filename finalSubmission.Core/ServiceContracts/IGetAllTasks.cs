using finalSubmission.Core.Domain.Entities;

namespace finalSubmission.Core.ServiceContracts
{
    public interface IGetAllTasks
    {
        public Task<List<MyTask>> GetAllPossibleTasks();
    }
}