using ThucHanhWebMVC.Models;
namespace ThucHanhWebMVC.Repository
{
    // Tao interface daynamic động (1)
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);

        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(TLoaiSp loaiSp);
        TLoaiSp GetLoaiSp(string maloaisp);
        IEnumerable<TLoaiSp> GetAllLoaiSp();

    }
}
