using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Omnis.Web
{
    using System.Web.Optimization;

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundle/js")
                .Include("~/Scripts/libs/modernizr-1.7.min.js")
                .Include("~/Scripts/kendo/2013.1.319/jquery.min.js")
                .Include("~/Scripts/kendo/2013.1.319/kendo.core.min.js")
                .Include("~/Scripts/kendo/2013.1.319/kendo.web.min.js")
                .Include("~/Scripts/underscore.js")
                .Include("~/Scripts/plugins.js")
                .Include("~/Scripts/script.js")
                .Include("~/Scripts/App/main.js")
                .Include("~/Scripts/App/map.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/bundle/css")
                .Include("~/Content/kendo/2013.1.319/kendo.common.min.css")
                .Include("~/Content/kendo/2013.1.319/kendo.bootstrap.min.css")
                .Include("~/Content/toastr.css")
                .Include("~/Styles/main.css"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}