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
    [RoutePrefix("public/subjects")]
    public class SubjectsController : ApiController
    {
        private ISubjectsService subjectsService;

        public SubjectsController(ISubjectsService subjectsService)
        {
            this.subjectsService = subjectsService;
        }
        [Route("")]
        public IEnumerable<Subject> GetAllSubjects()
        {
            return subjectsService.GetAllSubjects();
        }
        [Route("{id}")]
        [ResponseType(typeof(Subject))]
        public IHttpActionResult GetSubjectById(int id)
        {
            Subject subject = subjectsService.GetById(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [Route("", Name = "PostSubject")]
        [ResponseType(typeof(Subject))]
        public IHttpActionResult PostSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject createdSubject = subjectsService.InsertSubject(subject);

            return CreatedAtRoute("PostSubject", new { id = subject.Id }, createdSubject);
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Subject))]
        public IHttpActionResult UpdateSubject(int id, Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject updatedSubject = subjectsService.UpdateSubject(id, subject);

            if (updatedSubject == null)
            {
                return NotFound();
            }

            return Ok(updatedSubject);
        }

        [Route("{id}")]
        [ResponseType(typeof(Subject))]
        public IHttpActionResult DeleteSubject(int id)
        {
            Subject subject = subjectsService.DeleteSubject(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }


    }
}
