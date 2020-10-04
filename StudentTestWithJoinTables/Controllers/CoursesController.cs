using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Model;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
    public class CoursesController : ControllerBase
    {
    


            private readonly ICourseServices _COURSEDAL;

            public CoursesController(ICourseServices coursedal)
            {
                _COURSEDAL = coursedal;

            }



            [HttpGet]
            public ActionResult<IEnumerable<Course>> GetAllCourse()
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var allcourses = _COURSEDAL.GetAllCourse().ToList();
                    return Ok(allcourses);
                }


            }

            [HttpGet("{id}")]
            public ActionResult<IEnumerable<Course>> GetCourseById([FromRoute] int id)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var courseobj = _COURSEDAL.GetCourseById(id).FirstOrDefault();
                    return Ok(courseobj);
                }

            }


            [HttpPost]
            public ActionResult AddNewCourse([FromBody] Course course)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
            _COURSEDAL.AddNewCourse(course);
                return Ok();
            }


            [HttpPut("{id}")]
            public ActionResult UpdateCourse([FromRoute] int id, [FromBody] Course course)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                if (id != course.CourseId)
                {
                    return BadRequest("Id's did not match!! ");
                }
                else
                {
                    _COURSEDAL.UpdateCourse(id, course);
                    return Ok();
                }
            }



            [HttpDelete("{id}")]
            public ActionResult DeleteCourse([FromRoute] int id)
            {

                if (id <= 0)
                {
                    return BadRequest("Not a valid course id");
                }
                else
                {
                    _COURSEDAL.DeleteCourse(id);

                }
                return Ok();


            }

        }
    }


   
