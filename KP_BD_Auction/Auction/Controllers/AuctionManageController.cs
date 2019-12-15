using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Auction.Models;
using Auction.Repositories;
using Auction.ViewModel;

namespace Auction.Controllers
{
    public class AuctionManageController : Controller
    {
        // GET: AuctionManage
        public ActionResult Index()
        {
            return RedirectToAction("GetAuctions");
        }

        public ActionResult GetAuctions()
        {
            AuctionRepository repository = new AuctionRepository();
            ModelState.Clear();
            return View(repository.GetAll("GetFutureAuctions"));
        }

        public ActionResult AddDeals(int id)
        {
            DealRepository repository = new DealRepository();
            ModelState.Clear();
            ViewBag.AuctionId = id;
            return View(repository.GetForAuction(id));
        }

        // GET: Deal/Create
        public ActionResult NewDeal(int id)
        {
            AuctionRepository auctionRep = new AuctionRepository();
            ParticipantRepository participantRep = new ParticipantRepository();
            DealStateRepository dealStateRep = new DealStateRepository();
            ItemRepository itemRep = new ItemRepository();

            DealModel model = new DealModel
            {
                Auctions = auctionRep.GetAll(),
                Buyers = participantRep.GetAll(),
                Sellers = participantRep.GetAll(),
                DealStates = dealStateRep.GetAll(),
                Items = itemRep.GetAll("GetAvailableItems")
            };

            ViewBag.Id = id;
            return View(model);
        }

        // POST: Deal/Create
        [HttpPost]
        public ActionResult NewDeal(DealModel ModelObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DealRepository dealRepository = new DealRepository();
                    ItemRepository itemRepository = new ItemRepository();
                    itemRepository.SetSold(ModelObject.Item_Id);

                    dealRepository.Add(ModelObject);
                    return RedirectToAction("AddDeals", "AuctionManage", new { id = ModelObject.Auction_Id });
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AuctionManage/Edit/5
        public ActionResult Start(int id)
        {
            DealRepository dealRepository = new DealRepository();
            ParticipantRepository participantRepository = new ParticipantRepository();
            ItemRepository itemRepository = new ItemRepository();
            IEnumerable<DealModel> dealsForAuction = dealRepository.GetForAuction(id);
            StartViewModel startViewModel = new StartViewModel
            {
                deals = dealsForAuction,
                participants = participantRepository.GetAll()
            };
            
            ModelState.Clear();
            ViewBag.AuctionId = id;
            if(dealsForAuction.Count() > 0)
            {
                ItemModel firstDealItem = itemRepository.GetById(startViewModel.deals.ElementAt(0).Item_Id);

                ViewBag.startPrice = firstDealItem.StartedPrice;
                ViewBag.dealStep = firstDealItem.PriceGrowth;
            }

            return View(startViewModel);
        }

        // POST: AuctionManage/Edit/5
        [HttpPost]
        public ActionResult Start()
        {
            try
            {
                return RedirectToAction("GetAuctions", "AuctionManage");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetItemInfo(int dealId, int byuerId, int stepRate)
        {
            DateTime now = DateTime.Now;
            TradingProgressRepository tradingProgressRepository = new TradingProgressRepository();
            TradingProgressModel tradingProgress = new TradingProgressModel
            {
                Deal_Id = dealId,
                Buyer_Id = byuerId,
                StepTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0),
                StepRate = stepRate
            };
            tradingProgressRepository.Add(tradingProgress);
            
            return Json(new { }, JsonRequestBehavior.DenyGet);
        }
        

        public ActionResult Next(int auctionId, int dealId)
        {
            try
            {
                AuctionRepository auctionRepository = new AuctionRepository();
                auctionRepository.End(auctionId);
                DealRepository dealRepository = new DealRepository();
                dealRepository.NoActive(dealId);

                return RedirectToAction("Start", "AuctionManage", new { id = auctionId });
            }
            catch
            {
                return RedirectToAction("Start", "AuctionManage", new { id = auctionId });
            }
        }
    }
}
