using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Models;

namespace ThucHanhWebMVC.Areas.Admin.Controllers
{


    public class AccessController : Controller
    {
        QLBanVaLiContext db = new QLBanVaLiContext();
        [HttpGet]
        public IActionResult Login()
        {
            //neu chua dang nhap
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            //Neu da dang nhap 
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var uSer = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (uSer != null)
                {
                    HttpContext.Session.SetString("UserName", uSer.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
            return View();
        }

        
    }
}
