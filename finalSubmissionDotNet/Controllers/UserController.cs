using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.ServiceContracts.IUserService;
using finalSubmissionDotNet.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace finalSubmissionDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUser _createUser;
        private readonly IDeleteUser _deleteUser;

        public UserController(ICreateUser createUser, IDeleteUser deleteUser)
        {
            _createUser = createUser;
            _deleteUser = deleteUser;
        }

        [HttpPost("[action]")]
        [TypeFilter(typeof(ModelValidationActionFilter))]
        public async Task<IActionResult> CreateUser(string UserName)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                return BadRequest(new { message = "Username cannot be null or empty." });
            }

            // Initialize a new user with a unique ID
            User user = new User() { UserName = UserName, UserId = Guid.NewGuid() };

            try
            {
                // Attempt to create the user
                var createdUser = await _createUser.CreateAnUser(user);

                if (createdUser == null)
                {
                    return Conflict(new { message = $"User with username '{UserName}' already exists." });
                }

                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                // Log the exception (pseudo-code for logging is provided)
                // Log.Error(ex, "Error occurred while creating a user");
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }



        [HttpDelete("[action]/{UserName}")]
        public async Task<IActionResult> DeleteUser(string UserName)
        {
            try
            {
                if (string.IsNullOrEmpty(UserName))
                {
                    return BadRequest("Username cannot be null or empty.");
                }

                // Attempt to delete the user
                User? user = await _deleteUser.DeleteAnUser(UserName);

                if (user is not null)
                {
                    return Ok($"User '{UserName}' deleted successfully.");
                }

                return NotFound($"User with username '{UserName}' does not exist.");
            }
            catch (Exception ex)
            {
                // Log exception and return a generic error message
                // Log.Error(ex, "Error occurred while deleting user."); // Example logging statement
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


    }
}
