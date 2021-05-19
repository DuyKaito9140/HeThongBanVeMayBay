using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class SigninModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();

        public bool checksignin(string tendangnhap)
        {
            List<USER> listuser = db.USERs.ToList();
            foreach (var item in listuser)
            {
                if (item.ACCOUNT.TenDangNhap == tendangnhap)
                {
                    return false;
                }
            }
            return true;
        }
        public void add_signin_user(ACCOUNT ac, USER us) 
        {
            //Account
            string idyaccount = Content.RandomString(12); 
            ac.idAccount = idyaccount;
            ac.idQuyen = "q003";
            //User
            string idyuser = Content.RandomString(12);
            us.idUser = idyuser;
            us.idAccount = ac.idAccount;
            //Add Database
            db.ACCOUNTs.Add(ac);
            db.USERs.Add(us);
            db.SaveChanges();
        }
    }
}