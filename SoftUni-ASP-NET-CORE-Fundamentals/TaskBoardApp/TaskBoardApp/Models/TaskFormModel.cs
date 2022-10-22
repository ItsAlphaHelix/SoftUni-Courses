using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.Constants.DataConstants.Task;

namespace TaskBoardApp.Models
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(MaxTaskTitle, MinimumLength = MinTaskTitle, ErrorMessage = "Title should be at leat {2} characters long")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxTaskTitle, MinimumLength = MinTaskTitle, ErrorMessage = "Description should be at leat {2} characters long")]
        public string Description { get; set; }

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
    }
}
