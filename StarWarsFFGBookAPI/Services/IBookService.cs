using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsFFGBookAPI.Services
{
    public interface IBookService
    {

        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(Guid id);
        Task<Book> PostBookAsync(Book book);
        Task<bool> DeleteBookAsync(Guid id);
        Task<Book> PutBookAsync(Guid id, Book book);
    }
}
