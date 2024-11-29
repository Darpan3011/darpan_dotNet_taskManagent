using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Domain.RepositoryContracts;
using finalSubmission.Core.ServiceContracts;

namespace finalSubmission.Core.Services
{
    public class GetTaskByDueDate : IGetTaskByDueDate
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByDueDate(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<MyTask>> GetTaskByADueDate(DateTime dateTime)
        {
            List<MyTask> myTasks = await _taskRepository.GetAllTasksByDueDate(dateTime);

            return myTasks;
        }
    }
}
