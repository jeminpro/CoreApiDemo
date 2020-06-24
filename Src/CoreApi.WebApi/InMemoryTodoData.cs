using CoreApi.Common;
using System.Collections.Generic;

namespace CoreApi.WebApi
{
    public static class InMemoryTodoData
    {
        public static List<TodoItem> TodoItems { get; set; }

        static InMemoryTodoData()
        {
            TodoItems = new List<TodoItem>(){
                new TodoItem { Id = 1, Name = "Planning", IsComplete = false},
                new TodoItem { Id = 2, Name = "Design", IsComplete = false },
                new TodoItem { Id = 3, Name = "Color Palette", IsComplete = false },
                new TodoItem { Id = 4, Name = "Mockup", IsComplete = false },
                new TodoItem { Id = 5, Name = "Prototype", IsComplete = false },
                new TodoItem { Id = 6, Name = "Developing", IsComplete = false },
                new TodoItem { Id = 7, Name = "Testing", IsComplete = false },
                new TodoItem { Id = 8, Name = "Deploying", IsComplete = false },
            };
        }
    }
}
