using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TibiaInfo.Core.Models;


namespace TibiaInfo.Core.Interfaces
{
    public interface IHuntings
    {
        Task<CharacterHuntingInfo> GetAsync(Guid id);
        Task<IEnumerable<CharacterHuntingInfo>> BrowseAsyncAllHuntings(string nickname);
        Task AddAsync(CharacterHuntingInfo characterHuntingInfo);
        Task DeleteAsync(CharacterHuntingInfo characterHuntingInfo);
    }
}