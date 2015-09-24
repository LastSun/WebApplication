using System.Net;
using Microsoft.AspNet.Mvc;

namespace WebApplication.ResourceServer.Controllers
{
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead]
        public IActionResult Handle()
        {
            return new HttpNotFoundResult();
        }
    }
}