using School.Models;
using School.Repositories;
using School.Services;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace School
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
            container.RegisterType<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
            container.RegisterType<IGenericRepository<Student>, GenericRepository<Student>>();
            container.RegisterType<IGenericRepository<Parent>, GenericRepository<Parent>>();
            container.RegisterType<IGenericRepository<Grade>, GenericRepository<Grade>>();
            container.RegisterType<IGenericRepository<Subject>, GenericRepository<Subject>>();
            container.RegisterType<DbContext, DataAccessContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IStudentsService, StudentsService>();
            container.RegisterType<ITeachersService, TeachersService>();
            container.RegisterType<IParentsService, ParentsService>();
            container.RegisterType<ISubjectsService, SubjectsService>();
            container.RegisterType<IGradesService, GradesService>();
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}