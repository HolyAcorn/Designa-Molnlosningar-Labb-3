using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsFFGBookAPI.Data;

namespace StarWarsFFGBookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _ctx;

        public BookService(DataContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<List<Book>> GetBooksAsync()
        {
            var books = await _ctx.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var book = await _ctx.Books.FindAsync(id);
            return book;
        }

        public async Task<Book> PostBookAsync(Book book)
        {
            if (await BookExistsAync(book.Name)) return null;
            _ctx.Books.Add(book);
            await _ctx.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var book = await GetBookAsync(id);
            if (book == null) return false;
            _ctx.Books.Remove(book);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<Book> PutBookAsync(Guid id, Book book)
        {
            var bookToBeUpdated = await GetBookAsync(id);
            if (bookToBeUpdated == null || book == null) return null;
            bookToBeUpdated.Name = book.Name;
            bookToBeUpdated.Type = book.Type;
            bookToBeUpdated.ChildOf = book.ChildOf;
            bookToBeUpdated.Sku = book.Sku;
            bookToBeUpdated.WantPriority = book.WantPriority;
            bookToBeUpdated.Price = book.Price;
            bookToBeUpdated.Owned = book.Owned;
            await _ctx.SaveChangesAsync();
            return bookToBeUpdated;
        }

        public async Task<bool> BookExistsAync(string name)
        {
            return await _ctx.Books.FirstOrDefaultAsync(x => x.Name == name) != null;
        }
    }
}
