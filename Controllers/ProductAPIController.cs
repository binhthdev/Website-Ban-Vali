using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Models;
using ThucHanhWebMVC.Models.Product;

namespace ThucHanhWebMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QLBanVaLiContext db = new QLBanVaLiContext();

        [HttpGet]
        //public IEnumerable<TDanhMucSp> GetAllProduct()
        //{

        //    return db.TDanhMucSps.ToList(); 
        //}
        // Hien thi san pham theo loai bang web Api va Ajax
        public IEnumerable<Product> GetAllProduct()
        {
            var products = (from p in db.TDanhMucSps
                            select new Product
                            {
                                MaSp = p.MaSp,
                                TenSp = p.TenSp,
                                MaLoai = p.MaLoai,
                                AnhDaiDien = p.AnhDaiDien,
                                GiaNhoNhat = p.GiaNhoNhat,
                            }).ToList();
            return products;
        }
        [HttpGet ("maloai")]
        public IEnumerable<Product> GetProductByCategory(string maLoai)
        {
            var products = (from p in db.TDanhMucSps
                            where p.MaLoai == maLoai
                            select new Product 
                            {
               
                                MaSp = p.MaSp,
                                TenSp = p.TenSp,
                                MaLoai = p.MaLoai,
                                AnhDaiDien = p.AnhDaiDien,
                                GiaNhoNhat = p.GiaNhoNhat,
                            }).ToList();
            return products;
        }

    }
}
