using ThucHanhWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Repository;
namespace ThucHanhWebMVC.ViewComponents
{
    // Khai bao cau hình
    public class LoaiSpMenuViewComponent: ViewComponent
    {
        private readonly ILoaiSpRepository _loaisp;

        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaisp = loaiSpRepository;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaisp = await Task.FromResult(_loaisp.GetAllLoaiSp().OrderBy(x => x.Loai));
            return View(loaisp);
        }



    }

}
