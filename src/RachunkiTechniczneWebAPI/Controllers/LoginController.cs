using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RachunkiTechniczneWebApi.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RachunkiTechniczneWebApi.Models;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto userLogin)
        {
            var returnData = await _loginService.Login(userLogin);
            if (returnData != null)
            {
                return Ok(returnData);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
