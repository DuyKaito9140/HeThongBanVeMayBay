using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class EditInfomation
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();

        public USER Queryuser(string id)
        {
            return db.USERs.First(m => m.idUser == id);
        }
        public void edit_info(USER us)
        {
            USER x = Queryuser(us.idUser);
            x.HoTen = us.HoTen;
            x.NgaySinh = us.NgaySinh;
            x.GioiTinh = us.GioiTinh;
            x.DiaChi = us.DiaChi;
            x.Email = us.Email;
            x.Sdt = us.Sdt;
            x.Cmnd = us.Cmnd;
            x.QuocTich = us.QuocTich;
            db.SaveChanges();
        }
    }
}