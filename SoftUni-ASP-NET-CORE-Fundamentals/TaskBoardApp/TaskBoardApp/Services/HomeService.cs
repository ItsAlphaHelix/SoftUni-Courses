using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Contracts;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly TaskBoardAppDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public HomeService(
            TaskBoardAppDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<HomeViewModel> GetTasksInfo()
        {
            var taskBoards = await this.context
                .Boards
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();

            var tasksCount = new List<HomeBoardViewModel>();

            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = this.context.Tasks.Where(t => t.Board.Name == boardName).Count();

                tasksCount.Add(new HomeBoardViewModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            var userTasksCount = -1;

            if (this.httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                var currentUserId =  this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                userTasksCount =  this.context.Tasks.Where(t => t.OwnerId == currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = this.context.Tasks.Count(),
                BoardsWithTasksCount = tasksCount,
                UserTasksCount = userTasksCount
            };

            return homeModel;
        }
    }
}
