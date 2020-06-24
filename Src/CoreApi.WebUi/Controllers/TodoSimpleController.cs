using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CoreApi.Common;
using CoreApi.WebUi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.WebUi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoSimpleController : Controller
    {
        private HttpClient _client;

        public TodoSimpleController(
            IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("coreapi");
        }

        [HttpGet]
        public async Task<List<TodoItem>> GetToDoItems()
        {
            return await _client.GetFromJsonAsync<List<TodoItem>>("/api/todoitems");
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem todoItem)
        {
            var result = await _client.PostAsJsonAsync<TodoItem>("/api/todoitems", todoItem);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Delete,
                $"/api/todoitems/{id}");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem todoItem)
        {
            var response = await _client.PutAsJsonAsync($"/api/todoitems/{id}", todoItem);

            if (response.IsSuccessStatusCode)
                return Ok();
            else
                return NotFound();
        }
    }
}
