using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class PartnerFlightsModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<CHUYENBAY> Listchuyenbay()
        {
            return db.CHUYENBAYs.ToList();
        }

        public CHUYENBAY layOnechuyenbay(string id)
        {
            return db.CHUYENBAYs.First(m => m.idChuyenBay == id);
        }

        public void them_chuyenbay(CHUYENBAY cb)
        {
            string idchuyenbay = Content.RandomString(8);
            cb.idChuyenBay = idchuyenbay;
            string[] idmb = cb.idMayBay.Split(' ');
            cb.idMayBay = idmb[0];
            db.CHUYENBAYs.Add(cb);
            db.SaveChanges();
        }

        public void sua_chuyenbay(CHUYENBAY cb)
        {
            string[] idmb = cb.idMayBay.Split(' ');

            CHUYENBAY x = layOnechuyenbay(cb.idChuyenBay);
            x.NgayBay = cb.NgayBay;
            x.GioBay = cb.GioBay;
            x.GioDen = cb.GioDen;
            x.NoiDi = cb.NoiDi;
            x.NoiDen = cb.NoiDen;
            x.idMayBay = idmb[0];
            db.SaveChanges();
        }

        public void xoa_chuyenbay(string id)
        {
            CHUYENBAY x = layOnechuyenbay(id);
            db.CHUYENBAYs.Remove(x);
            db.SaveChanges();
        }
    }
}