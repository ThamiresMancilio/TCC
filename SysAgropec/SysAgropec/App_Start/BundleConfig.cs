﻿using System.Web;
using System.Web.Optimization;

namespace SysAgropec
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.dcjqaccordion.2.7.js",
                "~/Scripts/jquery.scrollTo.min.js",
                "~/Scripts/jquery.nicescroll.js",
                "~/Scripts/jquery.sparkline.js",
                "~/Scripts/common-scripts.js",
                "~/Scripts/gritter/js/jquery.gritter.js",
                "~/Scripts/gritter-conf.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jquery-paginator").Include(
                "~/Scripts/paging.js",
                "~/Scripts/jquery-ui.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jquery-fileinput").Include(
                "~/Scripts/pt-BR.js",
                "~/Scripts/fileinput.js",
                "~/Scripts/themes/explorer/theme.js",
                "~/Scripts/plugins/sortable.js",
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/bootstrap.min.js"

                ));

            bundles.Add(new StyleBundle("~/bundles/bootstrap2").Include(
                      "~/Styles/bootstrap.css",
                      "~/Styles/lineicons_style.css",
                      "~/Styles/style.css",
                        "~/Styles/style-responsive.css",
                  "~/assets/font-awesome/css/font-awesome.css",
                      "~/Scripts/gritter/css/jquery.gritter.css"));

            bundles.Add(new StyleBundle("~/bundles/login").Include(
              "~/Styles/bootstrap.css",
              "~/Styles/style.css",
              "~/Styles/style-login.css"
              ));

            bundles.Add(new StyleBundle("~/bundles/fileinput").Include(
              "~/Styles/fileinput.css",
              "~/Styles/theme.css"

              ));

            bundles.Add(new StyleBundle("~/bundles/paging").Include(
              "~/Styles/paging.css"

              ));
        }
    }
}