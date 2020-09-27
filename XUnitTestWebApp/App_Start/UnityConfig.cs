using Common.Contracts;
using Common.Contracts.Services;
using Data;
using Logic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;
using Unity.Injection;
using XUnitTestWebApp.IoC;

namespace XUnitTestWebApp {
    public static class UnityConfig {
        private static IUnityContainer _container;
        private static IHttpContextAccessor _httpContextAccessor;

        public static IUnityContainer Container {
            get {
                if (_container == null) {
                    _container = BuildUnityContainer();
                }
                return _container;
            }
        }

        public static void RegisterComponents(IHttpContextAccessor httpContextAccessor, HttpConfiguration config) {
            _httpContextAccessor = httpContextAccessor;
            config.DependencyResolver = new UnityResolver(Container);
        }

        private static IUnityContainer BuildUnityContainer() {
            var container = new UnityContainer();

            // DAL
            var connectionString = ConfigurationManager.ConnectionStrings["XUnitTestDb"].ConnectionString;
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestOrTransientLifeTimeManager(_httpContextAccessor), new InjectionConstructor(connectionString));

            // BLL
            container.RegisterType<IServiceHost, ServiceHost>(new PerRequestOrTransientLifeTimeManager(_httpContextAccessor), new InjectionConstructor(container));
            container.RegisterType<IInvoiceService, InvoiceService>();

            return container;
        }
    }
}
