using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/contract")]
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
