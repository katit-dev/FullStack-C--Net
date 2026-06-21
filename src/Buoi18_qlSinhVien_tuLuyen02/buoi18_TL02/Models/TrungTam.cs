public class TrungTam
{
     public string TenCongTy { get; set; }
    public string MST { get; set; }
    public double DoanhThu { get; set; }

    private List<NguoiDung> nguoiDungs { get; set; }

    // getter setter
    public List<NguoiDung> GetNguoiDungs()
    {
        return nguoiDungs;
    }

    public void SetNguoiDungs(List<NguoiDung> nguoiDungs)
    {
        this.nguoiDungs = nguoiDungs;
    }

    public TrungTam()
    {
        nguoiDungs = new List<NguoiDung>();
        nguoiDungs.Add(new GiangVien("GV001", "Nguyen Van A", 35, "Nam", 1000));
        nguoiDungs.Add(new GiangVien("GV002", "Le Thi B", 30, "Nu", 1200));
        nguoiDungs.Add(new SinhVien("SV001", "Tran Van C", 20, "Nam"));
        nguoiDungs.Add(new SinhVien("SV002", "Pham Thi D", 22, "Nu"));
        nguoiDungs.Add(new Mentor("MT001", "Hoang Van E", 28, "Nam", 1500));    
        nguoiDungs.Add(new Mentor("MT002", "Do Thi F", 26, "Nu", 1300));

    }

    // hien thi nguoi dung theo loai
    public void HienThiNguoiDungTheoLoai<T>() where T : NguoiDung
    {
        foreach(var nguoiDung in nguoiDungs)
        {
            if(nguoiDung is T)
            {
                nguoiDung.HienThiThongTin();
            }
        }
    }

}