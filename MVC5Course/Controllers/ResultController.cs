using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ResultController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View(); //View();
        }

        public ActionResult ViewTest()
        {
            string model = "My Model";
            return View((object) model);
        }

        public ActionResult PartialViewTest()
        {
            string model = "My Model";
            return PartialView("ViewTest", (object)model);
        }

        public ActionResult JsonTest()
        {
            var model = new Dictionary<string, object>()
            {
                {"Model", "My Model"},
                {"Name", "Patrick" },
                {"Age", 30 }
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JavaScriptTest()
        {
            return JavaScript("alert('hello');");
        }

        public ActionResult XmlTest()
        {
            return new XmlResult();
        }

        public ActionResult FileTest(string dl)
        {
            if (string.IsNullOrEmpty(dl))
                return File(
                    Server.MapPath("~/App_Data/Image.jpg"),
                    "image/jpeg");
            else
                return File(
                    Server.MapPath("~/App_Data/Image.jpg"),
                    "image/jpeg",
                    "FIFA.jpg");
        }
    }
}