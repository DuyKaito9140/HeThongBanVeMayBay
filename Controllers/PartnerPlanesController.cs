using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class PartnerPlanesController : Controller
    {
        PartnerPlanesModel mbm = new PartnerPlanesModel();
        public ActionResult Index()
        {
            return View(mbm.ListMayBay());
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