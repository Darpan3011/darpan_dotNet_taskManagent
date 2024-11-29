using finalSubmission.Core.Domain.Entities;

namespace finalSubmission.Core.ServiceContracts
{
    public interface IGetTaskByDueDate
    {
        public Task<List<MyTask>> GetTaskByADueDate(DateTime dateTime);
    }
}
