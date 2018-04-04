using RestApi.Model;
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
        public IHttpActionResult Get()
        {
            try
            {
                if (true)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (true)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]string value)
        {
            try
            {
                if (true)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                if (true)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (true)
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
