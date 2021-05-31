using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class PartnerTicketsController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        PartnerTicketsModel vmbm = new PartnerTicketsModel(); 
        public ActionResult Index(int? page, string mysearch)
        {
            if (page == null) page = 1;
            var links = new List<VEMAYBAY>();
            if (!String.IsNullOrEmpty(mysearch))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(m => (m.CHUYENBAY.MAYBAY.HANGMAYBAY.TenHang.Contains(mysearch)
                         || m.CHUYENBAY.NoiDi.Contains(mysearch) || m.CHUYENBAY.NoiDen.Contains(mysearch) || m.SoKgHanhLy.ToString().Contains(mysearch) || m.GiaVe.ToString().Contains(mysearch)
                         || m.CHUYENBAY.GioBay.Contains(mysearch) || m.CHUYENBAY.GioDen.Contains(mysearch) || m.TrangThai.Contains(mysearch)
                         || m.CHUYENBAY.MAYBAY.TenMayBay.Contains(mysearch) || m.LOAIVE.TenLoaiVe.Contains(mysearch)) && m.CHUYENBAY.MAYBAY.HANGMAYBAY.TenHang.Contains(HeThongQuanLyDatVeMayBay.Models.Content.TenHang)).ToList();
            }
            else
            {
                links = (from l in db.VEMAYBAYs
                             select l).Where(m => m.CHUYENBAY.MAYBAY.HANGMAYBAY.TenHang.Contains(HeThongQuanLyDatVeMayBay.Models.Content.TenHang)).OrderBy(x => x.idVe).ToList();
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
        public ActionResult Create(VEMAYBAY v)
        {
            vmbm.them_vemaybay(v);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            return View(vmbm.layOnevemaybay(id));
        }
        [HttpPost]
        public ActionResult Edit(VEMAYBAY v)
        {
            vmbm.sua_vemaybay(v);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            vmbm.xoa_vemaybay(id);
            return RedirectToAction("Index");
        }
    }
}