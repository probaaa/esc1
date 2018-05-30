using School.Models;
using School.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School.Controllers
{
    public class UsersController : ApiController
    {
        private IUnitOfWork db;
        public UsersController(IUnitOfWork db)
        {
            this.db = db;
        }
        public HttpResponseMessage PostUser(Student student)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            db.UserRepository.Insert(student);
            db.Save();
            return Request.CreateResponse(HttpStatusCode.Accepted, student);
        }
    }
}
