using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Duyan.Controllers
{
    public class RoomTypeController : Controller
    {
        // GET: RoomTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RoomTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomTypeController/Create
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

        // GET: RoomTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomTypeController/Edit/5
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

        // GET: RoomTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomTypeController/Delete/5
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
