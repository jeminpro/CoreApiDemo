using CoreApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.WebApi.Services.Interfaces
{
    public interface ITodoService
    {
        List<TodoItem> GetAllTodoItems();

        TodoItem GetTodoItem(int id);

        bool UpdateTodoItem(int id, TodoItem todoItem);

        TodoItem CreateTodoItem(TodoItem todoItem);

        bool DeleteTodoItem(int id);
    }
}
