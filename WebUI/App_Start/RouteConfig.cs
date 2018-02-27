using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //name: "Department",
            //url: "{controller}/{action}/{id}",
            //defaults: new { controller = "Department", action = "newDepartment", id = UrlParameter.Optional }
            //);


            //routes.MapRoute(
            //name: "Account",
            //url: "{controller}/{action}/{id}",
            //defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Project", action = "newProject", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
