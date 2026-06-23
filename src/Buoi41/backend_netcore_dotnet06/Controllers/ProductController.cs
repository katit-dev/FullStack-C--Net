// snippet: api-controller-async
// snippet: api-controller-async

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend_netcore_dotnet06.Helper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;

        private readonly IWebHostEnvironment _environment;

        public ProductController(ProductStoreContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProductsSQLRaw()
        {
            List<ProductDTO> res = await _context.Database.SqlQueryRaw<ProductDTO>($"SELECT Id, Name,Price, Alias FROM Products").ToListAsync();
            return Ok(res);
        }

        [Authorize]
        [HttpGet("GetAllProductsLinq")]
        public async Task<ActionResult> GetAllProductsLinq()
        {
            List<ProductDTO> res = await _context.Products.Where(p => p.Deleted == false).Skip(0).Take(10).Select(p => new ProductDTO
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
                .Where(p => p.Deleted == false)
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

        // tim kiem product
        [HttpGet("SearchProductsSQLRaw")]
        public async Task<ActionResult> SearchProductsSQLRaw([FromQuery] string keyword)
        {
            keyword = HelperFunction.StringToSlug(keyword);
            SqlParameter keywordParam = new SqlParameter("@keyword", $"%{keyword}%");

            List<ProductDTO> products = await _context.Database.SqlQueryRaw<ProductDTO>($"SELECT Id, Name, Price, Alias, Description FROM Products WHERE Alias LIKE @keyword OR Description LIKE @keyword", keywordParam).ToListAsync();

            return Ok(products);
        }

        [HttpGet("SearchProductsLinq")]
        public async Task<ActionResult> SearchProductsLinq([FromQuery] string keyword)
        {
            keyword = HelperFunction.StringToSlug(keyword);
            List<ProductDTO> products = await _context.Products
                .Where(p => p.Alias.Contains(keyword) || p.Description.Contains(keyword))
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Alias = p.Alias,
                    Description = p.Description
                }).OrderBy(n => n.Id).Skip(0).Take(10)
                .ToListAsync();

            return Ok(products);
        }

        // insert product
        [HttpPost("InsertProductSQLRaw")]
        public async Task<ActionResult> InsertProductSQLRaw([FromBody] ProductInsertDTO newproduct)
        {
            SqlParameter nameParam = new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = newproduct.Name };
            SqlParameter priceParam = new SqlParameter("@price", System.Data.SqlDbType.Decimal) { Value = newproduct.Price };
            SqlParameter aliasParam = new SqlParameter("@alias", System.Data.SqlDbType.NVarChar, 255) { Value = HelperFunction.StringToSlug(newproduct.Name) };
            SqlParameter descriptionParam = new SqlParameter("@description", System.Data.SqlDbType.NVarChar, 255) { Value = newproduct.Description ?? (object)DBNull.Value };
            SqlParameter imageUrlParam = new SqlParameter("@imageUrl", System.Data.SqlDbType.NVarChar, 255) { Value = newproduct.ImageUrl ?? (object)DBNull.Value };
            SqlParameter deletedParam = new SqlParameter("@deleted", System.Data.SqlDbType.Bit) { Value = false };
            await _context.Database.ExecuteSqlRawAsync($"INSERT INTO Products (Name, Alias, Price, Description, ImageUrl, Deleted) VALUES (@name, @alias, @price, @description, @imageUrl, @deleted)", nameParam, aliasParam, priceParam, descriptionParam, imageUrlParam, deletedParam);
            return StatusCode(201, "Product inserted successfully");

        }

        [HttpPost("InsertProductLinq")]
        public async Task<ActionResult> InsertProductLinq([FromBody] ProductInsertDTO newproduct)
        {
            // cach 1 : map tay tu productDTO sang product model
            // Product proModel = new Product
            // {
            //     Name = newproduct.Name,                
            //     Alias = HelperFunction.StringToSlug(newproduct.Name),
            //     Price = newproduct.Price,
            //     Description = newproduct.Description,
            //     ImageUrl = newproduct.ImageUrl,
            //     Deleted = false,
            //     CreatedAt = DateTime.Now,
            //     UpdatedAt = DateTime.Now
            // };

            // cach 2: Map bang automapper, dung de map cac thuoc tinh ten giong nhua nhung khac class(lop doi tuong khac nhau)
            Product proModel = _mapper.Map<Product>(newproduct);
            // proModel.Deleted = false;
            // proModel.CreatedAt = DateTime.Now;
            // proModel.UpdatedAt = DateTime.Now;


            _context.Products.Add(proModel);
            await _context.SaveChangesAsync();

            return StatusCode(201, "Product inserted successfully");
        }

        [HttpPut("UpdateProductFromSQLRaw/{id}")]
        public async Task<ActionResult> UpdateProductFromSQLRaw([FromRoute] int id, [FromBody] ProductUpdate updateProduct)
        {
            SqlParameter idParam = new SqlParameter("@id", id);
            SqlParameter nameParam = new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = updateProduct.Name };
            SqlParameter priceParam = new SqlParameter("@price", System.Data.SqlDbType.Decimal) { Value = updateProduct.Price };
            SqlParameter aliasParam = new SqlParameter("@alias", System.Data.SqlDbType.NVarChar, 255) { Value = HelperFunction.StringToSlug(updateProduct.Name) };
            SqlParameter descriptionParam = new SqlParameter("@description", System.Data.SqlDbType.NVarChar, 255) { Value = updateProduct.Description ?? (object)DBNull.Value };
            SqlParameter imageUrlParam = new SqlParameter("@imageUrl", System.Data.SqlDbType.NVarChar, 255) { Value = updateProduct.ImageUrl ?? (object)DBNull.Value };

            int rowsAffected = await _context.Database.ExecuteSqlRawAsync($"UPDATE Products SET Name = @name, Alias = @alias, Price = @price, Description = @description, ImageUrl = @imageUrl, UpdatedAt = GETDATE() WHERE Id = @id", nameParam, aliasParam, priceParam, descriptionParam, imageUrlParam, idParam);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return Ok("Product updated successfully");
        }

        [HttpPut("UpdateProductFromLinq/{id}")]
        public async Task<ActionResult> UpdateProductFromLinq([FromRoute] int id, [FromBody] ProductUpdate proUpdate)
        {
            // Lay ra dong du lieu tu database map ra C# dong thoi kiem tra co trong csdl hay khong
            Product? prodModel = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (prodModel == null)
            {
                return NotFound($"Khong tim thay san pham voi ID {id}");
            }

            // Neu co thi update gia tri moi vao model (map tay hoac auto mapper)
            // prodModel = _mapper.Map<Product>(proUpdate); // tạo một object Product moi 
            // dung cho insert vi no new 1 vung nho moi cho Product

            _mapper.Map(proUpdate, prodModel); // prodModel vẫn là object đang được EF Core track
            _context.Products.Update(prodModel);

            // Luu thay doi vao database
            await _context.SaveChangesAsync();
            return Ok("Product updated successfully");

        }


        [HttpDelete("DeleteProductFromLinq/{id}")]
        public async Task<ActionResult> DeleteProductFromLinq([FromRoute] int id)
        {
            // kiem tra existing
            Product? prd = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (prd == null)
            {
                return NotFound($"Khong tim thay san pham voi ID {id}");
            }

            _context.Products.Remove(prd);
            await _context.SaveChangesAsync();

            return Ok("Product deleted successfully");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult> DeleteProductFromSQLRaw([FromRoute] int id)
        {
            Product? prd = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (prd == null)
            {
                return NotFound($"Khong tim thay san pham voi ID {id}");
            }
            prd.Deleted = true;
            await _context.SaveChangesAsync();

            return Ok("Product deleted successfully");
        }

        [HttpPost("Uploadfile")]
        public async Task<ActionResult> UploadFile(IFormFile files)
        {
            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = Path.GetFileName(files.FileName);

            var newFileName = $"{Guid.NewGuid()}_{fileName}";

            var filePath = Path.Combine(uploadPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await files.CopyToAsync(stream);
            }

            return Ok("ok");
        }

    }

}