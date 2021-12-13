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
    public class ProductsController : ControllerBase
    {
        public FawzyAppDBContext DB { get; }

        public ProductsController(FawzyAppDBContext db)
        {
            DB = db;
        }

        
        [HttpGet("getRange/{skip}/{take}")]
        public IActionResult Get(int skip , int take)
        {
            var list = DB.Products.ToList().Skip(skip).Take(take);
            return Ok(list);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Product product)
        {
            //int price = 114;
            var RValue = new ResponseResult<Product>();
            for (int i = 1; i < 150; i++)
            {
                await Task.Delay(100);
                product.ID = new Guid();
                product.Price = new Random().Next(101, 999);
                product.Title = "Product " + i;
                product.Description = "Description " + i;

                await DB.Products.AddAsync(product);
                await DB.SaveChangesAsync();
            }

            RValue.ROpject = product;
            RValue.Status = true;

            return Ok(RValue);
        }

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
