using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Models.DBQuanLyNhanVien;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using backend_netcore_dotnet06.Models;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyNhanVienController : ControllerBase
    {
        private readonly QuanLyNhanVienContext _context;
        public QuanLyNhanVienController(QuanLyNhanVienContext context)
        {
            _context = context;
        }

        [HttpGet("LayThongTinNhanVienPhongBan")]
        public async Task<ActionResult> LayThongTinNhanVienPhongBan()
        {

            var lstNhanVienPB = await _context.NhanViens.Select(item => new
            {
                MaNV = item.Id,
                TenNV = item.TenNv,
                TenPB = item.MaPbNavigation.TenPb
            }).ToListAsync();

            return Ok(lstNhanVienPB);
        }

       

    }
}