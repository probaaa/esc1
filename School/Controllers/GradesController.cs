using School.Models;
using School.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace School.Controllers
{
    [RoutePrefix("project/grades")]
    public class GradesController : ApiController
    {
        private IGradesService gradesService;

        public GradesController(IGradesService gradesService)
        {
            this.gradesService = gradesService;
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return gradesService.GetAllGrades();
        }

        public IHttpActionResult GetById(int id)
        {
            Grade grade = gradesService.GetById(id);

            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }

        [Route("", Name = "PostGrade")]
        [ResponseType(typeof(Grade))]
        public IHttpActionResult PostGrade(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Grade createdGrade = gradesService.InsertGrade(grade);

            return CreatedAtRoute("PostGrade", new { id = grade.Id }, createdGrade);
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Grade))]
        public IHttpActionResult UpdateGrade(int id, Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Grade updatedGrade = gradesService.UpdateGrade(id, grade);

            if (updatedGrade == null)
            {
                return NotFound();
            }

            return Ok(updatedGrade);
        }

        [Route("{id}")]
        [ResponseType(typeof(Grade))]
        public IHttpActionResult DeleteGrade(int id)
        {
            Grade grade = gradesService.DeleteGrade(id);

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }
    }
}
