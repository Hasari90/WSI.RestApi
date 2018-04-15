using RestApi.Repository.Repositories;
using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.Model;
using RestApi.Base;
using System.Web;
using System.Net.Http.Formatting;

namespace RestApi.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentRepository studentRepository = Program.studentRepository;

        public IHttpActionResult Get()
        {
            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
            {
                try
                {
                    var students = studentRepository.GetAll();

                    return Ok(students);
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

        public IHttpActionResult Get(int id)
        {

            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
            {
                try
                {
                    var student = studentRepository.GetById(id.ToString());

                    if (student == null)
                    {
                        return NotFound();
                    }

                    return Ok(student);
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

        public IHttpActionResult Post([FromBody]RestApi.Model.Student value)
        {
            try
            {
                var student = studentRepository.GetById(value.Index.ToString());

                if (student == null)
                {
                    studentRepository.Insert(value);
                    return Created(Request.RequestUri + "/" + value.Index.ToString(), value);
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]RestApi.Model.Student value)
        {
            try
            {
                studentRepository.Update(id.ToString(), value);
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
                if (studentRepository.Delete(id.ToString()))
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
