using RestApi.Base;
using RestApi.Model;
using RestApi.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class CoursesController : ApiController
    {
        private CourseRepository courseRepository = Program.courseRepository;

        [Route("api/courses")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
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
            else
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotAcceptable));
            }
        }

        [Route("api/students/{index}/courses/")]
        [HttpGet]
        public IHttpActionResult Get(int index)
        {
            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
            {
                try
                {
                    var courses = courseRepository.GetAll();
                    //var courses = courseRepository.GetById(index);

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
            else
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotAcceptable));
            }
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpGet]
        public IHttpActionResult Get(int index,string course)
        {
            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
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
                catch(Exception)
                {
                    return Conflict();
                }
            }
            else
            {
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotAcceptable));
            }
        }

        [Route("api/students/courses")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]RestApi.Model.Course value)
        {
            try
            {
                courseRepository.Insert(value);
                return Created(Request.RequestUri + "/" + value.Name, value);
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses")]
        [HttpPost]
        public IHttpActionResult Post(int index,[FromBody]RestApi.Model.Course value)
        {
            try
            {
                courseRepository.Insert(value);
                return Created(Request.RequestUri + "/" + value.Name, value);
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
