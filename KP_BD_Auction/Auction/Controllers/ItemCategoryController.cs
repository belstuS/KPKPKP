using System.Web.Mvc;
using Auction.Models;
using Auction.Repositories;

namespace Auction.Controllers
{
    public class ItemCategoryController : Controller
    {
        // GET: ItemCategory
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
            ItemCategoryRepository repository = new ItemCategoryRepository();
            ModelState.Clear();
            return View(repository.GetAll());
        }
        
        // GET: ItemCategory/Create
        public ActionResult Create()
        {
            return View(new ItemCategoryModel());
        }

        // POST: ItemCategory/Create
        [HttpPost]
        public ActionResult Create(ItemCategoryModel ModelObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemCategoryRepository repository = new ItemCategoryRepository();
                    repository.Add(ModelObject);
                    return RedirectToAction("GetAll");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemCategory/Edit/5
        public ActionResult Edit(int id)
        {
            ItemCategoryRepository repository = new ItemCategoryRepository();

            ItemCategoryModel model = repository.GetById(id);

            return View(model);
        }

        // POST: ItemCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemCategoryModel ModelObject)
        {
            try
            {
                ItemCategoryRepository repository = new ItemCategoryRepository();
                repository.Update(ModelObject);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemCategory/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ItemCategoryRepository repository = new ItemCategoryRepository();
                repository.Delete(id);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }
        }
    }
}
