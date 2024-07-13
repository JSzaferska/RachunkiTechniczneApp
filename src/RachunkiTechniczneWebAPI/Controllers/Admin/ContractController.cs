using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/contract")]
    [Authorize(Roles = "admin")]
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
            var result = await _service.GetAllContract();
            return Ok(result);
        }
    }
}
