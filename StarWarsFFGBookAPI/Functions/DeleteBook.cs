using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using StarWarsFFGBookAPI.Services;
using static System.Reflection.Metadata.BlobBuilder;
using Guid = System.Guid;

namespace StarWarsFFGBookAPI;

public class DeleteBook
{
    private readonly ILogger<DeleteBook> _logger;

    private readonly IBookService _service;
    public DeleteBook(ILogger<DeleteBook> logger, IBookService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("DeleteBook")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "book/{id}")] HttpRequest req, string id)
    {
        _logger.LogInformation("Removing book");
        var isSuccess = await _service.DeleteBookAsync(new Guid(id));
        return new OkObjectResult($"The book is deleted: {isSuccess}");
    }
}