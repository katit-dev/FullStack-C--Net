// snippet: api-controller-async

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Helper;
using Microsoft.AspNetCore.Mvc;
//using backend_netcore_dotnet06.Models;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<string> lstProducts = new List<string>() { "Product 1", "Product 2", "Product 3" };

        public static List<ProductDTO> lstProductsDTO = new List<ProductDTO>()
        {
           new ProductDTO() { Id = 1, Name = "Điện thoại iphone 17 pro max", Price = 10000 },
            new ProductDTO() { Id = 2, Name = "Samsung galaxy Note 25 ultra ", Price = 20000 },
            new ProductDTO() { Id = 3, Name = "Xiaomi mi 17 pro max", Price = 15000 }
        };


        static ProductController()
        {
            foreach (var product in lstProductsDTO)
            {
                product.Alias = HelperFunction.StringToSlug(product.Name);
            }
        }

        public ProductController()
        {
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(lstProducts);
        }

        // c1: dung ham tra ve cua C# de tra ve status code va noi dung
        [HttpGet("GetAllProductDTO")]
        public async Task<IActionResult> GetProductDTO()
        {
            var response = new ResponseTypeDTO<List<ProductDTO>>()
            {
                StatusCode = 200,
                Message = "Success",
                Content = lstProductsDTO,
                DateTime = DateTime.Now
            };
            return Ok(response);
        }

        // // c2: custom lai ham tra ve de tra ve status code va noi dung
        // [HttpGet("GetAllProductDTO")]
        // public async Task<ResponseTypeDTO<List<ProductDtO>>> GetProductDTO()
        // {
        //     var response = new ResponseTypeDTO<List<ProductDtO>>()
        //     {
        //         StatusCode = 200,
        //         Message = "Success",
        //         Content = lstProductsDTO,
        //         DateTime = DateTime.Now
        //     };
        //     return StatusCode(StatusCodes.Status200OK, response);
        // }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            // kiem tra xem id co ton tai trong list hay khong, neu co thi tra ve phan tu do neu khong tra loi 400
            ProductDTO? prodDetail = await Task.FromResult(lstProductsDTO.FirstOrDefault(p => p.Id == id));

            var response = new ResponseTypeDTO<dynamic>()
            {
                StatusCode = 400,
                Message = "Product not found",
                Content = null,
                DateTime = DateTime.Now
            };

            if (prodDetail == null)
            {
                response.Content = "khong tim thay san pham voi id = " + id;
                return BadRequest(response);// status code 400
            }
            else
            {
                response.Content = prodDetail;
                return Ok(response);// status code 200
            }
        }


        [HttpPost("AddProduct")]// FormBody la nguoi dung nhap lieu tu form
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO product)
        {
            // kiem tra trung
            var existingProduct = lstProductsDTO.FirstOrDefault(p => p.Id == product.Id);

            var response = new ResponseTypeDTO<dynamic>()
            {
                StatusCode = 400,
                Message = "Product with the same ID already exists.",
                Content = null,
                DateTime = DateTime.Now
            };

            if (existingProduct != null)
            {
                response.Content = "San pham voi id = " + product.Id + " da ton tai";
                return BadRequest(response);
            }
            else
            {
                // doi ten san pham thanh alias
                product.Alias = HelperFunction.StringToSlug(product.Name);
                lstProductsDTO.Add(product);
                response.StatusCode = 200;
                response.Message = "Product added successfully.";
                response.Content = product;
                return Ok(response);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = lstProductsDTO.FirstOrDefault(p => p.Id == id);

            // kiem tra khac null thi xoa
            if (product != null)
            {
                lstProductsDTO.Remove(product);
                var response = new ResponseTypeDTO<dynamic>()
                {
                    StatusCode = 200,
                    Message = "Product deleted successfully.",
                    Content = product,
                    DateTime = DateTime.Now
                };
                return Ok(response);
            }
            else
            {
                var response = new ResponseTypeDTO<dynamic>()
                {
                    StatusCode = 400,
                    Message = "Product not found.",
                    Content = null,
                    DateTime = DateTime.Now
                };
                return BadRequest(response);
            }
        }


        //nguyễn VăN A => nguyen-van-a
        //list : nguyễn văn a => nguyen-van-a => alias: nguyen-van-a

        [HttpGet("SearchProductByName")]
        public async Task<IActionResult> SearchProductByName([FromQuery] string keyword) //ĐIỆN THOẠI -> dien-thoai
        {
            string name = HelperFunction.StringToSlug(keyword);
            var lstSearchProduct = await Task.FromResult(lstProductsDTO.Where(p => p.Alias.Contains(name)).ToList());
            if (lstSearchProduct.Count == 0)
            {
                var responseData = new ResponseTypeDTO<string>()
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy sản phẩm với tên: " + keyword,
                    Content = null,
                    DateTime = DateTime.Now
                };
                return StatusCode(StatusCodes.Status404NotFound, responseData);
            }
            else
            {
                var response = new ResponseTypeDTO<List<ProductDTO>>()
                {
                    StatusCode = 200,
                    Message = @$"Tìm thấy {lstSearchProduct.Count} sản phẩm với tên: {keyword}",
                    Content = lstSearchProduct,
                    DateTime = DateTime.Now
                };
                return StatusCode(StatusCodes.Status200OK, response);
            }

        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDTO updatedProduct)
        {
            var productToUpdate = lstProductsDTO.SingleOrDefault(p => p.Id == updatedProduct.Id);
            if (productToUpdate == null)
            {
                var responseData = new ResponseTypeDTO<string>()
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy sản phẩm với id: " + updatedProduct.Id,
                    Content = null,
                    DateTime = DateTime.Now
                };
                return StatusCode(StatusCodes.Status404NotFound, responseData);
            }else
            {
                productToUpdate.Name = updatedProduct.Name;
                productToUpdate.Price = updatedProduct.Price;
                productToUpdate.Alias = HelperFunction.StringToSlug(updatedProduct.Name);
                var response = new ResponseTypeDTO<List<ProductDTO>>()
                {
                    StatusCode = 200,
                    Message = "Cập nhật sản phẩm thành công",
                    Content = lstProductsDTO,
                    DateTime = DateTime.Now
                };
                return StatusCode(StatusCodes.Status200OK, response);
            }
        }

        [HttpPatch("DiscountProduct/{id}")]
        public List<ProductDTO> DiscountProduct([FromRoute] int id, [FromBody] decimal discountPercentage)
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