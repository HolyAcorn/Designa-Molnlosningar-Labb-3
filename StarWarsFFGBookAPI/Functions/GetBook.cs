using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using StarWarsFFGBookAPI.Services;

namespace StarWarsFFGBookAPI;

public class GetBook
{
    private readonly ILogger<GetBook> _logger;

    private readonly IBookService _service;
    public GetBook(ILogger<GetBook> logger, IBookService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GetBook")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "book/{id}")] HttpRequest req, string id)
    {
        _logger.LogInformation($"Getting book with id: {id}");
        var book = await _service.GetBookAsync(new Guid(id));
        return new OkObjectResult(book);
    }
}