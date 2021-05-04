using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class AdminUser
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<USER> ListUser()
        {
            return db.USERs.ToList();
        }

        public USER layOneuser(string id)
        {
            return db.USERs.First(m => m.idUser == id);
        }
        public ACCOUNT layOneaccount(string id)
        {
            return db.ACCOUNTs.First(m => m.idAccount == id);
        }
        public void them_user(USER us, ACCOUNT ac) 
        {
            //account
            ac.idAccount = Content.RandomString(12); 
            ac.idQuyen = "q003";

            //user
            us.idUser = Content.RandomString(12);
            us.idAccount = ac.idAccount;
            db.ACCOUNTs.Add(ac);
            db.USERs.Add(us);
            db.SaveChanges();
        }
        public void them_hang(USER us , HANGMAYBAY ha)
        {
            ha.idHang = Content.RandomString(8);
            ha.idAccount = us.idAccount;
            db.HANGMAYBAYs.Add(ha);
            db.SaveChanges();
        }
        public void role_user(USER us, ACCOUNT ac) 
        {
            string[] idq = ac.idQuyen.Split(' ');              
            ACCOUNT x = layOneaccount(us.idAccount);
            x.idQuyen = idq[0];
            if (x.idQuyen == "q002")
            {
                HeThongQuanLyDatVeMayBay.Models.Content.idquyen = "q002";
            }
            db.SaveChanges();
        }

        public void xoa_user(string id)
        {
            USER x = layOneuser(id);
            db.USERs.Remove(x);
            db.SaveChanges();
        }
    }
}