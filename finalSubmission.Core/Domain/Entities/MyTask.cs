using finalSubmission.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finalSubmission.Core.Domain.Entities
{
    public class MyTask
    {
        [Key]
        [Required(ErrorMessage = "{0} is required")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(4)]
        public required string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public required Guid UserId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public required DateTime DueDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public CustomTaskStatus Status { get; set; } = CustomTaskStatus.Pending;

    }
}
