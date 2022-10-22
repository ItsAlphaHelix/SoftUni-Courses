using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Contracts;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Services
{
    public class BoardService : IBoardService
    {
        private readonly TaskBoardAppDbContext context;

        public BoardService(TaskBoardAppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BoardViewModel>> GetAllBoardsTasksAsync()
        {
            var boards = this.context.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                }).ToListAsync();
  
            return await boards;
        }
    }
}
