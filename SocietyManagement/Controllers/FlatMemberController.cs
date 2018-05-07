using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Interface.Service;

namespace SocietyManagement.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FlatMemberController : BaseController
    {
        private readonly ISocietyMangementService _societyMangementService;

        public FlatMemberController(ISocietyMangementService societyMangementService)
        {
            _societyMangementService = societyMangementService;
        }

        // GET api/values
        [HttpGet("GetAllFlatMembers")]
        public IEnumerable<Members> Get()
        {
            return GetAllMembres();
        }

        private IEnumerable<Members> GetAllMembres()
        {
            return _societyMangementService.GetAllMembers();
        }
        [HttpGet("GetVisitorsByFlatNumber/{flatNumber}")]
        public IActionResult GetVisitorsByFlatNumber(int flatNumber)
        {
            try
            {
                return Ok(GetAllVisitors(101));
            }
            catch(Exception ex)
            {
                return NotFound(new { result = ex.Message });
            }

        }

        private IEnumerable<Domain.Models.Visitors> GetAllVisitors(int flatId)
        {
            return _societyMangementService.GetVisitors(flatId);
        }

        // POST api/values
        [HttpPost("AddFlatMember")]
        public IActionResult Post([FromBody]Domain.Models.Member member)
        {
            if (member != null)
            {
                AddFlatMember(member);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("AddFamilyMember")]
        public IActionResult AddFamilyMember([FromBody]Domain.Models.Member member)
        {
            if (member != null)
            {
                _societyMangementService.AddFamilyMember(member);
                return Ok();
            }
            return BadRequest();
        }

        private void AddFlatMember(Domain.Models.Member member)
        {
            _societyMangementService.AddMembers(member);
        }

        [HttpGet("GetSocietyList")]
        public IActionResult GetSocietyList()
        {
            var societyList = _societyMangementService.GetSocietyList();
            if(societyList.Count() > 0)
            {
                return Ok(societyList);
            }
            return NoContent();
        }

        [HttpGet("GetFlatBySociety/{id}")]
        public IActionResult GetSocietyList(int id)
        {
            var flatList = _societyMangementService.GetFlatsBySociety(id);
            if (flatList.Count() > 0)
            {
                return Ok(flatList);
            }
            return NoContent();
        }
        [HttpGet("GetProfileDetails/{userName}/{password}")]
        public IActionResult GetMemberProfile(string userName,string password)
        {
            var profileDetails = _societyMangementService.GetProfileDetails("Rakesh101", "password");
            if(profileDetails != null)
            {
                return Ok(profileDetails);
            }
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
