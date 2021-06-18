using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class HistoryAdminController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        HistoryAdminModel ha = new HistoryAdminModel();
        public ActionResult Index()
        {
            return View(ha.Listdatve());
        }
    }
}