using System.Web.Mvc;
using Auction.Models;
using Auction.Repositories;

namespace Auction.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
            AuctionRepository repository = new AuctionRepository();
            ModelState.Clear();
            return View(repository.GetAll());
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            return View(new AuctionModel());
        }

        // POST: Auction/Create
        [HttpPost]
        public ActionResult Create(AuctionModel ModelObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AuctionRepository repository = new AuctionRepository();
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

        // GET: Auction/Edit/5
        public ActionResult Edit(int id)
        {
            AuctionRepository repository = new AuctionRepository();

            AuctionModel model = repository.GetById(id);

            return View(model);
        }

        // POST: Auction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AuctionModel ModelObject)
        {
            try
            {
                AuctionRepository repository = new AuctionRepository();
                repository.Update(ModelObject);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auction/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                AuctionRepository repository = new AuctionRepository();
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
