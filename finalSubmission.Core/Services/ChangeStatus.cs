using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Domain.RepositoryContracts;
using finalSubmission.Core.ServiceContracts;

namespace finalSubmission.Core.Services
{
    public class ChangeStatus : IChangeStatus
    {
        private readonly ITaskRepository _taskRepository;

        public ChangeStatus(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<MyTask> ChangeAStatus(string Title, string newStatus)
        {

            MyTask myTask = await _taskRepository.UpdateTaskStatus(Title, newStatus);

            return myTask;
        }
    }
}
