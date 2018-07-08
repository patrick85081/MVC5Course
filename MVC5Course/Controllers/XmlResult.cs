using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class XmlResult : ActionResult
    {
        //private object xmlModel;

        //public XmlResult(object xmlModel)
        //{
        //    this.xmlModel = xmlModel;
        //}

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/xml";
            //context.HttpContext.Response.BinaryWrite();
            context.HttpContext.Response.Write("<xml><hello/></xml>");
        }
    }
}