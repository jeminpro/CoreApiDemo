using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApi.Common;
using CoreApi.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService   _todoService;

        public TodoItemsController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            return _todoService.GetAllTodoItems();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = _todoService.GetTodoItem(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            var isSuccess = _todoService.UpdateTodoItem(id, todoItem);

            if (!isSuccess)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todoItem)
        {
            return _todoService.CreateTodoItem(todoItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = _todoService.DeleteTodoItem(id);

            if (!todoItem)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
