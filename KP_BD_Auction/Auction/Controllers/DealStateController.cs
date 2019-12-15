using System.Web.Mvc;
using Auction.Models;
using Auction.Repositories;

namespace Auction.Controllers
{
    public class DealStateController : Controller
    {
        // GET: DealState
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
            DealStateRepository repository = new DealStateRepository();
            ModelState.Clear();
            return View(repository.GetAll());
        }

        // GET: DealState/Create
        public ActionResult Create()
        {
            return View(new DealStateModel());
        }

        // POST: DealState/Create
        [HttpPost]
        public ActionResult Create(DealStateModel ModelObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DealStateRepository repository = new DealStateRepository();
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

        // GET: DealState/Edit/5
        public ActionResult Edit(int id)
        {
            DealStateRepository repository = new DealStateRepository();

            DealStateModel model = repository.GetById(id);

            return View(model);
        }

        // POST: DealState/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DealStateModel ModelObject)
        {
            try
            {
                DealStateRepository repository = new DealStateRepository();
                repository.Update(ModelObject);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }
        }

        // GET: DealState/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DealStateRepository repository = new DealStateRepository();
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
