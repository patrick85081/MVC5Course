using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            var data = "Hello World";
            ViewData.Model = data;
            return View();
        }

        public ActionResult ViewBagDemo()
        {
            ViewBag.Text = "Demo";
            return View();
        }

        public ActionResult ViewDataDemo()
        {
            ViewData["Text"] = "Demo";
            return View();
        }

        public ActionResult TempDataSave()
        {
            TempData["Text"] = "Temp";
            return RedirectToAction("TempDataDemo");
        }

        public ActionResult TempDataDemo()
        {
            return View();
        }
    }
}