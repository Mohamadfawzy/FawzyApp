using APIFawzyApp.Services;
using FawzyShared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFawzyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly FawzyAppDBContext DB;

        public CoursesController(FawzyAppDBContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = DB.Courses.ToList();
            return Ok(list);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Courses course)
        {
            await DB.Courses.AddAsync(course);
            await DB.SaveChangesAsync();

            return Ok(course);
        }



    }
}
