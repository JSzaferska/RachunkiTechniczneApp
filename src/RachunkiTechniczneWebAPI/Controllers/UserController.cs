using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RachunkiTechniczneWebApi.Controllers
{
    public class UserController : Controller
    {
        // GET: UzytkownicyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UzytkownicyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UzytkownicyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UzytkownicyController/Create
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

        // GET: UzytkownicyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UzytkownicyController/Edit/5
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

        // GET: UzytkownicyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UzytkownicyController/Delete/5
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
    }
}
