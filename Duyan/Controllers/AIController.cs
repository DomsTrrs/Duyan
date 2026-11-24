using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class AIController : Controller
    {
        // GET: AIController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AIController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AIController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AIController/Create
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

        // GET: AIController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AIController/Edit/5
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

        // GET: AIController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AIController/Delete/5
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
