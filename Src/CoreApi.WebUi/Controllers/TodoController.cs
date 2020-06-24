using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Common;
using CoreApi.WebUi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.WebUi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly CoreApiService _coreApiService;

        public TodoController(
            CoreApiService coreApiService)
        {
            _coreApiService = coreApiService;
        }

        [HttpGet]
        public async Task<List<TodoItem>> GetToDoItems()
        {
            return await _coreApiService.GetToDoItems();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem todoItem)
        {
            return await _coreApiService.CreateTodoItem(todoItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var isSuccess = await _coreApiService.DeleteTodoItem(id);

            if (isSuccess)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem todoItem)
        {
            var isSuccess = await _coreApiService.UpdateTodoItem(id, todoItem);

            if (isSuccess)
                return Ok();
            else
                return NotFound();
        }
    }
}
