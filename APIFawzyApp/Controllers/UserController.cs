using APIFawzyApp.Services;
using FawzyShared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFawzyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FawzyAppDBContext DB;
        public UserController(FawzyAppDBContext db)
        {
            DB = db;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {

            return Ok("");
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOneAsync([FromBody] User user)
        {
            
            return Ok("");
        }



       // GET: api/<UserController>
       [HttpGet("dget/{id}")]
        public IActionResult Get(int id)
        {
            var result = BC.HashPassword("1234");
            ///BC.EnhancedHashPassword(result);
            var data = new string[] { "value1", "value2", $"{id}" };
            return StatusCode(200, data);
        }

        // GET api/<UserController>/5
        [HttpGet]
        [Route("get/{pass}/{hash}")]
        public async Task<IActionResult> Get(string password, string hash)
        {

            var result = BC.Verify(password, hash);

            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User value)
        {
            // Hash Password and assign result to user password;
            value.Password = BC.HashPassword(value.Password);

            // add new user to database
            await DB.Users.AddAsync(value);
            await DB.SaveChangesAsync();

            return Ok(value);

            //var result = (value);
            //RedirectToAction("get", "User", new { res.ID });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post(string password, string hash)
        {
            // Hash Password and assign result to user password;
            var isValid = BC.Verify(password, hash);
            if (isValid)
            {
                return Ok(DB.Users.FirstOrDefault(x => x.Password == hash));
            }
            return Ok("No");

            //var result = (value);
            //RedirectToAction("get", "User", new { res.ID });
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
