using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bulky.Models;
using Bulky.DataAccess.Repo.IRepo;
using Microsoft.AspNetCore.Authorization;

namespace DNWb.Controllers
{
    [Authorize]
    public class BulkyBooksController : Controller
    {

        public readonly IUnitOfWork _logger;
        public BulkyBooksController(IUnitOfWork logger)
        {
            _logger = logger;

        }
        // GET: BulkyBooksController
        public ActionResult Index()
        {
            IEnumerable<BulkyBook> res = _logger.bulkybooks.GetAll().ToList();
         
            return View(res);
        }

        // GET: BulkyBooksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BulkyBooksController/Create
        [Authorize(Roles ="admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BulkyBooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BulkyBook model)
        {
            if (ModelState.IsValid)
            {
                _logger.bulkybooks.Add(model);
                _logger.Save();
            }
            ModelState.Clear();

            return View();
        }

        // GET: BulkyBooksController/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BulkyBooksController/Edit/5
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

        // GET: BulkyBooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BulkyBooksController/Delete/5
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
