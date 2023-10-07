using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess.Repo.IRepo;

namespace DNWb.Controllers
{
    public class CategoryController : Controller
    {
       // public readonly ApplicationDbContext _db;

      //  public readonly ICategory _db;
         public readonly IUnitOfWork _db;
        public CategoryController(IUnitOfWork db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
           // IEnumerable<Category> objCategoryList = _db.Categories.ToList();
           IEnumerable<Category> objCategoryList = _db.category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customerror", "The Display Order and Name can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.category.Add(obj);
                _db.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            };
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _db.category.Get(x=>x.Id==id);
            //Category? categoryfromDb = _db.Categories.FirstOrDefault(id)
            //Category? categoryfromDb = _db.Categories.SingleOrDefault(id)
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customerror", "The Display Order and Name can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.category.Update(obj);
                _db.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            };
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
          //  Category? categoryfromDb = _db.Categories.Find(id);
            Category? categoryfromDb = _db.category.Get(x => x.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.category.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

           // _db.Categories.Remove(obj);
            _db.category.Remove(obj);
            _db.Save();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");


        }
        public ActionResult Demo()
        {
           List<DemoModel> dm = new List<DemoModel>(){ 
            new DemoModel()
            {
                Id=1,
                Name="ljlj",
                Description=new String[]{"ljds1","ouue1","sfs"}
            },
            new DemoModel(){
                Id=2,
                Name="hjvg",
                Description=new String[]{"ljds2","ouue2","ljjsdf"}
            }
            };

            return View(dm);
        }

    }
}
