using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocietyManagement.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseController:Controller
    {
        protected IActionResult CreateNoContentResponseObjectResult()
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
            return new ObjectResult("Data not found");
        }

        protected IActionResult CreatePageNotFound()
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return new ObjectResult("Record cannot be deleted");
        }
    }
}
