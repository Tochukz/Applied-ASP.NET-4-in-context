using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EventRegistration.Controllers;
using EventRegistration.Models.Domain.Repository;
using Ninject;
using Ninject.Syntax;

namespace EventRegistration.Infrastructure
{
    public class CustomDependencyResolver: IDependencyResolver
    {

        /* // Manual dependency injection implementation 
        public  public CustomDependencyResolver()
        {
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(RegistrationController))
            {
                DummyRepository dummyRepository = new DummyRepository();
                return new RegistrationController(dummyRepository);
            } 
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
        */

        /* Using NInject dependency injection container */
        private IKernel ninjectKernel;

        public CustomDependencyResolver()
        {
            ninjectKernel = new StandardKernel();
            AddDefaultBindings();
        }

        public object GetService(Type serviceType)
        {
            return ninjectKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ninjectKernel.GetAll(serviceType);
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return ninjectKernel.Bind<T>();
        }

        public void AddDefaultBindings()
        {
            Bind<IRepository>().To<DummyRepository>();
        }
    }
}