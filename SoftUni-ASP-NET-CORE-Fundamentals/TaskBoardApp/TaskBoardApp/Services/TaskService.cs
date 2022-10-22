using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using TaskBoardApp.Contracts;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public TaskService(
            TaskBoardAppDbContext context,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task CreateTaskAsync(TaskFormModel model)
        {
            string currentUserId = GetUserId();

            var task = new Data.Models.Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = currentUserId
            };

            await this.context.Tasks.AddAsync(task);
            await this.context.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> DetailsTaskAsync(int id)
        {
            var model = this.context.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                }).FirstOrDefaultAsync();

            return await model;
        }

        public async Task<TaskFormModel> ShowEditViewTaskAsync(int id)
        {
            var task = await ValidatationTask(id);

            var model = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId ?? 0,
                Boards = await GetBoardsAsync()
            };

            return model;
        }

        public async Task<TaskBoardAppDbContext> EditTaskAsync(int id, TaskFormModel taskModel)
        {
            var task = await ValidatationTask(id);

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            return this.context;
        }

        public async Task<IEnumerable<TaskBoardModel>> GetBoardsAsync()
        {
            var model = this.context.Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToListAsync();

            return await model;
        }

        public async Task<TaskViewModel> ShowDeleteViewTaskAsync(int id)
        {
            var task = await ValidatationTask(id);

            var taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return taskModel;
        }
        public async Task<TaskBoardAppDbContext> DeleteTask(TaskViewModel taskModel)
        {
            var task = await ValidatationTask(taskModel.Id);

            this.context.Tasks.Remove(task);

            return this.context;
        }
        private string GetUserId()
            => this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        private async Task<Data.Models.Task> ValidatationTask(int id)
        {
            var task = await this.context.Tasks.FindAsync(id);

            if (task == null)
            {
                throw new NullReferenceException("The task cannot be null!");
            }

            var currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                throw new ArgumentException("Unauthorized");
            }

            return task;
        }
    }
}
