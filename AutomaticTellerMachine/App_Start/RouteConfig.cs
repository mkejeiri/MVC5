using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutomaticTellerMachine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // //http://localhost:49198/serial?letterCase=lower
            // routes.MapRoute(
            //    name: "Serial Number",
            //    url: "Serial",
            //    defaults: new { controller = "Home", action = "Serial"}
            //);

            //  routes.MapRoute(
            //    name: "Serial Number",
            //    url: "Serial/{letterCase}",
            //    defaults: new { controller = "Home", action = "Serial", letterCase = "upper" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
