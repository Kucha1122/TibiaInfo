using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TibiaInfo.Infrastructure.Context;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _context;
        public UserService(AppDbContext context)
        {
            
        }

        public Task<UserDTO> Authenticate(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Create(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}