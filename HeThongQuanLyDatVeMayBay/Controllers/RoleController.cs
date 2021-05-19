using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;
using PagedList;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class RoleController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        RoleModel rm = new RoleModel();
        public ActionResult Index(int? page, string mysearch)
        {
            if (page == null) page = 1;
            var links = new List<LOAIQUYEN>();
            if (!String.IsNullOrEmpty(mysearch))
            {
                links = (from l in db.LOAIQUYENs
                         select l).OrderBy(x => x.idQuyen).Where(m => m.TenQuyen.Contains(mysearch)).ToList();
            }
            else
            {
                links = (from l in db.LOAIQUYENs
                         select l).OrderBy(x => x.idQuyen).ToList();
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
        public ActionResult Create(LOAIQUYEN q)
        {
            rm.them_quyen(q);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            return View(rm.layOnequyen(id));
        }
        [HttpPost]
        public ActionResult Edit(LOAIQUYEN q)
        {
            rm.sua_quyen(q);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            rm.xoa_quyen(id);
            return RedirectToAction("Index");
        }
    }
}