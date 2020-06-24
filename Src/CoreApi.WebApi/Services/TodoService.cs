using CoreApi.Common;
using CoreApi.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.WebApi.Services
{
    public class TodoService: ITodoService
    {
        public TodoService()
        {

        }

        public List<TodoItem> GetAllTodoItems()
        {
            return InMemoryTodoData.TodoItems;
        }

        public TodoItem GetTodoItem(int id)
        {
            return InMemoryTodoData.TodoItems.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateTodoItem(int id, TodoItem todoItem)
        {
            foreach(var item in InMemoryTodoData.TodoItems)
            {
                if(item.Id == id)
                {
                    item.IsComplete = todoItem.IsComplete;
                    
                    return true;
                }
            }

            return false;
        }

        public TodoItem CreateTodoItem(TodoItem todoItem)
        {
            var lastItem = InMemoryTodoData.TodoItems.OrderByDescending(t => t.Id).FirstOrDefault();
            todoItem.Id = lastItem != null ? lastItem.Id + 1 : 1;            
            InMemoryTodoData.TodoItems.Add(todoItem);
            return todoItem;
        }

        public bool DeleteTodoItem(int id)
        {
            var currentTodoItem = GetTodoItem(id);

            if (currentTodoItem == null)
            {
                return false;
            }

            InMemoryTodoData.TodoItems.Remove(currentTodoItem);

            return true;
        }

    }
}
