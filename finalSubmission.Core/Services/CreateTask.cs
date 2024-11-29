using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Domain.RepositoryContracts;
using finalSubmission.Core.ServiceContracts;

namespace finalSubmission.Core.Services
{
    public class CreateTask : ICreateTask
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<MyTask> CreateNewTask(MyTask myTask)
        {
            await _taskRepository.AddNewTask(myTask);

            return myTask;

        }
    }
}
