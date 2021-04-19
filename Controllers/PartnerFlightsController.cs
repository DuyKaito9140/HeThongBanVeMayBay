using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class PartnerFlightsController : Controller
    {
        PartnerFlightsModel cbm = new PartnerFlightsModel(); 
        public ActionResult Index()
        {
            return View(cbm.Listchuyenbay());
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