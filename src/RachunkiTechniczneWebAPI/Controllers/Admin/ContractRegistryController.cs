using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/registry")]
    public class ContractRegistryController : Controller
    {
       
        private readonly IContractService _service;

        public ContractRegistryController(IContractService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetRegistryContract();
            return Ok(result);
        }
    }
}
