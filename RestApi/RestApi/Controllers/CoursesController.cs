using RestApi.Models;
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
        [Route("api/students/{index}/courses")]
        [HttpGet]
        public IEnumerable<Models.Course> Get()
        {
            Course course = new Course();

            return new [] { course };
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpGet]
        public Models.Course Get(string course)
        {
            Course course1 = new Course();
            
            return course1;
        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpPost]
        public void Post([FromBody]string value)
        {


        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpPut]
        public void Put(string name, [FromBody]string value)
        {

        }

        [Route("api/students/{index}/courses/{course}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string name)
        {

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
