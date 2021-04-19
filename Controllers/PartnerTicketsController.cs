using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class PartnerTicketsController : Controller
    {
        PartnerTicketsModel vmbm = new PartnerTicketsModel(); 
        public ActionResult Index()
        {
            return View(vmbm.Listvemaybay());
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