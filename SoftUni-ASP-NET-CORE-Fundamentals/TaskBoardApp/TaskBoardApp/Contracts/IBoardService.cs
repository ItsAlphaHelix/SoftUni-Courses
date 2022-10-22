using TaskBoardApp.Models;

namespace TaskBoardApp.Contracts
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardViewModel>> GetAllBoardsTasksAsync();
    }
}
