using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using RestSharp;
using TibiaInfo.Core.Interfaces;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private ITibiaCharacterRepository _tibiaCharacterRepository;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AccountService(ITibiaCharacterRepository tibiaCharacterRepository,
            IUserRepository userRepository, IMapper mapper)
        {
            _tibiaCharacterRepository = tibiaCharacterRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task AddTibiaCharacter(Guid id, string nickname)
        {
           var tibiaCharacter = await _tibiaCharacterRepository.GetAsync(nickname);
            try
            {
                if(tibiaCharacter == null)
                {
                    var requestedTibiaCharacter = await RequestForCharacterData(id, nickname);
                    await _tibiaCharacterRepository.AddAsync(requestedTibiaCharacter);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Character with this: '{nickname}' is already added.", e);
            }   
        }

        public async Task<IEnumerable<TibiaCharacterDTO>> GetAllUserTibiaCharacters(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            var tibiaCharacters = user.TibiaCharacters;
            return _mapper.Map<IEnumerable<TibiaCharacterDTO>>(tibiaCharacters);
        }

        public Task<HuntingsDTO> GetTibiaCharacterHuntings(string nickname)
        {
            throw new NotImplementedException();
        }

        private async Task<TibiaCharacter> RequestForCharacterData(Guid id, string nickname)
        {
            var httpClient = HttpClientFactory.Create();
            var url = $"https://api.tibiadata.com/v2/characters/{nickname}.json";
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            if(httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsAsync<TibiaCharacter>();
                data.UserId = id;

                return data;
            }
            else
            {
                throw new Exception("Cannot fetch the data from TibiaAPI.");
            }     
        }


    }
}