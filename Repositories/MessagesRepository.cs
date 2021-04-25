using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SupportApplication.Infrastractures;
using SupportApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportApplication.Repositories
{
    public class MessagesRepository : IRepository<Messages>
    {
        private readonly AppDbContext _context;

        public MessagesRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Messages>> GetAllAsync() => await _context.Messages.ToListAsync();

        public async Task<Messages> GetAsync(int id) => await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);

        public async Task CreateAsync(Messages message) => await _context.Messages.AddAsync(message);

        public async Task UpdateAsync(Messages message)
        {
            if (_context != null)
                _context.Update(message);
        }

        public async Task DeleteAsync(int id)
        {
            var messageEntity = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);

            if (messageEntity != null)
                _context.Messages.Remove(messageEntity);
        }
    }
}
