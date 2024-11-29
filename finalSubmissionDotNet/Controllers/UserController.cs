using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Domain.RepositoryContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace finalSubmissionDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]  // Ensure the user has the "User" role
    public class UserController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public UserController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // Get tasks assigned to the logged-in user
        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasksAssignedToUser()
        {
            var userId = GetUserIdFromToken();

            if (userId == Guid.Empty)
            {
                return Unauthorized(new { message = "User ID not found in token" });
            }

            var tasks = await _taskRepository.GetAllTasksByUserID(userId);

            if (tasks == null || tasks.Count == 0)
            {
                return NotFound(new { message = "No tasks found for the user." });
            }

            return Ok(tasks);
        }

        // Update status of a task assigned to the logged-in user
        [HttpPut("tasks/{taskTitle}/status")]
        public async Task<IActionResult> UpdateTaskStatus(string taskTitle, [FromBody] string newStatus)
        {
            var userId = GetUserIdFromToken();

            if (userId == Guid.Empty)
            {
                return Unauthorized(new { message = "User ID not found in token" });
            }

            var task = await _taskRepository.GetTaskByTitle(taskTitle);
            if (task == null)
            {
                return NotFound(new { message = "Task not found." });
            }

            // Ensure the task is assigned to the logged-in user
            if (task.UserId != userId)
            {
                return Unauthorized(new { message = "You are not authorized to update this task." });
            }

            // Update the task status
            task.Status = newStatus;
            var updatedTask = await _taskRepository.EditATask(task);

            return Ok(updatedTask);
        }

        // Helper method to get the UserId from JWT token
        private Guid GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;
        }
    }
}
