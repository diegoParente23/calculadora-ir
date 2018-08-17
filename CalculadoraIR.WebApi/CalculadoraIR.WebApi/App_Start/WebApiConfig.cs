﻿using System.Web.Http;
using System.Web.Http.Cors;

namespace CalculadoraIR.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Habilita os cors
            var cors = new EnableCorsAttribute(
            origins: "*",
            headers: "*",
            methods: "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
