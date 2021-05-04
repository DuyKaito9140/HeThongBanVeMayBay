using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class PartnerFlightsController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        PartnerFlightsModel cbm = new PartnerFlightsModel(); 
        public ActionResult Index(int? page, string mysearch)
        {
            if (page == null) page = 1;
            var links = new List<CHUYENBAY>();
            if (!String.IsNullOrEmpty(mysearch))
            {
                links = (from l in db.CHUYENBAYs
                         select l).OrderBy(x => x.idChuyenBay).Where(m => m.MAYBAY.HANGMAYBAY.TenHang.Contains(mysearch)
                         || m.NoiDi.Contains(mysearch) || m.NoiDen.Contains(mysearch)
                         || m.GioBay.Contains(mysearch) || m.GioDen.Contains(mysearch)).ToList();
            }
            else
            {
                links = (from l in db.CHUYENBAYs
                         select l).OrderBy(x => x.idChuyenBay).ToList();
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
        public ActionResult Create(CHUYENBAY cb)
        {
            cbm.them_chuyenbay(cb);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            return View(cbm.layOnechuyenbay(id));
        }
        [HttpPost]
        public ActionResult Edit(CHUYENBAY cb)
        {
            cbm.sua_chuyenbay(cb);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            cbm.xoa_chuyenbay(id);
            return RedirectToAction("Index");
        }        
    }
}