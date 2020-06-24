using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CoreApi.Common;
using CoreApi.WebUi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoreApi.WebUi.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class IndexModel : PageModel
    {
        private readonly CoreApiService _coreApiService;

        public List<TodoItem> TodoItems { get; set; }

        public IndexModel(
            CoreApiService coreApiService)
        {
            _coreApiService = coreApiService;
        }

        public async Task  OnGetAsync()
        {
            TodoItems = await _coreApiService.GetToDoItems();
        }
    }
}
