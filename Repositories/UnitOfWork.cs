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
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly AppDbContext _context;
        public IRepository<Book> Books { get; }
        public IRepository<Messages> Messages { get; }

        public UnitOfWork(AppDbContext context, IRepository<Book> bookRepository, IRepository<Messages> messagesRepository)
        {
            _context = context;
            Books = bookRepository;
            Messages = messagesRepository;
        }

        //public BookRepository Books
        //{
        //    get
        //    {
        //        return bookRepository = bookRepository ?? new BookRepository(_context);
        //    }
        //}

        //public MessagesRepository Messages
        //{
        //    get
        //    {
        //        return messagesRepository = messagesRepository ?? new MessagesRepository(_context);
        //    }
        //}

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }

    }
}
