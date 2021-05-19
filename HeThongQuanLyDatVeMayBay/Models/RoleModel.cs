using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class RoleModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<LOAIQUYEN> Listquyen()
        {
            return db.LOAIQUYENs.ToList();
        }

        public LOAIQUYEN layOnequyen(string id)
        {
            return db.LOAIQUYENs.First(m => m.idQuyen == id);
        }

        public void them_quyen(LOAIQUYEN q)
        {
            string idq = Content.RandomString(8);
            q.idQuyen = idq;
            db.LOAIQUYENs.Add(q);
            db.SaveChanges();
        }

        public void sua_quyen(LOAIQUYEN mb)
        {
            LOAIQUYEN x = layOnequyen(mb.idQuyen);
            x.TenQuyen = mb.TenQuyen;
            db.SaveChanges();
        }

        public void xoa_quyen(string id)
        {
            LOAIQUYEN x = layOnequyen(id);
            db.LOAIQUYENs.Remove(x);
            db.SaveChanges();
        }
    }
}