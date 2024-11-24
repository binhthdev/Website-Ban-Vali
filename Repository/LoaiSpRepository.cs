using ThucHanhWebMVC.Models;
namespace ThucHanhWebMVC.Repository
{
    //(2)
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QLBanVaLiContext _context;
        
        public LoaiSpRepository(QLBanVaLiContext context)
        {
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;

        }

        public TLoaiSp Delete(TLoaiSp loaiSp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(string maloaisp)
        {
            return _context.TLoaiSps.Find(maloaisp);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
