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
    /*Authorization filters*/
    //[Authorize(Roles="administrators", Users="jsmith")]
    //[Authorize] // Allows any logged-in users
    //[AllowAnonymous]//Allow any 
    //[MyLoggingFilter]

    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        //[Authorize(Roles="administrators", Users="jsmith")]
        //[Authorize] // Allows any logged-in users
        //[AllowAnonymous]//Allow any 
        //[MyLoggingFilter] //Or globally
        [Authorize]
        public ActionResult Index()
        {
            //return PartialView();
            //throw new StackOverflowException();
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(x => x.ApplicationUserId == userId).FirstOrDefault().Id;
            ViewBag.checkingAccountId = checkingAccountId;
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin; 
            return View();
        }
            //Get /home/Index
            //[ActionName("about-this-atm")]
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";
                //Must provide explicit view name otherwise it will look for about-this-atm.{cshtml,vbhtml,aspx,ascx}
                //in Views/Home or in Views/Shared
                //if you provide a full path you need to specify also the extension: return View("~/Views/Home/About.cshtml");
                return View("About");
            }

        
        //Get /Home/Contact
        //[OutputCache(Duration=100)]
        //[OutputCache(Duration=100, VaryByParam="id")]
        //[HandleError(View = "MathError", ExceptionType = typeof(DivideByZeroException))]
        //[HandleError(View = "SOError", ExceptionType = typeof(StackOverflowException))]
        public ActionResult Contact()
        {

            //This would survive onlu if we return view and get destroy afterward
            //if we want something to stay in memory use TempData["TheMessage"]
            ViewBag.TheMessage = "Having trouble? send us a message";
            return View();
        }

        [HttpPost]//action selector
        public ActionResult Contact(string message)
        {
            //TODO: Send message to HQ
            message = message ?? "Thanks, we got your message!";
            ViewBag.TheMessage = message;
            return PartialView("_ContactThanks");
            //return View();
        }


        public ActionResult Foo()
        {
            //must provide explicit view name otherwise it will look for Foo.{cshtml,vbhtml,aspx,ascx}
            //in Views/Home or in Views/Shared
            return View("About"); 
        }


        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            //return Content(serial);
            //return new HttpStatusCodeResult(403);
            //return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
           return RedirectToAction("Index", "Home");
            
        }
    }
}