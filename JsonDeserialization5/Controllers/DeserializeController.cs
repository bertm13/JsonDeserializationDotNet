using System;
using System.Diagnostics;
using System.Web.Http;
using JsonDeserialization5.Models;
using Newtonsoft.Json;

namespace JsonDeserialization5.Controllers
{
    public class DeserializeController : ApiController
    {
        [Route("api/any")]
        [HttpPost]
        public IHttpActionResult Any([FromBody] string input)
        {
            var obj = JsonConvert.DeserializeObject(input, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            return Ok(obj);
        }

        [Route("api/typed")]
        [HttpPost]
        public IHttpActionResult Typed([FromBody] string input)
        {
            TestModel obj = null;

            try
            {
                obj = JsonConvert.DeserializeObject<TestModel>(input, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return Ok(obj);
        }

        [Route("api/typedvulnerable")]
        [HttpPost]
        public IHttpActionResult TypedVulnerable([FromBody] string input)
        {
            VulnerableTestModel obj = null;

            try
            {
                obj = JsonConvert.DeserializeObject<VulnerableTestModel>(input, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return Ok(obj);
        }
    }
}
