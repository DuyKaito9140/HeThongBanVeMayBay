using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class HomeController : Controller
    {
        LoginModel lg = new LoginModel();
        SigninModel sg = new SigninModel();
        public ActionResult Index()
        {
            return View(lg.GETuser(HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap, HeThongQuanLyDatVeMayBay.Models.Content.Password));
        }
        public ActionResult Logout() 
        {
            HeThongQuanLyDatVeMayBay.Models.Content.QuyenUser = "";
            return RedirectToAction("Index");
        }
        public ActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ACCOUNT ac) 
        {
            if(lg.checkuser(ac.TenDangNhap, ac.Password))
            {
                lg.GETuser(ac.TenDangNhap, ac.Password);
                HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap = ac.TenDangNhap;
                HeThongQuanLyDatVeMayBay.Models.Content.Password = ac.Password;
                return RedirectToAction("Index");
            }
            else
            {                
                return RedirectToAction("Login");                
            }
        }
        public ActionResult Signin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(ACCOUNT ac, USER us)
        {
            if (sg.checksignin(ac.TenDangNhap))
            {
                sg.add_signin_user(ac, us);
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Signin");
            }
        }
        [HttpPost]
        public ActionResult booknow()
        {
             return RedirectToAction("Signin");
        }
    }
}