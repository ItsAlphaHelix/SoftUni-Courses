using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Contracts;

namespace TaskBoardApp.Controllers
{
    public class BoardsController : BaseController
    {
        private readonly IBoardService boardService;

        public BoardsController(IBoardService boardService)
        {
            this.boardService = boardService;
        }
        
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var boards = await this.boardService.GetAllBoardsTasksAsync();
            return View(boards);
        }
    }
}
