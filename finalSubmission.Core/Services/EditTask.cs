﻿using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Domain.RepositoryContracts;
using finalSubmission.Core.ServiceContracts;

namespace finalSubmission.Core.Services
{
    public class EditTask : IEditTask
    {
        private readonly ITaskRepository _taskRepository;

        public EditTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<MyTask> EditATask(MyTask myTask)
        {
            MyTask myTask1 =  await _taskRepository.EditATask(myTask);

            return myTask1;
        }
    }
}
