using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthorizationServer.Controllers
{
    public class AudienceController : ApiController
    {
        public IHttpActionResult Post(AudienceModel audience)
        {
            var newAudience = AudienceStore.AddAudience(audience.Name);
            return Ok(newAudience);
        }
    }
}
