using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThucHanhWebMVC.Models;
using ThucHanhWebMVC.Models.Authentication;
using ThucHanhWebMVC.ViewModel;
using X.PagedList;

namespace ThucHanhWebMVC.Controllers
{
    public class HomeController : Controller
    {
        QLBanVaLiContext db = new QLBanVaLiContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       // [Authentication]
        // Thêm các sản phẩm và phân trang
        public IActionResult Index(int? page)
        {
            int pagesize = 8;
            int pageNumber= page == null || page< 0 ? 1 : page.Value;
            var listsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsanpham, pageNumber, pagesize);
            return View(lst);
        }
       // [Authentication]
        // Hiển thị sản phẩm theo loại
        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            // List<TDanhMucSp> lstsanpham = db.TDanhMucSps.Where
            //   (x => x.MaLoai == maloai).OrderBy(x => x.TenSp).ToList();
            int pagesize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsanpham = db.TDanhMucSps.AsNoTracking().Where(x=>x.MaLoai==maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsanpham, pageNumber, pagesize);
            ViewBag.maloai = maloai;
            return View(lst);
        }
      //  [Authentication]
        public IActionResult ProductDetail(String maSp)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewmodel { 
                dangMucSp = sanPham ,
                AnhSps = anhSanPham
            };
          

            return View(homeProductDetailViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
