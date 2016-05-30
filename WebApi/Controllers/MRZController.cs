using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Validator;

namespace WebApi.Controllers
{
    public class MRZController : ApiController
    {
        [HttpPost, Route("api/mrz/validate")]
        public IHttpActionResult Validate(MRZForm m)
        {
            MRZ o = new MRZ(m.value);
            return Ok(o);
        }
    }

    public class MRZForm
    {
        public string value;
    }
}
