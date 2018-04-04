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
        private CourseRepository courseRepository = new CourseRepository();

        [Route("api/students/{index}/courses")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var students = courseRepository.GetAll();

                return Ok(students);
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var student = courseRepository.GetById(id.ToString());

                if (student == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}")]
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
        public IHttpActionResult Put(int id, [FromBody]RestApi.Model.Course value)
        {
            try
            {
                courseRepository.Update(id.ToString(), value);
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (courseRepository.Delete(id.ToString()))
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
