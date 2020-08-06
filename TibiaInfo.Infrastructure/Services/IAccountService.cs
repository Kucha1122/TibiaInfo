using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<TibiaCharacterDTO>> GetAllUserTibiaCharacters(Guid id);
        Task AddTibiaCharacter(Guid id, string nickname);
        Task<HuntingsDTO> GetTibiaCharacterHuntings(string nickname);
    }
}