using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class BooknowModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();

        public IEnumerable<VEMAYBAY> ListVe()
        {
            return db.VEMAYBAYs.ToList();
        }
        public VEMAYBAY NhanOneVBM(string idVe)
        {
            return db.VEMAYBAYs.First(m => m.idVe == idVe);
        }
        public void dat_ve_nologin(DATVEKOLOGIN cb) 
        {
            DateTime date = DateTime.Now;
            string iduser = Content.RandomString(8);
            cb.idUser2 = iduser;
            cb.NgayDat2 = date;
            VEMAYBAY vedangdat = db.VEMAYBAYs.First(m => m.idVe == cb.idVe);
            vedangdat.TrangThai = "Hết vé";
            db.SaveChanges();
            db.DATVEKOLOGINs.Add(cb);
            db.SaveChanges();

        }
    }
}