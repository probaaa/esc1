using School.Models;
using School.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Services
{
    public class GradesService : IGradesService
    {
        private IUnitOfWork db;

        public GradesService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return db.GradeRepository.Get();
        }

        public Grade GetById(int id)
        {
            return db.GradeRepository.GetByID(id);
        }

        public Grade InsertGrade(Grade newGrade)
        {
            db.GradeRepository.Insert(newGrade);
            db.Save();
            return newGrade;
        }

        public Grade UpdateGrade(int id, Grade updatedGrade)
        {
            Grade grade = db.GradeRepository.GetByID(id);

            if (grade != null)
            {
                grade.GradeValues = updatedGrade.GradeValues;
                grade.SemesterEndGrade = updatedGrade.SemesterEndGrade;
                grade.Semester = updatedGrade.Semester;
                grade.FinalGrade = updatedGrade.FinalGrade;

                db.GradeRepository.Update(grade);
                db.Save();
            }

            return grade;
        }
        public Grade DeleteGrade(int id)
        {
            Grade grade = db.GradeRepository.GetByID(id);
            if (grade == null)
            {
                return null;
            }
            db.GradeRepository.Delete(grade);
            db.Save();

            return grade;
        }
    }
}