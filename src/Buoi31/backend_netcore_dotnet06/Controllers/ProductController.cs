// snippet: api-controller-async

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using backend_netcore_dotnet06.Models;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<string> lstProducts = new List<string>(){"Product 1", "Product 2", "Product 3"};

        public static List<ProductDtO> lstProductsDTO = new List<ProductDtO>()
        {
            new ProductDtO(){Id = 1, Name = "Product 1", Price = 10.5m},
            new ProductDtO(){Id = 2, Name = "Product 2", Price = 20.0m},
            new ProductDtO(){Id = 3, Name = "Product 3", Price = 30.0m}
        };
        

        public ProductController()
        {
            
        }

        [HttpGet("GetAllProduct")]
        public List<string> GetProduct()
        {
            return lstProducts;
        }

        [HttpGet("GetAllProductDTO")]
        public List<ProductDtO> GetProductDTO()
        {
            return lstProductsDTO;
        }

        [HttpGet("GetProductById/{id}")]
        public ProductDtO? GetProductById([FromRoute] int id)
        {
            return lstProductsDTO.FirstOrDefault(p => p.Id == id);
        }
        
        [HttpPost("AddProduct")]// FormBody la nguoi dung nhap lieu tu form
        public List<ProductDtO> AddProduct([FromBody] ProductDtO product)
        {
            
            lstProductsDTO.Add(product);
            return lstProductsDTO;
        }

        [HttpDelete("DeleteProduct/{id}")]
        public List<ProductDtO> DeleteProduct([FromRoute] int id)
        {
            var product = lstProductsDTO.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                lstProductsDTO.Remove(product);
            }
            return lstProductsDTO;
        }

        [HttpGet("SearchProductByName")]
        public List<ProductDtO> SearchProductByName([FromQuery] string name)
        {
            return lstProductsDTO.Where(p => p.Name.Contains(name)).ToList();
        }
        
        [HttpPut("UpdateProduct/{id}")]
        public List<ProductDtO> UpdateProduct([FromRoute] int id, [FromBody] ProductDtO updatedProduct)
        {
            var product = lstProductsDTO.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                lstProductsDTO.Remove(product);
                lstProductsDTO.Add(updatedProduct);
            }
            return lstProductsDTO;
        }

        [HttpPatch("DiscountProduct/{id}")]
        public List<ProductDtO> DiscountProduct([FromRoute] int id, [FromBody] decimal discountPercentage)
        {
            var product = lstProductsDTO.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                var discountAmount = product.Price * discountPercentage / 100;
                product.Price -= discountAmount;
            }
            return lstProductsDTO;
        }

        // Dispose la giai phong tai nguyen, giai phong bo nho, giai phong ket noi database, giai phong file stream, giai phong network stream





    }
}