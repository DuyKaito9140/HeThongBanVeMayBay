using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class HistoryPartnerModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<DATVE> Listdatve()
        {
            return db.DATVEs.OrderByDescending(m => m.NgayDatVe).Where(m=>m.VEMAYBAY.CHUYENBAY.MAYBAY.HANGMAYBAY.TenHang == Content.TenHang).ToList();
        }
        public DATVE layOnedatve(string id)
        {
            return db.DATVEs.First(m => m.idDatVe == id);
        }
    }
}