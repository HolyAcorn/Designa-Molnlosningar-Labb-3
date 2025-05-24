using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StarWarsFFGBookAPI.Services;

namespace StarWarsFFGBookAPI;

public class UpdateBook
{
    private readonly ILogger<UpdateBook> _logger;

    private IBookService _service;
    public UpdateBook(ILogger<UpdateBook> logger, IBookService service)
    {
        _service = service;
        _logger = logger;
    }


    [Function("UpdateBook")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route="book/{id}")] HttpRequest req,
        string id)
    {
        _logger.LogInformation("Updating book");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        Book updatedBook = JsonConvert.DeserializeObject<Book>(requestBody);

        Book book = await _service.PutBookAsync(new Guid(id), updatedBook);
        return new OkObjectResult(book);
    }
}