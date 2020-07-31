using System;
using System.Threading.Tasks;
using TibiaInfo.Infrastructure.Commands.Users;
using TibiaInfo.Infrastructure.Services;
using  Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TibiaInfo.API.Controllers
{
    [Route("[controller]")]
    public class UserController : ApiControllerBase
    {
        private IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction(Guid UserId)
            => Json(await _userService.GetById(UserId));

        [HttpPost("get")]
        public async Task<IActionResult> GetAction(string login)
            => Json(await _userService.GetByLogin(login));

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            try
            {
                var id = Guid.NewGuid();
                 await _userService.RegisterAsync(id, command.Login,
                    command.Password, command.Role);
                return Ok(id);
            }
            catch (ApplicationException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Post([FromBody]Auth command)
        {
            try
            {
                var token = await _userService.Authenticate(command.Login, command.Password);
                return Ok(token);
            }
            catch (ApplicationException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
               var users =  await _userService.GetAllUsers();
               return Ok(users);
            }
            catch (ApplicationException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }
    }
}