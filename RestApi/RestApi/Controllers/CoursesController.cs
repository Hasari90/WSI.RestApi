using RestApi.Base;
using RestApi.Model;
using RestApi.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class CoursesController : ApiController
    {
        private CourseRepository courseRepository = Program.courseRepository;

        [Route("api/students/{index}/courses")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var courses = courseRepository.GetAll();

                return Ok(courses);
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpGet]
        public IHttpActionResult Get(string course)
        {
            try
            {
                var courses = courseRepository.GetById(course);

                if (courses == null)
                {
                    return NotFound();
                }

                return Ok(courses);
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]RestApi.Model.Course value)
        {
            try
            {
                courseRepository.Insert(value);
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpPut]
        public IHttpActionResult Put(string course, [FromBody]RestApi.Model.Course value)
        {
            try
            {
                courseRepository.Update(course, value);
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpDelete]
        public IHttpActionResult Delete(string course)
        {
            try
            {
                if (courseRepository.Delete(course))
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }
    }
}
