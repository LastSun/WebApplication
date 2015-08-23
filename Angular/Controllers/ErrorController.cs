using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Angular.Controllers
{
    public class ErrorController : ApiController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public HttpResponseMessage Handle()
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "The requested resource is not found"
            };
        }
    }
}