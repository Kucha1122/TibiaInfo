using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TibiaInfo.Core.Models;


namespace TibiaInfo.Core.Interfaces
{
    public interface IHuntingRepository
    {
        Task<Hunting> GetAsync(Guid id);
        Task<IEnumerable<Hunting>> BrowseAsyncAllHuntings(string nickname);
        Task AddAsync(Hunting hunting);
        Task DeleteAsync(Hunting hunting);
    }
}