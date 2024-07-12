using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Interfaces;
using System.Reflection.Metadata.Ecma335;
using static Dapper.SqlMapper;

namespace RachunkiTechniczneWebApi.Controllers.User
{
    [ApiController]
    [Route("api/admin/user")]
    public class UserController : Controller
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _service.GetAllUser();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            try
            {
                var newusers = await _service.AddUserAsync(user);
                return Ok(newusers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            try
            {
                var updatedusers = await _service.UpdateAsync(user);
                return Ok(updatedusers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _service.DeleteUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        
    }
}
