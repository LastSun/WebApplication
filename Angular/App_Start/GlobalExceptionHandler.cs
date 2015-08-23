using System;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Angular.Controllers;

namespace Angular
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            //new ErrorController().Handle();
            base.Handle(context);
        }
    }
}