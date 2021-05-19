using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class PromotionModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<KHUYENMAI> ListMayBay()
        {
            return db.KHUYENMAIs.ToList();
        }

        public KHUYENMAI layOnekhuyenmai(string id)
        {
            return db.KHUYENMAIs.First(m => m.idKhuyenMai == id);
        }

        public void them_khuyenmai(KHUYENMAI km)
        {
            string idkm = Content.RandomString(8);
            km.idKhuyenMai = idkm;
            db.KHUYENMAIs.Add(km);
            db.SaveChanges();
        }

        public void sua_khuyenmai(KHUYENMAI km)
        {
            KHUYENMAI x = layOnekhuyenmai(km.idKhuyenMai);
            x.MaKhuyenMai = km.MaKhuyenMai;
            x.NgayBatDauKM = km.NgayBatDauKM;
            x.NgayKetThucKM = km.NgayKetThucKM;
            x.GiaTriKM = km.GiaTriKM;
            x.ChiTietMoTaKM = km.ChiTietMoTaKM;
            db.SaveChanges();
        }

        public void xoa_khuyenmai(string id)
        {
            KHUYENMAI x = layOnekhuyenmai(id);
            db.KHUYENMAIs.Remove(x);
            db.SaveChanges();
        }
    }
}