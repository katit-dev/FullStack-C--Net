public class DonHang
{
    List<SanPham> sanPhams = new List<SanPham>();

    public DonHang()
    {
        List<SanPham> sanPhams = new List<SanPham>();
    }

    public void ThemSanPham(SanPham sanPham)
    {
        sanPhams.Add(sanPham);
    }

    public void HienThiDonHang()
    {
        Console.WriteLine("Danh sách sản phẩm trong đơn hàng:");
        foreach (var sanPham in sanPhams)
        {
            Console.WriteLine($"- {sanPham.TenSP}: {sanPham.Gia}");
        }
    }

    public double TinhTongTien()
    {
        // // c1:
        // double tongTien = 0;
        // foreach (var sanPham in sanPhams)
        // {
        //     tongTien += sanPham.Gia;
        // }
        // return tongTien;

        // c2: sử dụng LINQ
        return sanPhams.Sum(sp => sp.Gia);
    }
}