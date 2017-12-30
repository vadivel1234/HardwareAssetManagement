﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Asset_Management
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.LowercaseUrls = true;
            RouteTable.Routes.AppendTrailingSlash = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
               name: "requestnewdevice", // Route name
               url: "request/{devicetype}", // URL with parameters
                 defaults: new { controller = "AssetManagement", action = "RequestDevice", devicetype = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "devicelists", // Route name
               url: "devicelist", // URL with parameters
                 defaults: new { controller = "AssetManagement", action = "DeviceList" }
           );

            routes.MapRoute(
                name: "DeviceCategory",
                url: "purchase",
                defaults: new { controller = "AssetManagement", action = "PurchaseRequest", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MyDevices",
                url: "mydevices",
                defaults: new { controller = "Account", action = "EmployeeAssets" }
            );

            routes.MapRoute(
               name: "RequestDevice",
               url: "approve/devicerequest",
               defaults: new { controller = "Account", action = "RequestAssets" }
           );

            routes.MapRoute(
               name: "PurchaseDevice",
               url: "approve/purchase",
               defaults: new { controller = "Account", action = "PurchaseAssets" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
