using School.Models;
using School.Repositories;
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
    [RoutePrefix("public/teachers")]
    public class TeachersController : ApiController
    {
        private ITeachersService teachersService;
        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }
        [Route("")]
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return teachersService.GetAllTeachers();
        }
        [Route("{id}")]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult GetTeacherById(int id)
        {
            Teacher teacher = teachersService.GetById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [Route("", Name = "PostTeacher")]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult PostTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Teacher createdTeacher = teachersService.InsertTeacher(teacher);

            return CreatedAtRoute("PostTeacher", new { id = teacher.Id }, createdTeacher);
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult UpdateTeacher(int id, Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Teacher updatedTeacher = teachersService.UpdateTeacher(id, teacher);

            if (updatedTeacher == null)
            {
                return NotFound();
            }

            return Ok(updatedTeacher);
        }

        [Route("{id}")]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult DeleteTeacher(int id)
        {
            Teacher teacher = teachersService.DeleteTeacher(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }




    }
}
