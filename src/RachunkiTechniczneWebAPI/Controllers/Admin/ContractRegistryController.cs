using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Interfaces;

namespace RachunkiTechniczneWebApi.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/registry")]
    [Authorize(Roles = "admin")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractById(int id)
        {
            var user = await _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddContract([FromBody] AddContractRegistryDto contract)
        {
            var newcontract = await _service.AddRegistryContract(contract);
            return Ok(newcontract);   
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContrast([FromBody] ContractDto contract)
        {
            var updatedContract = await _service.UpdateContract(contract);
            return Ok(updatedContract);         
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContract(int id)
        {
            var user = await _service.DeleteContract(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
