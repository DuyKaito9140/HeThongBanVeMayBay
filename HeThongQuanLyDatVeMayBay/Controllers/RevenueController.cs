using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class RevenueController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        RevenueModel rv = new RevenueModel();
        public ActionResult Index()
        {
            return View(rv.Listdoanhthu());
        }

        [HttpPost]
        public ActionResult getrevenue(string ThangTK, string NamTK)
        {
            rv.TinhDoanhThu(ThangTK, NamTK);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string iddt) 
        {
            rv.xoadoanhthu(iddt);
            return RedirectToAction("Index");
        }
    }
}