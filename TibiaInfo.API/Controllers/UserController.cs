using System;
using System.Threading.Tasks;
using TibiaInfo.Infrastructure.Commands.Users;
using TibiaInfo.Infrastructure.Services;
using  Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TibiaInfo.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction(Guid UserId)
            => Json(await _userService.GetById(UserId));

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            try
            {
                await _userService.RegisterAsync(Guid.NewGuid(), command.Login,
                    command.Password, command.Role);
                return Ok();
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
                await _userService.Authenticate(command.Login, command.Password);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

            
    }
}