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
    public class StudentsController : ControllerBase
    {
        private readonly FawzyAppDBContext DB;

        public StudentsController(FawzyAppDBContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = DB.Students.ToList();
            return Ok(list);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Students student)
        {
            var RValue = new ResponseResult<Students>();

            await DB.Students.AddAsync(student);
            await DB.SaveChangesAsync();

            RValue.ROpject = student;
            RValue.Status = true;

            return Ok(RValue);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOneAsync(Guid id)
        {
            var student = DB.Students.FirstOrDefault(s => s.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            var result = DB.Students.Remove(student);
            await DB.SaveChangesAsync();
            //result.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return Ok(result.State);

        }
    }
}
