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
    [RoutePrefix("project/students")]
    public class StudentsController : ApiController
    {
        private IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }
        [Route("")]
        public IEnumerable<Student> GetAllStudents()
        {
            return studentsService.GetAllStudents();
        }
        [Route("{id}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudentById(int id)
        {
            Student student = studentsService.GetById(id);
            
            if (student==null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [Route("", Name = "PostStudent")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student createdStudent = studentsService.InsertStudent(student);

            return CreatedAtRoute("PostStudent", new {id = student.Id }, createdStudent);
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Student))]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student updatedStudent = studentsService.UpdateStudent(id, student);

            if(updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }

        [Route("{id}")]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = studentsService.DeleteStudent(id);

            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }




    }
}
