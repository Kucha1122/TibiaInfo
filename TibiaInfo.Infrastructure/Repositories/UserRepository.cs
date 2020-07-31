using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.Context;

namespace TibiaInfo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string login)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Login == login));

        public async Task<IEnumerable<User>> BrowseAsyncAllUsers()
        {
            var users = _context.Users.AsEnumerable();

            return await Task.FromResult(users);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(User user)
        {
            _context.Remove(user);

            await Task.CompletedTask;
        }

    }
}