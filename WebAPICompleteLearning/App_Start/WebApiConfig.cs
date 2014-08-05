using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using WebAPICompleteLearning.Models;

namespace WebAPICompleteLearning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //default
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //modified name
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{orgid}/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional },
            //    constraints: new { orgid = @"\d+" } 
            //);
            //for rpc call
            //config.Routes.MapHttpRoute(
            //    name: "RpcApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            //for json(override to work for all browser, if content type is not properly defined)

            //formatting using class

            //var fwtMediaFormatter = new FixedWidthTextMediaFormatter();
            //fwtMediaFormatter.MediaTypeMappings.Add(
            //new QueryStringMapping("frmt", "fwt",
            //new MediaTypeHeaderValue("text/plain")));
            //config.Formatters.Add(fwtMediaFormatter);



            //config.Formatters.Add(new JsonpMediaTypeFormatter());

            //Beatify JSON
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Respoonce type is JSON is all case
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            //To format numbers for different format
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new NumberConverter());

            //Culture Handler
            config.MessageHandlers.Add(new CultureHandler());

            //Encoding Handler
            //config.MessageHandlers.Add(new EncodingHandler());
            // Other handlers go here


            //foreach (var encoding in config.Formatters.JsonFormatter.SupportedEncodings)
            //{
            //    System.Diagnostics.Trace.WriteLine(encoding.WebName);
            //}

            //we retrive array of media type accepted by browser
            //here we can chnage or do anything what we want

            //content type based on query string
            //config.Formatters.JsonFormatter.MediaTypeMappings.Add(
            //    new QueryStringMapping("frmt", "json",
            //        new MediaTypeHeaderValue("application/json")));
            //config.Formatters.XmlFormatter.MediaTypeMappings.Add(
            //    new QueryStringMapping("frmt", "xml",
            //        new MediaTypeHeaderValue("application/xml")));

            //foreach (var formatter in config.Formatters)
            //{
            //    Trace.WriteLine(formatter.GetType().Name);
            //    Trace.WriteLine("\tCanReadType: " + formatter.CanReadType(typeof(Employee)));
            //    Trace.WriteLine("\tCanWriteType: " + formatter.CanWriteType(typeof(Employee)));
            //    Trace.WriteLine("\tBase: " + formatter.GetType().BaseType.Name);
            //    Trace.WriteLine("\tMedia Types: " + String.Join(", ", formatter.
            //    SupportedMediaTypes));
            //}

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
