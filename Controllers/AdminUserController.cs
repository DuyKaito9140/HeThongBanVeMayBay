using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class AdminUserController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        AdminUser amm = new AdminUser();
        public ActionResult Index(int? page, string mysearch)
        {
            if (page == null) page = 1;
            var links = new List<USER>();
            if (!String.IsNullOrEmpty(mysearch))
            {
                links = (from l in db.USERs
                         select l).OrderBy(x => x.idUser).Where(m => m.HoTen.Contains(mysearch)
                         || m.QuocTich.Contains(mysearch) || m.ACCOUNT.LOAIQUYEN.TenQuyen.Contains(mysearch) || m.GioiTinh.ToString().Contains(mysearch)).ToList();
            }
            else
            {
                links = (from l in db.USERs
                         select l).OrderBy(x => x.idUser).ToList();
            }
            int pageSize = 8;

            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(string mysearch)
        {
            mysearch = "";
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(USER us, ACCOUNT ac)
        {
            amm.them_user(us, ac);
            return RedirectToAction("Index");
        }
        public ActionResult Role(string id)
        {
            return View(amm.layOneuser(id));
        }
        [HttpPost]
        public ActionResult Role(USER us, ACCOUNT ac, HANGMAYBAY ha)
        {
            amm.role_user(us, ac);
            if(HeThongQuanLyDatVeMayBay.Models.Content.idquyen == "q002")
            {
                amm.them_hang(us, ha);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            amm.xoa_user(id);
            return RedirectToAction("Index");
        }
    }
}