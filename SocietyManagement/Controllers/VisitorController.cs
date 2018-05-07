using Microsoft.AspNetCore.Mvc;
using SocietyManagement.Domain.Models;
using SocietyManagement.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagement.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VisitorController:BaseController
    {
        private readonly IVisitorService _visitorService;

        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpPost("AddVisitors")]
        public IActionResult Post([FromBody]Domain.Models.Visitors visitor)
        {
            if (visitor != null)
            {
                _visitorService.RecordVisitor(visitor);
                return Ok();
            }
            return NoContent();
        }
        [HttpPost("ImageUpload")]
        public IActionResult UploadImage([FromBody]Image imageData)
        {
            if (imageData != null)
            {
                var imageId =_visitorService.AddImage(imageData.ImageData);
                return Ok(imageId);
            }
            return NoContent();
        }
    }
}
