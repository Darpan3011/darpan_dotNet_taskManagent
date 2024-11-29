﻿using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Domain.RepositoryContracts;
using finalSubmission.Core.ServiceContracts;

namespace finalSubmission.Core.Services
{
    public class GetByUserID : IGetByUserID
    {
        private readonly ITaskRepository _taskRepository;

        public GetByUserID(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<List<MyTask>> GetTaskByUserID(Guid userId)
        {
            List<MyTask>? myTasks = await _taskRepository.GetAllTasksByUserID(userId);

            return myTasks;
        }
    }
}
