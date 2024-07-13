using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.DTOs.User;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Controllers.User
{
    [ApiController]
    [Route("api/user/contract")]
    [Authorize]
    public class ContractController : Controller
    {
       
        private readonly IContractService _service;

        public ContractController(IContractService service)
        {
            _service = service;
        }

        [HttpGet]

        [HttpGet("{login}")]
        public async Task<IActionResult> Get(string login)
        {
            var users = await _service.GetUserContract(login);
            return Ok(users);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserContractDto contract)
        {
            var answer = await _service.UpdateUserContract(contract);
            return Ok(answer);
        }

    }
}
