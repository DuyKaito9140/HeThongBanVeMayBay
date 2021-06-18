using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongQuanLyDatVeMayBay.Models;

namespace HeThongQuanLyDatVeMayBay.Controllers
{
    public class ManagmentTicketController : Controller
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        ManagmentTicketModel mt = new ManagmentTicketModel();
        public ActionResult Index()
        {
            var listve = db.VEMAYBAYs.ToList();
            int vebamboo = 0; int vebambooBooked = 0; int veNobambooBooked = 0;
            int vevn = 0; int vevnBooked = 0; int veNovnBooked = 0;
            int vevietj = 0; int vevietjBooked = 0; int veNovietjBooked = 0;
            foreach (var item in listve)
            {
                if(item.CHUYENBAY.MAYBAY.HANGMAYBAY.TenHang == "BamBoo Airways")
                {
                    vebamboo++;
                    if(item.TrangThai == "Còn vé")
                    {
                        veNobambooBooked++;
                    }
                    else
                    {
                        vebambooBooked++;
                    }
                }
                else if (item.CHUYENBAY.MAYBAY.HANGMAYBAY.TenHang == "VietNam Airlines")
                {
                    vevn++;
                    if (item.TrangThai == "Còn vé")
                    {
                        veNovnBooked++;
                    }
                    else
                    {
                        vevnBooked++;
                    }
                }
                else if (item.CHUYENBAY.MAYBAY.HANGMAYBAY.TenHang == "VietJet Air")
                {
                    vevietj++;
                    if (item.TrangThai == "Còn vé")
                    {
                        veNovietjBooked++;
                    }
                    else
                    {
                        vevietjBooked++;
                    }
                }
            }
            //bamboo
            ViewBag.SumVeBamBoo = vebamboo;
            ViewBag.VeNoBamBooBooked = veNobambooBooked;
            ViewBag.VeBamBooBooked = vebambooBooked;
            //VNAirliine
            ViewBag.SumVeVN = vevn;
            ViewBag.VeNoVNBooked = veNovnBooked;
            ViewBag.VeVNBooked = vevnBooked;
            //Vietject
            ViewBag.SumVeVietJ = vevietj;
            ViewBag.VeNoVietJBooked = veNovietjBooked;
            ViewBag.VeVietJBooked = vevietjBooked;
            return View(ViewBag);
        }
    }
}