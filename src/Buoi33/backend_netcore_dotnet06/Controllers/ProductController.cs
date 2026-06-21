// snippet: api-controller-async

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.Models;
//using backend_netcore_dotnet06.Models;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductStoreContext _context;

        public ProductController(ProductStoreContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProductsSQLRaw()
        {
            //th1: dung lop doi tuong Product --> .Products.FromSqlRaw<Product>($"SELECT * FROM Products").ToListAsync();

            // th2: dung productDTO --> .Database.SqlQueryRaw<ProductDTO>
            List<ProductDTO> res = await _context.Database.SqlQueryRaw<ProductDTO>($"SELECT Id, Name,Price, Alias FROM Products").ToListAsync();
            return Ok(res);
        }

        [HttpGet("GetAllProductsLinq")]
        public async Task<ActionResult> GetAllProductsLinq()
        {
            List<ProductDTO> res = await _context.Products.Skip(0).Take(10).Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Alias = p.Alias
            }).ToListAsync();
            return Ok(res);
        }
        [HttpGet("GetProductsPaging")]
        public async Task<ActionResult> GetProductsPaging([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var pagedProducts = await _context.Products
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Alias = p.Alias
                })
                .ToListAsync();

            return Ok(pagedProducts);
        }

        [HttpGet("GetProductsById/{id}")]
        public async Task<ActionResult> GetProductsById([FromRoute] int id)
        {
            SqlParameter idParam = new SqlParameter("@id", id);

            var product = await _context.Database.SqlQueryRaw<ProductDTO>($"SELECT Id, Name, Price, Alias FROM Products WHERE Id = @id", idParam).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Alias = product.Alias
            };

            return Ok(productDTO);
        }

        [HttpGet("GetProductsByIdLinq/{id}")]
        public async Task<ActionResult> GetProductsByIdLinq([FromRoute] int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Alias = product.Alias
            };

            return Ok(productDTO);
        }

    }



}