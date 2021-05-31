using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class PartnerPlanesController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        PartnerPlanesModel mbm = new PartnerPlanesModel();
        public ActionResult Index(int? page, string mysearch)
        {
            if (page == null) page = 1;
            var links = new List<MAYBAY>();
            if (!String.IsNullOrEmpty(mysearch))
            {
                links = (from l in db.MAYBAYs
                             select l).OrderBy(x => x.idMayBay).Where(m=> (m.TenMayBay.Contains(mysearch) 
                             || m.HANGMAYBAY.TenHang.Contains(mysearch) || m.SoLuongKhach.ToString().Contains(mysearch)) && m.HANGMAYBAY.TenHang.Contains(HeThongQuanLyDatVeMayBay.Models.Content.TenHang)).ToList();
            }
            else
            {
                links = (from l in db.MAYBAYs
                             select l).Where(m=> m.HANGMAYBAY.TenHang.Contains(HeThongQuanLyDatVeMayBay.Models.Content.TenHang)).OrderBy(x => x.idMayBay).ToList();
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
        public ActionResult Create(MAYBAY mb)
        {
            mbm.them_maybay(mb);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            return View(mbm.layOnemaybay(id));
        }
        [HttpPost]
        public ActionResult Edit(MAYBAY mb)
        {
            mbm.sua_maybay(mb);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            mbm.xoa_maybay(id);
            return RedirectToAction("Index");
        }
    }
}