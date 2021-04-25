using Microsoft.EntityFrameworkCore;
using SupportApplication.Infrastractures;
using SupportApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportApplication.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        public async Task<Book> GetAsync(int id) => await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        public async Task CreateAsync(Book book) => await _context.Books.AddAsync(book);

        public async Task UpdateAsync(Book book)
        {
            if (_context != null)
                _context.Update(book);
        }

        public async Task DeleteAsync(int id)
        {
            var bookEntity = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookEntity != null)
                _context.Books.Remove(bookEntity);
        }
    }
}
