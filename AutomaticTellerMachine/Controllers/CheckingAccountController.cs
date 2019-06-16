using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AutomaticTellerMachine.Models;

namespace AutomaticTellerMachine.Controllers
{
    [Authorize]
    public class CheckingAccountController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /CheckingAccount/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CheckingAccount/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            //var checkingAccount = new CheckingAccount { AccountNumber = "0000123456", FirstName = "Mohamed", LastName = "Kejeiri", Balance = 500 };
            var checkingAccount = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId);

            return View(checkingAccount);
        }


        public ActionResult List()
        {
            return View(db.CheckingAccounts.ToList<CheckingAccount>());
        }


        [Authorize(Roles ="Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var checkingAccount = db.CheckingAccounts.Find(id);
            return View("Details",checkingAccount);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Statement(int? id =2)
        {
            var checkingAccount = db.CheckingAccounts.Find(id);
            return View(checkingAccount.Transactions.ToList<Transaction>());
        }


        //
        // GET: /CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CheckingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CheckingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CheckingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
