using System.Web.Mvc;
using Auction.Models;
using Auction.Repositories;

namespace Auction.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
            ItemRepository repository = new ItemRepository();
            ModelState.Clear();
            return View(repository.GetAll("GetItemsJoin", true));
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ItemCategoryRepository itemCategoryRep = new ItemCategoryRepository();

            ItemModel model = new ItemModel
            {
                ItemCategories = itemCategoryRep.GetAll()
            };

            return View(model);
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(ItemModel ModelObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemRepository repository = new ItemRepository();
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

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            ItemRepository repository = new ItemRepository();
            ItemCategoryRepository itemCategoryRep = new ItemCategoryRepository();

            ItemModel model = repository.GetById(id);
            model.ItemCategories = itemCategoryRep.GetAll();

            return View(model);
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemModel ModelObject)
        {
            try
            {
                ItemRepository repository = new ItemRepository();
                repository.Update(ModelObject);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ItemRepository repository = new ItemRepository();
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
