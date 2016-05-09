﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Adventure.EFCodeFirst.Models;

namespace Adventure.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
                                  
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            ////
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<DTOCustomer>("OData4");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<CustomerAddress>("CustomerAddresses");
            builder.EntitySet<SalesOrderHeader>("SalesOrderHeaders");

            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            ////
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
