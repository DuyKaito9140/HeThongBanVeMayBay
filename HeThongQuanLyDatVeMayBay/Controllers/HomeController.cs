﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class HomeController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        LoginModel lg = new LoginModel();
        SigninModel sg = new SigninModel();
        EditInfomation ei = new EditInfomation();
        PromotionModel pr = new PromotionModel();
        public ActionResult Index()
        {            
            return View(lg.GETuser(HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap, HeThongQuanLyDatVeMayBay.Models.Content.Password));
        }
        public ActionResult IndexPartner()
        {
            if (HeThongQuanLyDatVeMayBay.Models.Content.QuyenUser == "Admin")
            {
                return View(lg.GETuser(HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap, HeThongQuanLyDatVeMayBay.Models.Content.Password));
            }
            else
            {
                return View(lg.HangAccount(HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap, HeThongQuanLyDatVeMayBay.Models.Content.Password));
            }
        }
        public ActionResult Logout()
        {
            HeThongQuanLyDatVeMayBay.Models.Content.QuyenUser = "";
            HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap = "";
            HeThongQuanLyDatVeMayBay.Models.Content.Password = "";
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }        
        [HttpPost]
        public ActionResult Login(ACCOUNT ac)
        {
            if (lg.checkuser(ac.TenDangNhap, ac.Password))
            {
                lg.GETuser(ac.TenDangNhap, ac.Password);
                if (HeThongQuanLyDatVeMayBay.Models.Content.QuyenUser == "Hãng")
                {
                    lg.HangAccount(ac.TenDangNhap, ac.Password);
                    HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap = ac.TenDangNhap;
                    HeThongQuanLyDatVeMayBay.Models.Content.Password = ac.Password;
                    return RedirectToAction("IndexPartner");
                }
                else if (HeThongQuanLyDatVeMayBay.Models.Content.QuyenUser == "Admin")
                {
                    HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap = ac.TenDangNhap;
                    HeThongQuanLyDatVeMayBay.Models.Content.Password = ac.Password;
                    return RedirectToAction("IndexPartner");
                }
                else if (HeThongQuanLyDatVeMayBay.Models.Content.QuyenUser == "Thuky")
                {
                    HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap = ac.TenDangNhap;
                    HeThongQuanLyDatVeMayBay.Models.Content.Password = ac.Password;
                    return RedirectToAction("IndexPartner");
                }
                else
                {
                    HeThongQuanLyDatVeMayBay.Models.Content.TenDangNhap = ac.TenDangNhap;
                    HeThongQuanLyDatVeMayBay.Models.Content.Password = ac.Password;
                    return RedirectToAction("Index");
                }
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
        public ActionResult EditInfo(string id) 
        {
            return View(ei.Queryuser(id));
        }
        [HttpPost]
        public ActionResult EditInfo(USER us) 
        {
            ei.edit_info(us);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult booknow(string chuyenbaynoidi, string chuyenbaynoiden, string chuyenbayngaybay, string chuyenbaygiobay, string chuyenbayloaive)
        {
            return RedirectToAction("Booknow/Index");
        }
        public ActionResult History() 
        {
            string idu = HeThongQuanLyDatVeMayBay.Models.Content.idUser;
            var listvebooked = db.DATVEs.Where(m => m.idUser == idu).ToList();
            ViewBag.TicketBooked = listvebooked;
            return View(ViewBag);
        }
        public ActionResult Promotion() 
        {            
            return View(pr.Listkhuyenmai());
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact() 
        {
            return View();
        }
    }
}