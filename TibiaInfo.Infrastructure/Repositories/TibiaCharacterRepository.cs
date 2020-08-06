using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.Context;

namespace TibiaInfo.Infrastructure.Repositories
{
    public class TibiaCharacterRepository : ITibiaCharacterRepository
    {
        private AppDbContext _context;
        public TibiaCharacterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TibiaCharacter> GetAsync(Guid id)
            => await Task.FromResult(_context.TibiaCharacters.SingleOrDefault(x => x.Id == id));


        public async Task<TibiaCharacter> GetAsync(string name)
            => await Task.FromResult(_context.TibiaCharacters.SingleOrDefault(x => x.Name == name));
        
        public async Task<IEnumerable<TibiaCharacter>> BrowseAsyncAllTibiaCharacters()
        {
            var tibiaCharacters = _context.TibiaCharacters.AsEnumerable();

            return await Task.FromResult(tibiaCharacters);
        }
        
        public async Task AddAsync(TibiaCharacter tibiaCharacter)
        {
            _context.TibiaCharacters.Add(tibiaCharacter);
            _context.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(TibiaCharacter tibiaCharacter)
        {
            _context.Remove(tibiaCharacter);

            await Task.CompletedTask;
        }
    }
}