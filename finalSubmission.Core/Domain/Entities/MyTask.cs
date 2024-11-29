using finalSubmission.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finalSubmission.Core.Domain.Entities
{
    public class MyTask
    {
        [Key]
        [Required(ErrorMessage = "{0} is required")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public required Guid UserId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public required DateTime DueDate { get; set; }

        [DefaultValue("Pending")]
        public string Status { get; set; } = "Pending";


        public override string ToString()
        {
            return $"Task: {Title}\n" +
                   $"Description: {Description}\n" +
                   $"Assigned To User ID: {UserId}\n" +
                   $"Due Date: {DueDate.ToShortDateString()}\n" +
                   $"Status: {Status}";
        }

    }
}
