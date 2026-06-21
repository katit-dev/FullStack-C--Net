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
            // cach 1: su dung LINQ
            // Cach 1: Sử dụng LINQ để truy vấn dữ liệu từ bảng NhanVien và PhongBan
            // var lstNhanVienPB = await _context.NhanViens.Select(item => new
            // {
            //     MaNV = item.Id,
            //     TenNV = item.TenNv,
            //     TenPB = item.MaPbNavigation.TenPb
            // }).ToListAsync();
            // return Ok(lstNhanVienPB);

            // Cach 2: Sử dụng phương thức Join để kết hợp dữ liệu từ hai bảng NhanVien và PhongBan
            // var lstNhanVienPB = await _context.NhanViens.Join(_context.PhongBans,
            // nv => nv.MaPb,
            // pb => pb.Id,
            // (nv, pb) => new
            // {
                
            //     MaNV = nv.Id,
            //     TenNV = nv.TenNv,
            //     TenPb = pb.TenPb
            // }).ToListAsync();
            // return Ok(lstNhanVienPB);

            // cach 3: dung sql raw
            var lstNhanVienPBSqlRaw = await _context.Database.SqlQueryRaw<NhanVienPhongBanDTO>("SELECT nv.Id AS MaNV, nv.TenNV, pb.TenPB FROM NhanVien nv JOIN PhongBan pb ON nv.MaPB = pb.Id").ToListAsync();

            return Ok(lstNhanVienPBSqlRaw);
        }

        [HttpGet("LayThongTinNhanVienDuAn")]
        public async Task<IActionResult> LayThongTinNhanVienDuAn([FromQuery] string tenDuAn)
        {
            var lstNhanVienDuAn = await _context.NhanViens.Include(nv => nv.MaPbNavigation).Include(nv => nv.MaDuAns).Select(item => new
            {
                 TenNV = item.TenNv,
                SoDienThoai = item.SoDienThoai,
                TenPB = item.MaPbNavigation.TenPb,
                Id = item.Id,
                MaDuAn = item.MaDuAns.Select(da => da.Id).FirstOrDefault(),
                tenDuAn = item.MaDuAns.Select(da => da.TenDuAn).FirstOrDefault(),                
                MaDiaDiem = item.MaDuAns.Select(da => da.MaDiaDiem).FirstOrDefault()
            }).ToListAsync();


            // join collection tren voi bang dia diem de lay ra duoc them ten dia diem
            var res = lstNhanVienDuAn.Join(_context.DiaDiems, nv => nv.MaDiaDiem, dd => dd.Id, (nv, dd)
            => new
            {
                Id = nv.TenNV,
                TenVN = nv.TenNV,
                SoDienThoai = nv.SoDienThoai,
                TenPB = nv.TenPB,
                TenDuAn = nv.tenDuAn,
                TenDiaDiem = dd.TenDiaDiem
            }
            ).Where(item => item.TenDuAn.Contains(tenDuAn)).ToList();

            return Ok(res);
        }
       

    }
}

//Tạo DTO để trả về dữ liệu theo yêu cầu
public class NhanVienPhongBanDTO
{
    public int MaNV { get; set; }
    public string TenNV { get; set; }
    public string TenPB { get; set; }
}