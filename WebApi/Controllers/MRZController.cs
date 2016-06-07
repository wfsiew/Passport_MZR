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
            MRZ o = new MRZ();
            o.SetPassportNum(m.PassportNum);
            o.SetNationality(m.Nationality);
            o.SetDOB(m.DOB);
            o.SetSex(m.Sex);
            o.SetPassportExpDate(m.Expiry);
            o.SetPersonalNum();
            return Ok(o);
        }

        [HttpOptions, Route("api/mrz/validate")]
        public string OptionsValidate()
        {
            return null;
        }
    }

    public class MRZForm
    {
        public string PassportNum { get; set; }
        public string Nationality { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public string Expiry { get; set; }
    }
}
