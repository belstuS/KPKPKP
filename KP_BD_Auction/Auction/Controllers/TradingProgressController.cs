using System.Web.Mvc;
using Auction.Models;
using Auction.Repositories;

namespace Auction.Controllers
{
    public class TradingProgressController : Controller
    {
        // GET: TradingProgress
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
            TradingProgressRepository repository = new TradingProgressRepository();
            ModelState.Clear();
            return View(repository.GetAll("GetTradingProgressJoin", true));
        }

        // GET: TradingProgress/Create
        public ActionResult Create()
        {
            ParticipantRepository participantRep = new ParticipantRepository();
            DealRepository dealRep = new DealRepository();

            TradingProgressModel model = new TradingProgressModel
            {
                Buyers = participantRep.GetAll(),
                Deals = dealRep.GetAll()
            };

            return View(model);
        }

        // POST: TradingProgress/Create
        [HttpPost]
        public ActionResult Create(TradingProgressModel ModelObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TradingProgressRepository repository = new TradingProgressRepository();
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

        // GET: TradingProgress/Edit/5
        public ActionResult Edit(int id)
        {
            TradingProgressRepository repository = new TradingProgressRepository();
            ParticipantRepository participantRep = new ParticipantRepository();
            DealRepository dealRep = new DealRepository();

            TradingProgressModel model = repository.GetById(id);

            model.Buyers = participantRep.GetAll();
            model.Deals = dealRep.GetAll();

            return View(model);
        }

        // POST: TradingProgress/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TradingProgressModel ModelObject)
        {
            try
            {
                TradingProgressRepository repository = new TradingProgressRepository();
                repository.Update(ModelObject);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }
        }

        // GET: TradingProgress/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                TradingProgressRepository repository = new TradingProgressRepository();
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
