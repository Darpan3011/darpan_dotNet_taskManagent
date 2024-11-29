using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Enums;
using finalSubmission.Core.ServiceContracts;
using finalSubmission.Core.ServiceContracts.IUserService;
using finalSubmissionDotNet.Filters;
using Microsoft.AspNetCore.Mvc;

namespace finalSubmissionDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IGetAllTasks _getAllTasks;
        private readonly ICreateTask _createTask;
        private readonly IGetTaskByTitle _getTaskByTitle;
        private readonly IDeleteTask _deleteTask;
        private readonly IEditTask _editTask;
        private readonly IGetTaskByDueDate _getTaskByDueDate;
        private readonly IGetTaskByStatus _getTaskByStatus;
        private readonly IGetAllUsers _getAllUsers;
        private readonly IGetByUserID _getByUserID;

        public AdminController(IGetAllTasks getAllTasks, ICreateTask createTask, IGetTaskByTitle getTaskByTitle, IDeleteTask deleteTask, IEditTask editTask, IGetTaskByDueDate getTaskByDueDate, IGetTaskByStatus getTaskByStatus, IGetAllUsers getAllUsers, IGetByUserID getByUserID)
        {
            _getAllTasks = getAllTasks;
            _createTask = createTask;
            _getTaskByTitle = getTaskByTitle;
            _deleteTask = deleteTask;
            _editTask = editTask;
            _getTaskByStatus = getTaskByStatus;
            _getTaskByDueDate = getTaskByDueDate;
            _getAllUsers = getAllUsers;
            _getByUserID = getByUserID;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTasks()
        {
            List<MyTask> myTasks = await _getAllTasks.GetAllPossibleTasks();

            return Ok(myTasks);
        }

        [HttpPost("[action]")]
        [TypeFilter(typeof(ModelValidationActionFilter))]
        public async Task<IActionResult> AddTask([FromBody] MyTask task)
        {
            if (string.IsNullOrEmpty(task.Status))
            {
                task.Status = "Pending";
            }

            try
            {
                var createdTask = await _createTask.CreateNewTask(task);
                return Ok(createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("[action]/{Title}")]
        public async Task<IActionResult> DeleteTask(string Title)
        {
            if (await _getTaskByTitle.GetMyTaskByATitle(Title) is not null)
            {
                bool issuccess = await _deleteTask.DeleteATask(Title);
                if (issuccess)
                    return Ok();

                else BadRequest();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("[action]")]
        [TypeFilter(typeof(ModelValidationActionFilter))]
        public async Task<IActionResult> EditTheTask(MyTask myTask)
        {
            await _editTask.EditATask(myTask);

            return Ok(myTask);
        }

        [HttpGet("[action]/{dateTime}")]
        public async Task<List<MyTask>> GetAllTaskByDueDate(DateTime dateTime)
        {
            List<MyTask> myTasks = await _getTaskByDueDate.GetTaskByADueDate(dateTime);

            return myTasks;
        }

        [HttpGet("[action]/{status}")]
        public async Task<List<MyTask>> GetAllTaskByStatus(string status)
        {
            List<MyTask> myTasks = await _getTaskByStatus.GetTasksByAStatus(status);

            return myTasks;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _getAllUsers.GetAllAUsers());

        }

        [HttpGet("[action]")]
        public async Task<List<MyTask>?> GetTasksByUserID(Guid userID)
        {

            List<MyTask> myTasks = await _getByUserID.GetTaskByUserID(userID);

            return myTasks;

        }
    }
}
