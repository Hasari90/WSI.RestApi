using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class GradesController : ApiController
    {
        [Route("api/students/{index}/courses/{course}/grades")]
        [HttpGet]
        public IEnumerable<Models.Grade> Get()
        {

            return new [] { new Grade() };
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpGet]
        public Models.Grade Get(int id)
        {
            return new Grade();
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {

        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
