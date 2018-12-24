using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KubeSample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace KubeSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values.
        readonly IConfiguration _configuration;


        public ValuesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string result = $"{System.Environment.MachineName}";
            string COnnStr = _configuration["Database:ConnectionString"];
            DataAccessLayer dal = new DataAccessLayer();
            string  values = dal.get(COnnStr);
            List<string >list = new List<string>(){"Machine Name " + result,"Connection String --=" + COnnStr, "---- Table returned Values ="+ values};

            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
