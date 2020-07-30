using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.Context;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<UserDTO> Authenticate(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(Guid userId, string login, string password, string role = "user")
        {
            var user = await _context.Users.FindAsync(login);
            try
            {
                if(user == null)
                {
                    user = new User(userId, role, login, password);
                    await _context.Users.AddAsync(user);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"User with login: '{login}' already exists.", e);
            }
        }

        public async Task Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            try
            {
                if(user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            return _mapper.Map<UserDTO>(user);
        }
    }
}