using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var result = BC.HashPassword("1234");
            BC.EnhancedHashPassword(result);
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet]
        [Route("get/{id}")]
        public string Get(string pass)
        {
            return pass;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var result = BC.HashPassword(value);
            RedirectToAction("get", "User", new { result });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
