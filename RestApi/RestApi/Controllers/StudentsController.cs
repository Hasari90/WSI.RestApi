using RestApi.Repository.Repositories;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.Parameter;
using System.Web.Http.Cors;
using RestApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentRepository studentRepository = new StudentRepository();

        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public IHttpActionResult Get([FromUri] StudentParameter studentParameter)
        {
            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
            {
                try
                {
                    var students = studentRepository.GetAll(studentParameter);

                    var list = students as IList<Student> ?? students.ToList();
                    foreach (var student in list)
                    {
                        student.Links = new List<Link>
                        {
                            new Link() { Href = Request.RequestUri.ToString().Split('?').First() + string.Format("/{0}", student.Index), Rel = "student" }
                        };
                    }

                    return Ok(list);
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

        [EnableCors(origins: "*", headers: "*", methods: "GET")]
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

                    var s = Request.RequestUri.ToString().LastIndexOf("/");

                    student.Links = new List<Link>
                    {
                        new Link() { Href = Request.RequestUri.ToString().Split('?').First(), Rel = "self" },
                        new Link() { Href = Request.RequestUri.ToString().Split('?').First().Substring(0, s), Rel = "parent" },
                        new Link() { Href = Request.RequestUri.ToString().Split('?').First() + "/courses", Rel = "courses" }
                    };

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
