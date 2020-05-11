using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userFroRegisterDto)
        {
            // validate request

            userFroRegisterDto.Username = userFroRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userFroRegisterDto.Username))
                return BadRequest("Username exists");
            
            var userToCreate = new User
            {
                Username = userFroRegisterDto.Username
            };
            
            var createUser = await _repo.Register(userToCreate, userFroRegisterDto.Password);

            // TODO: send route of the user
            
            return StatusCode(201);
        }
    }
}