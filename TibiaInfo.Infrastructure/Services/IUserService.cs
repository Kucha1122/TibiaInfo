using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Services
{
    public interface IUserService
    {
        Task<TokenDTO> Authenticate(string login, string password);
        Task<UserDTO> GetById(Guid id);
        Task<UserDTO> GetByLogin(string login);
        Task RegisterAsync(Guid userId, string login, string password, string role = "user");
        Task Delete(Guid id);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        
    }
}