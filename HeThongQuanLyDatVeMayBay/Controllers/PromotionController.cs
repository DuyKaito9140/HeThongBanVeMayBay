using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class PromotionController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        PromotionModel promo = new PromotionModel();
        public ActionResult Index(int? page, string mysearch)
        {
            if (page == null) page = 1;
            var links = new List<KHUYENMAI>();
            if (!String.IsNullOrEmpty(mysearch))
            {
                links = (from l in db.KHUYENMAIs
                         select l).OrderBy(x => x.idKhuyenMai).Where(m => m.MaKhuyenMai.Contains(mysearch)
                         || m.NgayBatDauKM.Value.ToString().Contains(mysearch) || m.NgayKetThucKM.Value.ToString().Contains(mysearch)
                         || m.GiaTriKM.ToString().Contains(mysearch) || m.ChiTietMoTaKM.Contains(mysearch)).ToList();
            }
            else
            {
                links = (from l in db.KHUYENMAIs
                         select l).OrderBy(x => x.idKhuyenMai).ToList();
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
        public ActionResult Create(KHUYENMAI km)
        {
            promo.them_khuyenmai(km);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            return View(promo.layOnekhuyenmai(id));
        }
        [HttpPost]
        public ActionResult Edit(KHUYENMAI km)
        {
            promo.sua_khuyenmai(km);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            promo.xoa_khuyenmai(id);
            return RedirectToAction("Index");
        }
    }
}