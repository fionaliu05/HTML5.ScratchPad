using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HTML5.ScratchPad.DDD.WebAPI.Attributes;

namespace HTML5.ScratchPad.DDD.WebAPI.Controllers
{
    [RequireHttps]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ValuesController : ApiController
    {
        private static List<string> values = new List<string>();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return values.ElementAtOrDefault(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            values.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            if (values.Count > id)
                values[id] = value;
            else
                Post(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (values.Count > id)
                values.RemoveAt(id);
        }
    }
}
