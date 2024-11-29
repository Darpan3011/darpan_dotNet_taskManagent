using finalSubmission.Core.Domain.Entities;

namespace finalSubmission.Core.ServiceContracts
{
    public interface ICreateTask
    {
        public Task<MyTask> CreateNewTask(MyTask myTask);
    }
}
