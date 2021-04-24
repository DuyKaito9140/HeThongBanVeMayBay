using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class BooknowController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        BooknowModel bn = new BooknowModel();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe);
            int pageSize = 9;

            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }
    }
}