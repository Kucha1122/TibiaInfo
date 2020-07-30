using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TibiaInfo.Core.Models;


namespace TibiaInfo.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string login);
        Task<IEnumerable<User>> BrowseAsyncAllUsers();
        Task AddAsync(User user);
        Task DeleteAsync(User user);
    }
}