using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Contracts;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class TasksController : BaseController
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TaskFormModel()
            {
                Boards = await this.taskService.GetBoardsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!this.taskService.GetBoardsAsync().Result.Any(b => b.Id == model.BoardId))
            {
                this.ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            await this.taskService.CreateTaskAsync(model);

            return RedirectToAction("All", "Boards");
        }

        public async Task<IActionResult> Details(int id)
        {
           var model = await this.taskService.DetailsTaskAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        } 

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.taskService.ShowEditViewTaskAsync(id);
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        { 
            if (!this.taskService.GetBoardsAsync().Result.Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
            }

            var editedTask = await this.taskService.EditTaskAsync(id, taskModel);
            await editedTask.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await this.taskService.ShowDeleteViewTaskAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskmodel)
        {
            var deletedTask = this.taskService.DeleteTask(taskmodel);
            await deletedTask.Result.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }
    }
}
