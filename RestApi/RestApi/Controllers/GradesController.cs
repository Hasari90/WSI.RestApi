using RestApi.Model;
using RestApi.Parameter;
using RestApi.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RestApi.Controllers
{
    public class GradesController : ApiController
    {
        //private StudentRepository studentRepository = new StudentRepository();
        //private CourseRepository courseRepository = new CourseRepository();

        //[EnableCors(origins: "*", headers: "*", methods: "GET")]
        //[Route("api/students/{index}/courses/{course}/grades")]
        //[HttpGet]
        //public IHttpActionResult Get(string index, string course, [FromUri] GradeParameter gradeParameter)
        //{
        //    if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
        //    {
        //        try
        //        {
        //            var student = studentRepository.GetById(index);

        //            if (student == null)
        //            {
        //                return NotFound();
        //            }

        //            var grades = student.Grades;
        //            grades = grades.Where(g => g.CourseName == course).ToList();

        //            if (gradeParameter.Created != null)
        //            {
        //               // grades = grades.Where(g => g.Date == gradeParameter.Created).ToList();
        //            }

        //            if (gradeParameter.LowerGrades != null)
        //            {
        //               // grades = grades.Where(g => g.Mark < gradeParameter.LowerGrades).ToList();
        //            }

        //            if (gradeParameter.HigherGrades != null)
        //            {
        //               // grades = grades.Where(g => g.Mark > gradeParameter.HigherGrades).ToList();
        //            }

        //            if (gradeParameter.Value != null)
        //            {
        //                //grades = grades.Where(g => g.Mark.Equals(gradeParameter.Value)).ToList();
        //            }

        //            return Ok(grades);
        //        }
        //        catch (Exception)
        //        {
        //            return Conflict();
        //        }
        //    }
        //    else
        //    {
        //        return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotAcceptable));
        //    }
        //}

        //[EnableCors(origins: "*", headers: "*", methods: "GET")]
        //[Route("api/students/{index}/courses/{course}/grades/{id}")]
        //[HttpGet]
        //public IHttpActionResult Get(string index, string course, int id)
        //{
        //    if (Request.Headers.Accept.ToString().Contains("application/json") || Request.Headers.Accept.ToString().Contains("application/xml"))
        //    {
        //        try
        //        {
        //            var grades = studentRepository.GetById(index).Grades;

        //            var grade = grades.Where(g => g.Id == id);

        //            if (grade == null)
        //            {
        //                return NotFound();
        //            }

        //            return Ok(grade);
        //        }
        //        catch (Exception)
        //        {
        //            return Conflict();
        //        }
        //    }
        //    else
        //    {
        //        return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotAcceptable));
        //    }
        //}

        //[Route("api/students/{index}/courses/{course}/grades")]
        //[HttpPost]
        //public IHttpActionResult Post(string index, string course, [FromBody]Grade value)
        //{
        //    try
        //    {
        //        if(Validation.Validate.IsCorrect(value.Mark))
        //        {
        //            var student = studentRepository.GetById(index);
        //            var courses = courseRepository.GetById(course);
        //            if (student.Grades != null && student.Grades.Count > 0)
        //                value.Id = student.Grades.Max(g => g.Id) + 1;
        //            else
        //            {
        //                value.Id = 0;
        //                student.Grades = new List<Grade>();
        //            }
        //            value.Course = new MongoDBRef(nameof(courses), ObjectId.Parse(courses.ObjectId));
        //            value.Student = new MongoDBRef(nameof(student), ObjectId.Parse(student.ObjectId));
        //            student.Grades.Add(value);

        //           studentRepository.Update(index, student);
        //           return Created(Request.RequestUri + "/" + value.Id.ToString(), value);
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Conflict();
        //    }
        //}

        //[Route("api/students/{index}/courses/{course}/grades/{id}")]
        //[HttpPut]
        //public IHttpActionResult Put(string index, string course, string id, [FromBody]Grade value)
        //{
            
        //        try
        //        {
        //            if (Validation.Validate.IsCorrect(value.Mark))
        //            {
        //                var student = studentRepository.GetById(index);

        //                if (student == null)
        //                {
        //                    return NotFound();
        //                }

        //                var grades = student.Grades;
        //                var concreateGrade = grades.Find(g => g.Id == Convert.ToInt64(id));
        //                if (concreateGrade == null)
        //                {
        //                    return Post(index, course, value);
        //                }
        //                if (value.Id == concreateGrade.Id &&
        //                    value.Mark.Equals(concreateGrade.Mark) &&
        //                    value.Date == concreateGrade.Date)
        //                {
        //                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, ""));
        //                }

        //                concreateGrade.CourseName = value.CourseName;
        //                concreateGrade.Date = value.Date;
        //                concreateGrade.Mark = value.Mark;

        //                studentRepository.Update(index, student);

        //                return Ok();
        //            }
        //            else
        //            {
        //                return BadRequest();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return Conflict();
        //        } 
        //}

        //[Route("api/students/{index}/courses/{course}/grades/{id}")]
        //[HttpDelete]
        //public IHttpActionResult Delete(string index, string course, int id)
        //{
        //    try
        //    {
        //        var grades = studentRepository.GetById(index).Grades;
        //        var gradeId = grades.FindIndex(g => g.Id == id);

        //        if (gradeId != -1)
        //        {
        //            grades.RemoveAt(gradeId);

        //            return Ok();
        //        }

        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return Conflict();
        //    }
        //}
    }
}
