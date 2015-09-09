﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthorizationServer.Controllers
{
    public class AudienceController : ApiController
    {
        public IHttpActionResult Post()
        {
            var newAudience = AudienceStore.AddAudience();
            return Ok(newAudience);
        }
    }
}
