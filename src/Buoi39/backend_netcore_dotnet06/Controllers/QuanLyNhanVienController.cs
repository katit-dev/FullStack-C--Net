using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Models.DBQuanLyNhanVien;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static backend_netcore_dotnet06.Controllers.QuanLyNhanVienController.ChiTietDuAnDTO;
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

         [HttpGet("LayThongTinNhanVienTheoDuAn/{maDuAn}")]
        public async Task<ActionResult> LayThongTinNhanVienTheoDuAn(int maDuAn)
        {
            SqlParameter paramMaDuAn = new SqlParameter("@MaDuAn", DbType.Int32) { Value = maDuAn };

            var lstNhanVienTheoDuAn = await _context.Database.SqlQueryRaw<ChiTietDuAnDTO>("EXEC sp_layDanhSachNhanVienTheoDuAn @MaDuAn", paramMaDuAn).ToListAsync();
            foreach(var duAn in lstNhanVienTheoDuAn)
            {
                duAn.ConvertJsonNhanVienDuAn();
            }
            return Ok(lstNhanVienTheoDuAn);
        }

        [HttpGet("LayDanhSachNhanVienTheoDuAnLinQ/{maDuAn}")]
        [HttpGet("LayDanhSachNhanVienTheoDuAnLinQ/{maDuAn}")]
        public async Task<ActionResult> LayDanhSachNhanVienTheoDuAnLinQ(int maDuAn)
        {
            var lstNhanVienTheoDuAn = await _context.NhanVienDuans.Where(nvda => nvda.MaDuAn == maDuAn)
                .Select(nvda => new TTNhanVienDuAnDTO
                {
                    MaNhanVien = nvda.MaNhanVien,
                    TenNV = nvda.MaNhanVienNavigation.TenNv,
                    NgaySinh = nvda.MaNhanVienNavigation.NgaySinh.ToString("dd/MM/yyyy"),
                    SoDienThoai = nvda.MaNhanVienNavigation.SoDienThoai
                }).ToListAsync();
            return Ok(lstNhanVienTheoDuAn);
        }


        //Định nghĩa lấy danh sách dự án của từng nhân viên tham gia (tham số mã nhân viên)

        // [HttpPost("ThemNhanVienNhanh")]
        // public async Task<ActionResult> ThemNhanVienNhanh([FromBody] ThemNhanVienNhanhDTO model)
        // {
        //     InsertDynamicStoreProcedure<ThemNhanVienNhanhDTO>(model);
        //     var res = await _context.NhanViens.Select(nv => new
        //     {
        //         MaNV = nv.Id,
        //         TenNV = nv.TenNv,
        //         SoDT = nv.SoDienThoai
        //     }).ToListAsync();
        //     return Ok(res);


        // [HttpPost("ThemNhanhDiaDiem")]
        // public async Task<ActionResult> ThemNhanhDiaDiem([FromBody] ThemNhanhDiaDiemDTO model)
        // {
        //      InsertDynamicStoreProcedure<ThemNhanhDiaDiemDTO>(model);
        
        //     return Ok(await _context.DiaDiems.ToListAsync());


        // }

        // }
        
        // private List<T> InsertDynamicStoreProcedure<T>(T model)
        // {
        //       /*
        //         @TableName: NhanVien
        //         @DanhSachTenCot: TenNV, SoDienThoai, MaPB
        //         @DanhSachGiaTri: ['Nguyễn văn tèo','09090909',2]
        //     */
        //     //Lấy table name
        //     string tableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(T).Name;
        //     //Lấy tên cột động
        //     PropertyInfo[] danhSachCot = typeof(T).GetProperties();
        //     string danhSachTenCot = $@"{string.Join(", ", danhSachCot.Select(cot => cot.Name))}";
        //     //Lấy giá trị động
        //     string danhSachGiaTri = $"[{string.Join(", ", danhSachCot.Select(cot => $"\"{cot.GetValue(model)}\""))}]"; //N'["Nguyễn Văn Tèo", "09090909", "2"]'

        //     Console.WriteLine($@"danh sach gia tri: {danhSachGiaTri}");
        //     Console.WriteLine($@"danh sach ten cot: {danhSachTenCot}");


        //     SqlParameter paramTableName = new SqlParameter("@TableName", DbType.String) { Value = tableName };
        //     SqlParameter paramDanhSachTenCot = new SqlParameter("@DanhSachTenCot", DbType.String) { Value = danhSachTenCot };
        //     SqlParameter paramDanhSachGiaTri = new SqlParameter("@DanhSachGiaTri", DbType.String) { Value = danhSachGiaTri };
        //     var ketQua =  _context.Database.SqlQueryRaw<int>("EXEC InsertDynamicData_JSON @TableName, @DanhSachTenCot, @DanhSachGiaTri", paramTableName, paramDanhSachTenCot, paramDanhSachGiaTri).ToListAsync();
        //     var res = _context.Set<T>().ToList();
        //     return res;
        // }


        // private void InsertDynamicStoreProcedure<T>(T model) where T : class
        // {
        //      /*
        //         @TableName: NhanVien
        //         @DanhSachTenCot: TenNV, SoDienThoai, MaPB
        //         @DanhSachGiaTri: ['Nguyễn văn tèo','09090909',2]
        //     */
        //     //Lấy table name
        //     string tableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(T).Name;
        //     //Lấy tên cột động
        //     PropertyInfo[] danhSachCot = typeof(T).GetProperties();
        //     string danhSachTenCot = $@"{string.Join(", ", danhSachCot.Select(cot => cot.Name))}";
        //     //Lấy giá trị động
        //     string danhSachGiaTri = $"[{string.Join(", ", danhSachCot.Select(cot => $"\"{cot.GetValue(model)}\""))}]"; //N'["Nguyễn Văn Tèo", "09090909", "2"]'

        //     Console.WriteLine($@"danh sach gia tri: {danhSachGiaTri}");
        //     Console.WriteLine($@"danh sach ten cot: {danhSachTenCot}");


        //     SqlParameter paramTableName = new SqlParameter("@TableName", DbType.String) { Value = tableName };
        //     SqlParameter paramDanhSachTenCot = new SqlParameter("@DanhSachTenCot", DbType.String) { Value = danhSachTenCot };
        //     SqlParameter paramDanhSachGiaTri = new SqlParameter("@DanhSachGiaTri", DbType.String) { Value = danhSachGiaTri };
        //     var ketQua =  _context.Database.SqlQueryRaw<int>("EXEC InsertDynamicData_JSON @TableName, @DanhSachTenCot, @DanhSachGiaTri", paramTableName, paramDanhSachTenCot, paramDanhSachGiaTri).ToListAsync();
        // }


        //Tạo DTO để trả về dữ liệu theo yêu cầu
        public class NhanVienPhongBanDTO
        {
            public int MaNV { get; set; }
            public string TenNV { get; set; }
            public string TenPB { get; set; }
        }

        public class NhanVienDuanDTO
        {
            public int MaNV { get; set; }
            public string TenNV { get; set; }
            public string TenPB { get; set; }
            public string TenDuAn { get; set; }
            public string DiaDiem { get; set; }
        }

       public class ChiTietDuAnDTO
    {
        public int MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public int SoNhanVien { get; set; }
        public string? DanhSachNhanVien { get; set; }
        public List<TTNhanVienDuAnDTO>? DanhSachNhanVienChiTiet { get; set; } =  new List<TTNhanVienDuAnDTO>();

        public void ConvertJsonNhanVienDuAn (){
            if(!string.IsNullOrEmpty(DanhSachNhanVien))
            {
                DanhSachNhanVienChiTiet = JsonSerializer.Deserialize<List<TTNhanVienDuAnDTO>>(DanhSachNhanVien);
            }
        }

        public class TTNhanVienDuAnDTO
        {
            public int MaNhanVien { get; set; }
            public string TenNV { get; set; }
            public string NgaySinh { get; set; }
            public string SoDienThoai { get; set; }
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
}