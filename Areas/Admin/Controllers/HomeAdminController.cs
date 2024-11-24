using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucHanhWebMVC.Models;
using X.PagedList;


namespace ThucHanhWebMVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QLBanVaLiContext db = new QLBanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("DanhMucSanPham" +
            "")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pagesize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsanpham, pageNumber, pagesize);
            return View(lst);
        }
        [Route("ThemSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),
                "MaChatLieu","ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(),
                "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(),
                "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),
                "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(),
                "MaDt", "TenLoai");
            return View();
        }
        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(TDanhMucSp SanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(SanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(SanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {

            var SanPham = db.TDanhMucSps.Find(maSanPham);
            if(SanPham == null)
            {
                return NotFound();  
            }
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),
                "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(),
                "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(),
                "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),
                "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(),
                "MaDt", "TenLoai");
            return View(SanPham);
          
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp SanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Update(SanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(SanPham);
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),
                "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(),
                "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(),
                "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),
                "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(),
                "MaDt", "TenLoai");
            return View(SanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(String maSanPham)
        {
            TempData["Message"] = "";
            var ChiTietSanPham = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
            if(ChiTietSanPham.Count > 0)
            {
                TempData["Message"] = "Khong duoc xoa san pham nay";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSanPham);
            if(anhSanPham.Any()) db.RemoveRange(anhSanPham);
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "San pham nay da duoc xoa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }

    }
}
