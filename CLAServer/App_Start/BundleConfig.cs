﻿using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;
using WebGrease.Extensions;

namespace CLAServer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                "~/Scripts/fullcalendar/fullcalendar.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/scheduler").Include(
                "~/Scripts/fullcalendar-scheduler-1.9.4/fullcalendar-scheduler-1.9.4/scheduler.js"));
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include("~/Scripts/smalot-datetimepicker/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/fullcalendar.css",
                      "~/Scripts/fullcalendar-scheduler-1.9.4/fullcalendar-scheduler-1.9.4/scheduler.css",
                      "~/Content/smalot-datetimepicker/bootstrap-datetimepicker.css"));
            


            bundles.Add(new ScriptBundle("~/bundles/vue").Include("~/Scripts/vue.js"));
            bundles.Add(new ScriptBundle("~/bundles/ModuleScripts").IncludeDirectory("~/Scripts/ModuleScripts","*.js"));
        }

        public static void RegisterWebPackBundles(BundleCollection bundles, string appRootPath, string appRoot)
        {
            var bundleName = string.Format("~/{0}", appRoot);
            var devMode = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["devMode"]);
            //var location = devMode ? @"\dist" : @"\dist\static\js";
            var location = @"\dist";
            var jsPath = GetPathName(location, appRootPath, appRoot,"*.js");
            var cssPath = GetPathName(@"\dist\static\css", appRootPath, appRoot,"*.css");
            bundles.Add(new ScriptBundle(bundleName+"/js")
                .Include(jsPath.ToArray()));

            bundles.Add(new StyleBundle(bundleName+"/css").Include(cssPath.ToArray()));
        }

        private static List<string> GetPathName(string location, string appRootPath, string appRoot,string seachPattern)
        {
            
            var locationWeb = location.Replace(@"\", "/");
            var files = Directory.GetFiles(appRootPath + @"\" + appRoot + location, seachPattern);
            var pathName = new List<string>();
            

            foreach (var file in files)
            {
                var nameOnly = Path.GetFileName(file);
                pathName.Add(string.Format("~/{0}{1}/{2}", appRoot, locationWeb, nameOnly));
            }

            return pathName;
        }
    }
}
