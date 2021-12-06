using APIFawzyApp.Services;
using FawzyShared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFawzyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCoursesController : ControllerBase
    {


        private readonly FawzyAppDBContext DB;

        public StudentsCoursesController(FawzyAppDBContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            

            var list = DB.Courses.ToList();
            return Ok(list);
        }

        [HttpGet("GetStudentCourses/{studentID}")]
        public async Task<IActionResult> DoGetStudentCourses(Guid studentID)
        {
            var studentValue = await DB.Students.FirstOrDefaultAsync(s => s.ID == studentID);
            if (studentValue == null)
                return NotFound();
            var coursesList = await DB.Students_Courses.Where(sc => sc.Student_Id == studentID).Include(sc => sc.Courses).ToListAsync();
            return Ok(coursesList);
        }
    }
}
