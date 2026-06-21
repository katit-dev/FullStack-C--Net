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
        public static List<string> lstProduct = new List<string>{"Product 1", "Product 2", "Product 3"};

        public static List<ProductDTO> lstProductDTO = new List<ProductDTO>{
            new ProductDTO{Id = 1, Name = "Product 1", Price = 10.0m},
            new ProductDTO{Id = 2, Name = "Product 2", Price = 20.0m},
            new ProductDTO{Id = 3, Name = "Product 3", Price = 30.0m}
        };
        public ProductController()
        {
        }

        // GET: api/Product
        [HttpGet ("GetAllProducts")]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(lstProduct);
        }

        [HttpGet ("GetAllProductsDTO")]
        public async Task<IActionResult> GetProductDTO()
        {
            var response = new ResponseTypeDTO<List<ProductDTO>>
            {
                StatusCode = 200,
                Message = "get all products successfully",
                Content = lstProductDTO,
                Date = DateTime.UtcNow
            };
            return StatusCode(StatusCodes.Status200OK, response);
        }

        // get product by id
        [HttpGet ("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            ProductDTO? proDetail = await Task.FromResult(lstProductDTO.FirstOrDefault(p => p.Id == id));
            var response = new ResponseTypeDTO<ProductDTO>
            {
                StatusCode = 404,
                Message = "khong tim thay san pham " + id ,
                Content = null,
                Date = DateTime.UtcNow
            };
            if(proDetail != null)
            {
                response.StatusCode = 200;
                response.Message = "get product successfully";
                response.Content = proDetail;
                return StatusCode(StatusCodes.Status200OK, response);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }

        // add
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO product)
        {
            var response = new ResponseTypeDTO<ProductDTO>
            {
                StatusCode = 400,
                Message = "san pham da ton tai",
                Content = null,
                Date = DateTime.UtcNow
            };

            // kiem tra id da ton tai chua
            var existingProduct = lstProductDTO.FirstOrDefault(p => p.Id == product.Id);
            // neu chua ton tai thi add
            if(existingProduct == null)
            {
                lstProductDTO.Add(product);
                response.StatusCode = 200;
                response.Message = "add product successfully";
                response.Content = product;
                return StatusCode(StatusCodes.Status200OK, response);
            }
            // neu ton tai roi thi thoi
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        // delete
        [HttpDelete("DeleteProduct/{id}")]
        public List<ProductDTO> DeleteProduct([FromRoute] int id)
        {
            // lay ra phan tu can xoa
            var productToMove = lstProductDTO.FirstOrDefault(p => p.Id == id);
            //kiem tra neu tim duoc thi xoa
            if(productToMove != null)
            {
                lstProductDTO.Remove(productToMove);
            }
            // khong tim thay thi thoi
            return lstProductDTO;
        }

        // search
        [HttpGet("SearchProductByName")]
        public List<ProductDTO> SearchProductByName([FromQuery] string name)
        {
            return lstProductDTO.Where(p => p.Name.Contains(name)).ToList();
        }

        // update
        [HttpPut("UpdateProduct/{id}")]
        public List<ProductDTO> UpdateProdut([FromBody] ProductDTO product)
        {
            // tim dua tren id
            var productToUpdate = lstProductDTO.FirstOrDefault(p => p.Id == product.Id);
            // tim thay thi update
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
            }
            return lstProductDTO;
        }

        // update gia theo % discount
        [HttpPatch("UpdatePrice/{id}")]
        public List<ProductDTO> UpdatePrice ([FromRoute] int id,[FromBody] int discountPercentage)
        {
            var product = lstProductDTO.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                var discountAmount = product.Price * discountPercentage / 100;
                product.Price -= discountAmount;
            }
            return lstProductDTO;
        } 
    }
}