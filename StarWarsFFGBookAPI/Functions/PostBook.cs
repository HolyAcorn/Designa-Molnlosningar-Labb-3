using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using StarWarsFFGBookAPI.Services;

namespace StarWarsFFGBookAPI;

public class PostBook
{
    private IBookService _service;

    public PostBook(IBookService service)
    {
        _service = service;
    }
    

    [Function("PostBook")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "book" )] HttpRequestData req)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var bookToCreate = JsonConvert.DeserializeObject<Book>(requestBody);
        bookToCreate.Id = Guid.NewGuid();
        var book = await _service.PostBookAsync(bookToCreate);
        if (book == null) return new BadRequestObjectResult($"Book with {bookToCreate.Id} exists!");
        var responseMsg = $"Book is created, the id is {book.Id}";
        return new OkObjectResult(responseMsg);
    }
}