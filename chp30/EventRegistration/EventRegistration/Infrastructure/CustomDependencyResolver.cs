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
            /* The InRequestScope() method tells NInject to create only one instance of the repository clqass per web request
             * Instances will not be shared between requests, they re destroyed after each request is processed.
             */
            Bind<IRepository>().To<EFRepository>().InRequestScope();
        }
    }
}