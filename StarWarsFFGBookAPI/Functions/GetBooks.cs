using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using StarWarsFFGBookAPI.Services;

namespace StarWarsFFGBookAPI.Functions
{
    public class GetBooks
    {
        private readonly ILogger<GetBooks> _logger;
        private IBookService _service;

        public GetBooks(ILogger<GetBooks> logger, IBookService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("GetBooks")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "books")] HttpRequest req)
        {

            
            _logger.LogInformation("Getting all books");
            var books = await _service.GetBooksAsync();
            return new OkObjectResult(books);
        }

    }
}
