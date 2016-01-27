using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vjestina2015_Projekt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ova aplikacija je projekt za vještinu Razvoj aplikacija u programskom jeziku C#. Cilj aplikacije je omogućiti studentima lakše pronalaženje stručne prakse, a tvrtkama besplatni prostor za oglašavanje. Izvorni kod je dostupan na githubu.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}