using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class RevenuePartnerController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        RevenuePartnerModel rp = new RevenuePartnerModel();
        public ActionResult Index()
        {
            return View(rp.Listdoanhthu());
        }

        [HttpPost]
        public ActionResult getrevenuepartner(string ThangTK, string NamTK) 
        {
            rp.TinhDoanhThupartner(ThangTK, NamTK);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string iddt)
        {
            rp.xoadoanhthu(iddt);
            return RedirectToAction("Index");
        }
    }
}