﻿using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Enums;

namespace finalSubmission.Core.ServiceContracts
{
    public interface IGetTaskByStatus
    {
        public Task<List<MyTask>> GetTasksByAStatus(string customTaskStatus);
    }
}