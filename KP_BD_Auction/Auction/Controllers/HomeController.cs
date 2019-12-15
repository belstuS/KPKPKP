using System.Collections.Generic;
using System.Web.Mvc;
using Auction.Models;
using Auction.Repositories;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["Role"] == null) Session["Role"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel ModelObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserRepository repository = new UserRepository();

                    bool isPassworValid = repository.IsPasswordValid(ModelObject);

                    if (isPassworValid)
                    {
                        var currentUser = repository.GetUserByLogin(ModelObject.Username);

                        return Authorize(currentUser.Role);
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Authorize(string role)
        {
            Session["Role"] = role;
            if (role == "Admin")
            {
                return RedirectToAction("GetAll", "Auction");
            }
            else if (role == "User")
            {
                return RedirectToAction("GetAuctions", "AuctionManage");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Exit()
        {
            Session["Role"] = "";
            return RedirectToAction("Index");
        }
    }
}