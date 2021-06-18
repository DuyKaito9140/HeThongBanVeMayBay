using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class HomeModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<DATVE> Listdatve()
        {
            return db.DATVEs.ToList();
        }

        public DATVE layOnedatve(string id)
        {
            return db.DATVEs.First(m => m.idDatVe == id);
        }
        public VEMAYBAY layOneVeMayBay(string idv)
        {
            return db.VEMAYBAYs.First(m => m.idVe == idv);
        }
        public void Return_ticket(string iddv)
        {
            DATVE dv = layOnedatve(iddv);
            VEMAYBAY v = layOneVeMayBay(dv.idVe);
            v.TrangThai = "Còn vé";
            db.DATVEs.Remove(dv);
            db.SaveChanges();
        }
    }
}