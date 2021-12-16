using APIFawzyApp.Services;
using FawzyShared.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIFawzyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public FawzyAppDBContext DB { get; }

        private readonly IWebHostEnvironment _environment;

        public ProductsController(FawzyAppDBContext db, IWebHostEnvironment environment)
        {
            DB = db;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));

        }


        [HttpGet("getRange/{skip}/{take}")]
        public IActionResult Get(int skip, int take)
        {
            var list = DB.Products.ToList().Skip(skip).Take(take);
            return Ok(list);
        }
       
        [HttpPost("UploadFiles")]
        //[Route("UploadFiles")]
        public async Task<IActionResult> UploadFiles()
        {
            try
            {
                var httpRequest = HttpContext.Request;
                var title = httpRequest.Headers.ContainsKey("Title");

                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var filePath = Path.Combine(_environment.ContentRootPath, "uploads");

                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream); System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }

                        return Ok();
                    }
                }
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }

            return BadRequest();
        }


        [HttpPost()]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(Product product)
        {
            //file.CopyToAsync
            try
            {
                var httpRequest = HttpContext.Request;
                var filePath = Path.Combine(_environment.ContentRootPath, "uploads");

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                using (var memoryStream = new MemoryStream(product.Bytes))
                {
                    //await product.File.CopyToAsync(memoryStream);
                    System.IO.File.WriteAllBytes(Path.Combine(filePath, Guid.NewGuid().ToString()+".jpg"), memoryStream.ToArray());
                    //await UploadToAzureAsync(file);
                }

                return Ok();

            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error");
                return new StatusCodeResult(500);
            }

            return BadRequest();
        }


        //[HttpPost("Create")]
        //public async Task<IActionResult> Create(Product product)
        //{
        //    //int price = 114;
        //    var RValue = new ResponseResult<Product>();
        //    for (int i = 1; i < 150; i++)
        //    {
        //        await Task.Delay(100);
        //        product.ID = new Guid();
        //        product.Price = new Random().Next(101, 999);
        //        product.Title = "Product " + i;
        //        product.Description = "Description " + i;

        //        await DB.Products.AddAsync(product);
        //        await DB.SaveChangesAsync();
        //    }

        //    RValue.ROpject = product;
        //    RValue.Status = true;

        //    return Ok(RValue);
        //}

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOneAsync(Guid id)
        {
            var product = DB.Products.FirstOrDefault(s => s.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            var result = DB.Products.Remove(product);
            await DB.SaveChangesAsync();
            //result.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return Ok(result.State);

        }
    }
}
