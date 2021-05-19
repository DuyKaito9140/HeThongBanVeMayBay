﻿using System;
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
        public ActionResult Index(int? page, string chuyenbaynoidi, string chuyenbaynoiden, string chuyenbayngaybay, string chuyenbaygiobay, string chuyenbayloaive)
        {
            if (page == null) page = 1;
            var links = new List<VEMAYBAY>();
            if (!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && String.IsNullOrEmpty(chuyenbayngaybay) && String.IsNullOrEmpty(chuyenbaygiobay) && String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v=>v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi) && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden)).ToList();
            }
            else if(!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && !String.IsNullOrEmpty(chuyenbayngaybay) && String.IsNullOrEmpty(chuyenbaygiobay) && String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v => v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi) 
                         && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden) && v.CHUYENBAY.NgayBay.ToString().Contains(chuyenbayngaybay)).ToList();
            }
            else if (!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && String.IsNullOrEmpty(chuyenbayngaybay) && !String.IsNullOrEmpty(chuyenbaygiobay) && String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v => v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi)
                         && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden) && v.CHUYENBAY.GioBay.Contains(chuyenbaygiobay)).ToList();
            }
            else if (!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && String.IsNullOrEmpty(chuyenbayngaybay) && String.IsNullOrEmpty(chuyenbaygiobay) && !String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v => v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi)
                         && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden) && v.LOAIVE.TenLoaiVe.Contains(chuyenbayloaive)).ToList();
            }
            else if (!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && !String.IsNullOrEmpty(chuyenbayngaybay) && !String.IsNullOrEmpty(chuyenbaygiobay) && String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v => v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi)
                         && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden) && v.CHUYENBAY.NgayBay.ToString().Contains(chuyenbayngaybay) 
                         && v.CHUYENBAY.GioBay.Contains(chuyenbaygiobay)).ToList();
            }
            else if (!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && !String.IsNullOrEmpty(chuyenbayngaybay) && String.IsNullOrEmpty(chuyenbaygiobay) && !String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v => v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi)
                         && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden) && v.CHUYENBAY.NgayBay.ToString().Contains(chuyenbayngaybay)
                         && v.LOAIVE.TenLoaiVe.Contains(chuyenbayloaive)).ToList();
            }
            else if (!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && String.IsNullOrEmpty(chuyenbayngaybay) && !String.IsNullOrEmpty(chuyenbaygiobay) && !String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v => v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi)
                         && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden) && v.CHUYENBAY.GioBay.Contains(chuyenbaygiobay)
                         && v.LOAIVE.TenLoaiVe.Contains(chuyenbayloaive)).ToList();
            }
            else if (!String.IsNullOrEmpty(chuyenbaynoidi) && !String.IsNullOrEmpty(chuyenbaynoiden) && !String.IsNullOrEmpty(chuyenbayngaybay) && !String.IsNullOrEmpty(chuyenbaygiobay) && !String.IsNullOrEmpty(chuyenbayloaive))
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).Where(v => v.CHUYENBAY.NoiDi.Contains(chuyenbaynoidi)                   
                         && v.CHUYENBAY.NoiDen.Contains(chuyenbaynoiden) && v.CHUYENBAY.GioBay.Contains(chuyenbaygiobay)
                         && v.CHUYENBAY.NgayBay.ToString().Contains(chuyenbayngaybay)
                         && v.LOAIVE.TenLoaiVe.Contains(chuyenbayloaive)).ToList();
            }
            else
            {
                links = (from l in db.VEMAYBAYs
                         select l).OrderBy(x => x.idVe).ToList();
            }
            int pageSize = 8;

            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult booking(string idVe)
        {
            return View(bn.NhanOneVBM(idVe));
        }
        [HttpPost]
        public ActionResult booking(VEMAYBAY v) 
        {
            return RedirectToAction("Booknow/booking");
        }
    }
}