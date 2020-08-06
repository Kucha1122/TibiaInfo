using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TibiaInfo.Core.Models;


namespace TibiaInfo.Core.Interfaces
{
    public interface ITibiaCharacterRepository
    {
        Task<TibiaCharacter> GetAsync(Guid id);
        Task<TibiaCharacter> GetAsync(string name);
        Task<IEnumerable<TibiaCharacter>> BrowseAsyncAllTibiaCharacters();
        Task AddAsync(TibiaCharacter tibiaCharacter);
        Task DeleteAsync(TibiaCharacter tibiaCharacter);
    }
}