using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Haiku.Web.Controllers
{
    public class ValidatorController : ApiController
    {
        // GET /api/validator
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /api/validator/5
        public string Get(int id)
        {
            return "value";
        }

        // POST /api/validator
        public void Post(string value)
        {
        }

        // PUT /api/validator/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/validator/5
        public void Delete(int id)
        {
        }
    }
}
