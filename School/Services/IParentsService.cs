using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public interface IParentsService
    {
        IEnumerable<Parent> GetAllParents();
        Parent GetById(int id);
        Parent InsertParent(Parent newParent);
        Parent UpdateParent(int id, Parent updatedParent);
        Parent DeleteParent(int id);

    }
}
