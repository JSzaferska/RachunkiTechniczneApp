using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractRepository _repository;

        public ContractController(IContractRepository repository)
        {
            _repository = repository;
        }

        // GET api/<KontraktyController>/user
        [HttpGet("{user}")]
        public async Task<IActionResult> Get(string user)
        {
            var users = await _repository.GetByUserAsync(user);
            return Ok(users);
        }

        // GET api/<KontraktyController>/all
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var contracts = await _repository.GetAllAsync();
            return Ok(contracts);
        }


        /*
     // POST: KontraktyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KontraktyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KontraktyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KontraktyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KontraktyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
