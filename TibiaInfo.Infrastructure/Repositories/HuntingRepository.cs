using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.Context;

namespace TibiaInfo.Infrastructure.Repositories
{
    public class HuntingRepository : IHuntingRepository
    {
        private AppDbContext _context;

        public HuntingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Hunting> GetAsync(Guid id)
            => await Task.FromResult(_context.Huntings.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Hunting>> BrowseAsyncAllHuntings()
        {
            var huntings = _context.Huntings.AsEnumerable();

            return await Task.FromResult(huntings);
        }

        public async Task<IEnumerable<Hunting>> BrowseAsyncAllCharacterHuntings(string nickname)
        {
            var huntings = _context.Huntings.AsEnumerable();

            foreach(var hunting in huntings)
            {
                hunting.CharacterHuntingInfos.Contains(nickname);
            }
        }

        public async Task AddAsync(Hunting hunting)
        {
            _context.Huntings.Add(hunting);
            _context.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Hunting hunting)
        {
            _context.Remove(hunting);

            await Task.CompletedTask;
        }
    }
}