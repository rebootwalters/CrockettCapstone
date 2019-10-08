using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrockettWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your Brian application description page.";

            return View();
        }

        public ActionResult Contact(int ?id)
        {
            if (id.HasValue)
            {
                if (0 == id.Value % 2)
                {
                    ViewBag.Message = "Your Even Bryan contact page.";
                }
                else

                {
                    ViewBag.Message = "Your Odd Brian contact page.";
                }
            }
            else
            {
                ViewBag.Message = "I cant tell if it is to be Bryan or the odd Brian";
            }

            return View();
        }
    }
}