using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CrockettWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() 
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Acquire_RequestState()
        {
            string User = Session["AUTHUser"] as string;
            string roles = Session["AUTHRoles"] as string;
            string How = Session["AUTH"]
            
        }
    }
}
