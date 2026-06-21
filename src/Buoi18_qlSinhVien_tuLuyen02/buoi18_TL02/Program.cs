public class Progra
{
    public static void Main(string[] args)
    {
        TrungTam trungTamA = new TrungTam();
        QuanLyTrungTam quanLy = new QuanLyTrungTam(trungTamA);
        quanLy.ShowMenu();
    }
}