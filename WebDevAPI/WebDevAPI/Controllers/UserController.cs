using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Domain;
using DataAccess.Repository;
using WebDevAPI.Dto;

namespace WebDevAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("GetUser")]
        public IActionResult GetUser([FromBody] UserDto user)
        {
            var dbUsers = _userRepository.GetUsers();

            var dbUser = dbUsers.FirstOrDefault(o => o.Name == user.Username && o.Password == user.Password);

            if (dbUser == null)
            {
                return BadRequest();
            }

            return Ok(new UserDto
            {
                Id = dbUser.Id,
                Username = dbUser.Name
            });
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new User
            {
                Name = userDto.Username,
                Password = userDto.Password,
            };

            _userRepository.AddUser(user);

            var result = new UserDto
            {
                Id = user.Id,
                Username = userDto.Username,
                Password = userDto.Password
            };
            return Ok(result);
        }
    }
}
