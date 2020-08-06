using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.Context;

namespace TibiaInfo.Infrastructure.Repositories
{    
    public class CharacterHuntingInfoRepository : ICharacterHuntingInfo
    {
        private AppDbContext _context;

        public CharacterHuntingInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CharacterHuntingInfo> GetAsync(Guid id)
            => await Task.FromResult(_context.CharacterHuntingInfos.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<CharacterHuntingInfo>> BrowseAsyncAllHuntings()
        {
            var characterHuntingInfos = _context.CharacterHuntingInfos.AsEnumerable();

            return await Task.FromResult(characterHuntingInfos);
        }

        public async Task AddAsync(CharacterHuntingInfo characterHuntingInfo)
        {
            _context.CharacterHuntingInfos.Add(characterHuntingInfo);
            _context.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(CharacterHuntingInfo characterHuntingInfo)
        {
            _context.Remove(characterHuntingInfo);

            await Task.CompletedTask;
        }
    }
}