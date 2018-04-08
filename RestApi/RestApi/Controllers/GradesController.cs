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
    public class GradesController : ApiController
    {
        private GradeRepository gradeRepository = Program.gradeRepository;

        [Route("api/students/{index}/courses/{course}/grades")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var grades = gradeRepository.GetAll();

                return Ok(grades);
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpGet]
        public IHttpActionResult Get(int index, string course)
        {
            try
            {
                var grades = gradeRepository.GetById(index.ToString(),course);
                
                if (grades == null)
                {
                    return NotFound();
                }

                return Ok(grades);
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Grade value)
        {
            try
            {
                gradeRepository.Insert(value);
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{grade}")]
        [HttpPut]
        public IHttpActionResult Put(int index, string course, [FromBody]Grade value)
        {
            try
            {
                gradeRepository.Update(index.ToString(), value);
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades")]
        [HttpDelete]
        public IHttpActionResult Delete(int index, string course)
        {
            try
            {
                if (gradeRepository.Delete(index.ToString(),course))
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
