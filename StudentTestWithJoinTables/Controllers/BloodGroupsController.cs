using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using BusinessLayer.Services;
using BusinessLayer.Model;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodGroupsController : ControllerBase
    {

        private readonly IBloodGroupServices _BLOODGROUPDAL;

        public BloodGroupsController(IBloodGroupServices bgdal)
        {
           _BLOODGROUPDAL = bgdal;

        }



        [HttpGet]
        public ActionResult<IEnumerable<BloodGroup>> GetAllBloodGroup()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var allbg = _BLOODGROUPDAL.GetAllBloodGroup().ToList();
                return Ok(allbg);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<BloodGroup>> GetBloodGroupById([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var bgobj = _BLOODGROUPDAL.GetBloodGroupById(id).FirstOrDefault();
                return Ok(bgobj);
            }

        }


        [HttpPost]
        public ActionResult AddNewBloodGroup([FromBody] BloodGroup bloodgroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _BLOODGROUPDAL.AddNewBloodGroup(bloodgroup);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult UpdateBloodGroup([FromRoute] int id, [FromBody] BloodGroup bloodgroup)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if (id != bloodgroup.BloodGroupId)
            {
                return BadRequest("Id's did not match!! ");
            }
            else
            {
                _BLOODGROUPDAL.UpdateBloodGroup(id, bloodgroup);
                return Ok();
            }
        }



        [HttpDelete("{id}")]
        public ActionResult DeleteBloodGroup([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest("Not a valid BloodGroup id");
            }
            else
            {
               _BLOODGROUPDAL.DeleteBloodGroup(id);

            }
            return Ok();


        }

    }
}
