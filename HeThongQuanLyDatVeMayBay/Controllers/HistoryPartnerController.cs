using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class HistoryPartnerController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        HistoryPartnerModel hp = new HistoryPartnerModel();
        public ActionResult Index()
        {
            return View(hp.Listdatve());
        }
    }
}