using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.Constants.DataConstants.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxBoardName)]
        public string Name { get; init; } = null!;

        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
