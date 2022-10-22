using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.Constants.DataConstants.Task;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTaskTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxTaskDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int? BoardId { get; set; }

        public Board? Board { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; } = null!;

        public User Owner { get; set; } = null!;
    }
}