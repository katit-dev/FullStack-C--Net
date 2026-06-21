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
            // Cach 1: Sử dụng LINQ để truy vấn dữ liệu từ bảng NhanVien và PhongBan
            // var lstNhanVienPB = await _context.NhanViens.Select(item => new
            // {
            //     MaNV = item.Id,
            //     TenNV = item.TenNv,
            //     TenPB = item.MaPbNavigation.TenPb
            // }).ToListAsync();
            // return Ok(lstNhanVienPB);

            //Cách 2: Dùng phép join (dữ liệu bảng B không nhất thiết là dữ liệu từ db chỉ cần Collection List)
            var lstNhanVienPB = await _context.NhanViens.Join(_context.PhongBans,
            nv => nv.MaPb,
            pb => pb.Id,
            (nv, pb) => new NhanVienPhongBanDTO
            {
                MaNV = nv.Id,
                TenNV = nv.TenNv,
                TenPB = pb.TenPb
            }
            ).ToListAsync();
            // return Ok(lstNhanVienPB);

            //Cách 3: Dùng câu lệnh SQL thuần 
            var lstNhanVienPBSQLRaw = await _context.Database.SqlQueryRaw<NhanVienPhongBanDTO>("SELECT NhanVien.Id AS MaNV, NhanVien.TenNV, PhongBan.TenPB FROM NhanVien JOIN PhongBan ON NhanVien.MaPb = PhongBan.Id").ToListAsync();
            return Ok(lstNhanVienPBSQLRaw);

        }

        // [HttpGet("LayThongTinNhanVienDuAn")]
        // public async Task<ActionResult> LayThongTinNhanVienDuAn([FromQuery] string tenDuAn)
        // {
        //   var lstNhanVienDuAn = await _context.NhanViens.Include(nv => nv.MaPbNavigation).Include(nv => nv.MaDuAns).Select(item => new
        //     {

        //         TenNV = item.TenNv,
        //         SoDienThoai = item.SoDienThoai,
        //         TenPB = item.MaPbNavigation.TenPb,
        //         Id = item.Id,
        //         MaDuAn = item.MaDuAns.Select(da => da.Id).FirstOrDefault(),
        //         TenDuAn = item.MaDuAns.Select(da => da.TenDuAn).FirstOrDefault(),
        //         MaDiaDiem = item.MaDuAns.Select(da => da.MaDiaDiem).FirstOrDefault()
        //     }).ToListAsync();

        //     var res = lstNhanVienDuAn.Join(_context.DiaDiems, nv => nv.MaDiaDiem, dd => dd.Id, (nv, dd) => new
        //     {
        //         Id = nv.Id,
        //         TenNV = nv.TenNV,
        //         SoDienThoai = nv.SoDienThoai,
        //         TenPB = nv.TenPB,
        //         TenDuAn = nv.TenDuAn,
        //         TenDiaDiem = dd.TenDiaDiem
        //     }).Where(item => item.TenDuAn.Contains(tenDuAn)).ToList();
        //     return Ok(res);
        // }

        [HttpGet("LayThongTinNhanVienDuAn")]
        public async Task<ActionResult> LayThongTinNhanVienDuAn([FromQuery] string tenDuAn)
        {
          var res = await _context.NhanVienDuans.Select(itemt => new
          {
              MaNV = itemt.MaNhanVien,
              TenNV = itemt.MaNhanVienNavigation.TenNv,
              TenPB = itemt.MaNhanVienNavigation.MaPbNavigation.TenPb,
              MaDA = itemt.MaDuAn,
              TenDA = itemt.MaDuAnNavigation.TenDuAn,
              DiaDiem = itemt.MaDuAnNavigation.MaDiaDiemNavigation.TenDiaDiem
          }).Where(item => item.TenDA.Contains(tenDuAn)).ToListAsync();
            
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