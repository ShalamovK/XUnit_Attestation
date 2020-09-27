using Common.Contracts;
using Data;
using System;
using System.Configuration;
using Unity;
using Unity.Injection;

namespace XUnitTestApp {
    class Program {
        static void Main(string[] args) {
            var container = new UnityContainer();
            var connectionString = ConfigurationManager.ConnectionStrings["XUnitTestDb"].ConnectionString;
            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(connectionString));

            // BLL
            container.RegisterType<ISanMarService, SanMarService>();


        }
    }
}
