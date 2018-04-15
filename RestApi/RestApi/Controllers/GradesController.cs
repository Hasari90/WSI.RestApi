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
        private StudentRepository studentRepository = Program.studentRepository;
        private CourseRepository courseRepository = Program.courseRepository;

        [Route("api/students/{index}/courses/{course}/grades")]
        [HttpGet]
        public IHttpActionResult Get(string index, string course)
        {
            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
            {
                try
                {
                    var grades = studentRepository.GetById(index).Grades;

                    return Ok(grades);
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

        [Route("api/students/{index}/courses/{course}/grades/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string index, string course, int id)
        {
            if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
            {
                try
                {
                    var grades = studentRepository.GetById(index).Grades;

                    var grade = grades.Where(g => g.Id == id);

                    if (grade == null)
                    {
                        return NotFound();
                    }

                    return Ok(grade);
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

        [Route("api/students/{index}/courses/{course}/grades")]
        [HttpPost]
        public IHttpActionResult Post(string index, string course, [FromBody]Grade value)
        {
            try
            {
                if(Validation.Validate.IsCorrect(value.Mark))
                {
                    var student = studentRepository.GetById(index);
                    var courses = courseRepository.GetById(course);
                    if (student.Grades != null)
                        value.Id = student.Grades.Max(g => g.Id) + 1;
                    else
                    {
                        value.Id = 0;
                        student.Grades = new List<Grade>();
                    }
                    value.Course = courses;
                   student.Grades.Add(value);

                   studentRepository.Update(index, student);
                   return Created(Request.RequestUri + "/" + value.Id.ToString(), value);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{id}")]
        [HttpPut]
        public IHttpActionResult Put(string index, string course, string id, [FromBody]Grade value)
        {
            try
            {
                var student = studentRepository.GetById(index);

                if (student == null)
                {
                    return NotFound();
                }

                var grades = student.Grades;
                var concreateGrade = grades.Find(g => g.Id == Convert.ToInt64(id));
                if (concreateGrade == null)
                {
                    return Post(index, course, value);
                }
                if (value.Id == concreateGrade.Id &&
                    value.Mark.Equals(concreateGrade.Mark) &&
                    value.Date == concreateGrade.Date)
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, ""));
                }

                concreateGrade.CourseName = value.CourseName;
                concreateGrade.Date = value.Date;
                concreateGrade.Mark = value.Mark;

                studentRepository.Update(index, student);

                return Ok();

            }
            catch (Exception)
            {
                return Conflict();
            }
        }

        [Route("api/students/{index}/courses/{course}/grades/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string index, string course, int id)
        {
            try
            {
                var grades = studentRepository.GetById(index).Grades;
                var gradeId = grades.FindIndex(g => g.Id == id);

                if (gradeId != -1)
                {
                    grades.RemoveAt(gradeId);

                    return Ok();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }
    }
}
