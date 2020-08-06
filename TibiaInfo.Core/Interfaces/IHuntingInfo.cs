using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TibiaInfo.Core.Models;


namespace TibiaInfo.Core.Interfaces
{
    public interface IHuntingInfo
    {
        Task<HuntingInfo> GetAsync(Guid id);
        Task<IEnumerable<HuntingInfo>> BrowseAsyncAllHuntings();
        Task AddAsync(HuntingInfo huntingInfo);
        Task DeleteAsync(HuntingInfo huntingInfo);
    }
}