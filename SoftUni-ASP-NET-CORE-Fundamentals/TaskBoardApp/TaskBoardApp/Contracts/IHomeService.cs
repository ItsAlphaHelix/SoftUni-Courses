using TaskBoardApp.Models;

namespace TaskBoardApp.Contracts
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetTasksInfo();
    }
}
