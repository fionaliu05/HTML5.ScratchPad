using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace HTML5.ScratchPad.DDD.WebServices.Cors.Handlers
{
    public class CorsHandler : DelegatingHandler
    {
        //[HttpHeader("Access-Control-Allow-Origin", "http://localhost:51234")]
        //    [HttpHeader("Access-Control-Allow-Credentials", "true")]
        //    [HttpHeader("Access-Control-Allow-Methods", "ACCEPT, PROPFIND, PROPPATCH, COPY, MOVE, DELETE, MKCOL, LOCK, UNLOCK, PUT, GETLIB, VERSION-CONTROL, CHECKIN, CHECKOUT, UNCHECKOUT, REPORT, UPDATE, CANCELUPLOAD, HEAD, OPTIONS, GET, POST")]
        //    [HttpHeader("Access-Control-Allow-Headers", "Accept, Overwrite, Destination, Content-Type, Depth, User-Agent, X-File-Size, X-Requested-With, If-Modified-Since, X-File-Name, Cache-Control")]
        //    [HttpHeader("Access-Control-Max-Age", "3600")]

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Options)
            {
                var apiExplorer = request.GetConfiguration().Services.GetApiExplorer();

                var controllerRequested = request.GetRouteData().Values["controller"] as string;
                var supportedMethods = apiExplorer.ApiDescriptions
                    .Where(d =>
                    {
                        var controller = d.ActionDescriptor.ControllerDescriptor.ControllerName;
                        return string.Equals(
                            controller, controllerRequested, StringComparison.OrdinalIgnoreCase);
                    })
                    .Select(d => d.HttpMethod.Method)
                    .Distinct();

                if (!supportedMethods.Any())
                {
                    return Task.FromResult(request.CreateResponse(HttpStatusCode.NotFound));
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Headers.Add("Access-Control-Allow-Methods", string.Join(",", supportedMethods));

                //response.Headers.Add("Access-Control-Allow-Origin", AppCorsConstants.AllowedOrigins);
                response.Headers.Add("Access-Control-Allow-Headers", AppCorsConstants.AllowedHeaders);
                //response.Headers.Add("Access-Control-Allow-Methods", AppCorsConstants.AllowedMethods);

                return Task.FromResult(response);
            }



            //if (request.Headers.Contains("Origin") && request.Method.Method.Equals("OPTIONS"))
            //{
            //    var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            //    // Define and add values to variables: origins, headers, methods (can be global)               
            //    response.Headers.Add("Access-Control-Allow-Origin", AppCorsConstants.AllowedOrigins);
            //    response.Headers.Add("Access-Control-Allow-Headers", AppCorsConstants.AllowedHeaders);
            //    response.Headers.Add("Access-Control-Allow-Methods", AppCorsConstants.AllowedMethods);
            //    var tsc = new TaskCompletionSource<HttpResponseMessage>();
            //    tsc.SetResult(response);
            //    return tsc.Task;
            //}
            return base.SendAsync(request, cancellationToken);
        }
    }
}