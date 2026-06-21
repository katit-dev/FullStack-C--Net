class SinhVien : NguoiDung
{
    public SinhVien()
    {
    }

    public SinhVien(string ma, string ten, int tuoi, string gioiTinh) : base(ma, ten, tuoi, gioiTinh)
    {
        base.Ma = ma;
        base.Ten = ten;
        base.Tuoi = tuoi;
        base.GioiTinh = gioiTinh;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
    }
    public override void NhapThongTin()
    {
        base.NhapThongTin();
    }
    
}