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

namespace RestApi.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> studentRepository = Program.studentRepository;

        public IHttpActionResult Get()
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

        public IHttpActionResult Get(int id)
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

        public IHttpActionResult Post([FromBody]RestApi.Model.Student value)
        {
            try
            {
                studentRepository.Insert(value);
                return Ok();
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
