using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace HTML5.ScratchPad.DDD.WebServices.Cors.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AllowCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private const string keyCorsAllowOrigin = "cors:allowOrigins";
        private CorsPolicy _policy;

        public AllowCorsPolicyAttribute()
        {
            // Create a CORS policy.
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
                AllowAnyOrigin = false,
                PreflightMaxAge = 10,
                SupportsCredentials = true
            };

            var value = ConfigurationManager.AppSettings[keyCorsAllowOrigin];
            
            if (!string.IsNullOrEmpty(value))
            {
                foreach (var origin in from v in value.Split(';')
                    where !string.IsNullOrEmpty(v) select v) 
                    {
                    // Add allowed origins.
                    _policy.Origins.Add(origin);
                    //_policy.Headers.Add("Access-Control-Allow-Origin");
                    //_policy.Headers.Add("Access - Control - Allow - Credentials");
                    //_policy.Headers.Add("Access - Control - Allow - Credentials", "true");

                    }
            }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}