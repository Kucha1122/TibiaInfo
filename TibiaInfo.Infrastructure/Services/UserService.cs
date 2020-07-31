using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserDTO> Authenticate(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(Guid userId, string login, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(login);
            try
            {
                if(user == null)
                {
                    user = new User(userId, role, login, password);
                    await _userRepository.AddAsync(user);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"User with login: '{login}' already exists.", e);
            }
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            try
            {
                if(user != null)
                {
                    await _userRepository.DeleteAsync(user);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByLogin(string login)
        {
            var user = await _userRepository.GetAsync(login);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.BrowseAsyncAllUsers();

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}