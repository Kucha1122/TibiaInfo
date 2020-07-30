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
        Task RegisterAsync(Guid userId, string login, string password, string role = "user");
        Task Delete(Guid id);
        
    }
}