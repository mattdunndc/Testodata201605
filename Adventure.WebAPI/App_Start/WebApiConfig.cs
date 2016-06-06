using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Adventure.EFCodeFirst.Models;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using Microsoft.OData.Edm;
using Adventure.WebAPI.Models;

namespace Adventure.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API configuration and services
            var allowedCors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(allowedCors);

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //
            //config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            config.MapODataServiceRoute(
               routeName: "ODataRoute",
               routePrefix: "odata",
               model: GenerateEntityDataModel());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ////
            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            //builder.EntitySet<CustomerDTO>("OData4");
            //builder.EntitySet<Customer>("Customers");
            //builder.EntitySet<CustomerAddress>("CustomerAddresses");
            //builder.EntitySet<SalesOrderHeader>("SalesOrderHeaders");

            
            ////
        }

        #region GenerateEntityDataModel
        private static IEdmModel GenerateEntityDataModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            // Queryable DTOTask
            builder.EntitySet<CustomerDTO>("CustomersDTO");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<CustomerAddress>("CustomerAddresses");
            builder.EntitySet<SalesOrderHeader>("SalesOrderHeaders");

            builder.EntitySet<Tweet>("Tweets");

            // FilterByStatus function that takes a parameter and returns Tasks
            //var ByStatusFunction = builder.Function("ByStatus");
            //ByStatusFunction.ReturnsCollectionFromEntitySet<Models.DTOTask>("DTOTasks");
            //ByStatusFunction.Parameter<System.Boolean>("IsComplete");

            return builder.GetEdmModel();
        }
        #endregion
    }
}
