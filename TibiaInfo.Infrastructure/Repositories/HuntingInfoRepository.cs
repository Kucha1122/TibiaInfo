using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.Context;

namespace TibiaInfo.Infrastructure.Repositories
{
    public class HuntingInfoRepository : IHuntingInfo
    {

        private AppDbContext _context;

        public HuntingInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HuntingInfo> GetAsync(Guid id)
            => await Task.FromResult(_context.HuntingInfos.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<HuntingInfo>> BrowseAsyncAllHuntings()
        {
            var huntingInfos = _context.HuntingInfos.AsEnumerable();

            return await Task.FromResult(huntingInfos);
        }

        public async Task AddAsync(HuntingInfo huntingInfo)
        {
            _context.HuntingInfos.Add(huntingInfo);
            _context.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(HuntingInfo huntingInfo)
        {
            _context.HuntingInfos.Remove(huntingInfo);
            _context.SaveChanges();

            await Task.CompletedTask;
        }
    }
}