using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class StudentsController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        public IHttpActionResult Post([FromBody]Student value)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]Student value)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }
    }
}
