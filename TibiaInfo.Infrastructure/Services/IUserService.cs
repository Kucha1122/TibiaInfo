using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDTO> Authenticate(string login, string password);
        Task<UserDTO> GetById(Guid id);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> Create(UserDTO user);
        Task Delete(Guid id);
        
    }
}