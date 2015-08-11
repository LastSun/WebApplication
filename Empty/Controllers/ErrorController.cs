using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Empty.Controllers
{
    public class Error : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {

        }
    }

    [HandleError]
    public class ErrorController : Controller
    {
        [HandleError]
        // GET: Error
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return Error();
        }

        public ActionResult Internal()
        {
            return Error();
        }
    }
}