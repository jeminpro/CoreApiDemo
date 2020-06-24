using CoreApi.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreApi.WebUi.Services
{
    public class CoreApiService
    {
        public HttpClient Client { get; }

        private readonly IConfiguration _configuration;

        public CoreApiService(
            IConfiguration configuration,
            HttpClient client)
        {
            Client = client;
            _configuration = configuration;

            var baseUrl = _configuration.GetValue<string>("CoretApiBaseUrl");
            client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<List<TodoItem>> GetToDoItems()
        {
            var response = await Client.GetAsync("/api/todoitems");
            return await GetResponse<List<TodoItem>>(response);
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            var response = await Client.GetAsync($"/api/todoitems{id}");
            return await GetResponse<TodoItem>(response);
        }

        public async Task<bool> UpdateTodoItem(int id, TodoItem todoItem)
        {
            var response = await Client.PutAsync($"/api/todoitems/{id}", ToJsonStringContent(todoItem));
            return response.IsSuccessStatusCode;
        }

        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            var response = await Client.PostAsync("/api/todoitems", ToJsonStringContent(todoItem));
            return await GetResponse<TodoItem>(response);
        }

        public async Task<bool> DeleteTodoItem(int id)
        {
            var response = await Client.DeleteAsync($"/api/todoitems/{id}");

            return response.IsSuccessStatusCode;
        }

        private async Task<T> GetResponse<T>(HttpResponseMessage httpResponseMessage)
        {
            httpResponseMessage.EnsureSuccessStatusCode();

            using var responseStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return await JsonSerializer.DeserializeAsync<T>(responseStream, serializeOptions);
        }

        private StringContent ToJsonStringContent(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }
    }
}
