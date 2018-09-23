using MongoDB.Bson;
using MongoDB.Driver;
using RestApi.Model;
using System;
using System.Linq;
using System.Web.Http;

namespace RestApi.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesController : BaseApiController<Course>
    {
        public CoursesController()
            : base("Course")
        {

        }

        [Route("{courseID}")]
        [HttpDelete]
        public IHttpActionResult Delete(string courseID)
            => DeleteMethod(courseID);

        [Route()]
        [HttpGet]
        public IHttpActionResult Get(string name = null, string leadTeacher = null)
        {
            var builder = Builders<Course>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(name))
                filter &= builder.Eq(x => x.Name, name);
            if (!string.IsNullOrEmpty(leadTeacher))
                filter &= builder.Eq(x => x.LeadTeacher, leadTeacher);

            var list = GetMethod(filter);
            if (list.Count() == 0)
                return NotFound();

            return Ok(list);
        }

        [Route("{courseID}")]
        [HttpGet]
        public IHttpActionResult GetCourse(string courseID)
        {
            var course = GetMethod(x => x.Id == ObjectId.Parse(courseID));

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [Route()]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Course course)
        {
            try
            { 
            var created = PostMethod(course);
            return Created(string.Format("{0}/{1}", Request.RequestUri, created.Id), created);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{courseID}")]
        [HttpPut]
        public IHttpActionResult Put(string courseID, [FromBody] Course course)
        {
            var updateDefinition = Builders<Course>.Update
                .Set(x => x.LeadTeacher, course.LeadTeacher)
                .Set(x => x.Name, course.Name)
                .Set(x => x.ECTS, course.ECTS);

            return PutMethod(courseID, updateDefinition);
        }
    }
}
