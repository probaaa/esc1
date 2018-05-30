using School.Models;
using School.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Services
{
    public class ParentsService : IParentsService
    {
        private IUnitOfWork db;

        public ParentsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<Parent> GetAllParents()
        {
            return db.ParentRepository.Get();
        }

        public Parent GetById(int id)
        {
            return db.ParentRepository.GetByID(id);
        }

        public Parent InsertParent(Parent newParent)
        {
            db.ParentRepository.Insert(newParent);
            db.Save();
            return newParent;
        }

        public Parent UpdateParent(int id, Parent updatedParent)
        {
            Parent parent = db.ParentRepository.GetByID(id);

            if (parent != null)
            {
                parent.FirstName = updatedParent.FirstName;
                parent.LastName = updatedParent.LastName;
                parent.Username = updatedParent.Username;
                parent.Email = updatedParent.Email;

                db.ParentRepository.Update(parent);
                db.Save();
            }

            return parent;
        }
        public Parent DeleteParent(int id)
        {
            Parent parent = db.ParentRepository.GetByID(id);
            if (parent == null)
            {
                return null;
            }
            db.ParentRepository.Delete(parent);
            db.Save();

            return parent;
        }
    }
}