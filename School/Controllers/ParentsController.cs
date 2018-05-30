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
    [RoutePrefix("public/parents")]
    public class ParentsController : ApiController
    {
        private IParentsService parentsService;

        public ParentsController(IParentsService parentsService)
        {
            this.parentsService = parentsService;
        }

        [Route("")]
        public IEnumerable<Parent> GetAllParents()
        {
            return parentsService.GetAllParents();
        }
        [Route("{id}")]
        [ResponseType(typeof(Parent))]
        public IHttpActionResult GetParentById(int id)
        {
            Parent parent = parentsService.GetById(id);

            if (parent == null)
            {
                return NotFound();
            }

            return Ok(parent);
        }

        [Route("", Name = "PostParent")]
        [ResponseType(typeof(Parent))]
        public IHttpActionResult PostParent(Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Parent createdParent = parentsService.InsertParent(parent);

            return CreatedAtRoute("PostParent", new { id = parent.Id }, createdParent);
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Parent))]
        public IHttpActionResult UpdateParent(int id, Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Parent updatedParent = parentsService.UpdateParent(id, parent);

            if (updatedParent == null)
            {
                return NotFound();
            }

            return Ok(updatedParent);
        }

        [Route("{id}")]
        [ResponseType(typeof(Parent))]
        public IHttpActionResult DeleteParent(int id)
        {
            Parent parent = parentsService.DeleteParent(id);

            if (parent == null)
            {
                return NotFound();
            }

            return Ok(parent);
        }


    }
}
