using TaskBoardApp.Data;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskBoardApp.Contracts
{
    public interface ITaskService
    {
        Task CreateTaskAsync(TaskFormModel model);

        Task<IEnumerable<TaskBoardModel>> GetBoardsAsync();

        Task<TaskDetailsViewModel> DetailsTaskAsync(int id);

        Task<TaskFormModel> ShowEditViewTaskAsync(int id);

        Task<TaskBoardAppDbContext> EditTaskAsync(int id, TaskFormModel taskModel);

        Task<TaskViewModel> ShowDeleteViewTaskAsync(int id);

        Task<TaskBoardAppDbContext> DeleteTask(TaskViewModel taskModel);
    }
}
