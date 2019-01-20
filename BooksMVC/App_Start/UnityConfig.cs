using BooksDA.Repo;
using BooksDA.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using BookBL;

namespace BooksMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IManageBooksRepository, ManageBooksRepository>();
            container.RegisterType<IManageBooks, ManageBooks>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}