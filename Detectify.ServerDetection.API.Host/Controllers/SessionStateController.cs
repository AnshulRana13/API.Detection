using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detectify.ServerDetection.API.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SessionStateController  : ControllerBase
    {
        public ActionResult<string> Get()
        {           
            var res = HttpContext.Session.GetString("data");
            return Ok(res);
        }
    }
}