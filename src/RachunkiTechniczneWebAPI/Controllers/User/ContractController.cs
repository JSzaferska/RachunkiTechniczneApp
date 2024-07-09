using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Interfaces.User;

namespace RachunkiTechniczneWebApi.Controllers.User
{
    [ApiController]
    [Route("api/user/contract")]
    public class ContractController : Controller
    {
       
        private readonly IContractService _service;

        public ContractController(IContractService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = "LJAKOW";
            var users = await _service.GetUserContract(user);
            return Ok(users);
        }

    }
}
