using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class FiltersController : Controller
    {
        // GET: Filters

        
        [OutputCache(Duration=200)]
        public ActionResult CheckCache()
        {
            var date= DateTime.Now.ToString("T");
            ViewBag.Time = date;
            return View();
        }
    }
}