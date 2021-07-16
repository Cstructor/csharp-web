using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace HelloWorld
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // Just like static void Main( )
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterAutofac();
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                //.AsSelf() // PLEASE AVOID - IT DETERS FROM TESTABLE CODE
                .AsImplementedInterfaces();

            //builder.RegisterType<ContactRepository>().As<IContactRepository>();

            var container = builder.Build();

            // Configure dependency resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void xApplication_Error()
        {
            try
            {
                var exception = Server.GetLastError();

                Server.ClearError();

                // log
                // email
            }
            catch (Exception ex)
            {
                // ignore
            }

            try
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Home");
                routeData.Values.Add("action", "Error");

                //IController errorController = new Controllers.HomeController();
                //errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            }
            catch (Exception ex)
            {
                // ignore
            }
        }
    }
}
