using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class PartnerPlanesModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<MAYBAY> ListMayBay()
        {
            return db.MAYBAYs.ToList();
        }

        public MAYBAY layOnemaybay(string id)
        {
            return db.MAYBAYs.First(m => m.idMayBay == id);
        }

        public void them_maybay(MAYBAY mb)
        {
            string idmaybay = Content.RandomString(8);
            mb.idMayBay = idmaybay;
            string[] idhang = mb.idHang.Split(' ');
            mb.idHang = idhang[0];
            db.MAYBAYs.Add(mb);
            db.SaveChanges();
        }

        public void sua_maybay(MAYBAY mb)
        {
            string[] idhang = mb.idHang.Split(' ');

            MAYBAY x = layOnemaybay(mb.idMayBay);
            x.TenMayBay = mb.TenMayBay;
            x.idHang = idhang[0];
            x.SoLuongKhach = mb.SoLuongKhach;
            db.SaveChanges();
        }

        public void xoa_maybay(string id)
        {
            MAYBAY x = layOnemaybay(id);
            db.MAYBAYs.Remove(x);
            db.SaveChanges();
        }
    }
}