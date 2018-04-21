using System;
using System.Collections;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(Properties.Settings.Default.MediaTypeHeaderValue));

            GlobalConfiguration.Configuration.Formatters.Clear();

            if (Properties.Settings.Default.SupportJson)
                GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
            if (Properties.Settings.Default.SupportXML)
                GlobalConfiguration.Configuration.Formatters.Add(new XmlMediaTypeFormatter());

        }
    }
}
