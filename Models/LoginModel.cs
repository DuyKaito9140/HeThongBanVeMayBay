using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class LoginModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();

        public bool checkuser(string tendangnhap, string pass)
        {
            List<USER> listuser = db.USERs.ToList();
            foreach(var item in listuser)
            {
                if (item.ACCOUNT.TenDangNhap == tendangnhap && item.ACCOUNT.Password == pass)
                {                   
                     Content.QuyenUser = item.ACCOUNT.LOAIQUYEN.TenQuyen;
                     return true;
                }
            }
            return false;
        }
        public USER GETuser(string tendangnhap, string pass)
        {
            if(tendangnhap == "" || pass == "")
            {
                return null;
            }
            USER user = db.USERs.First(a => a.ACCOUNT.TenDangNhap == tendangnhap && a.ACCOUNT.Password == pass);
            Content.HoTen = user.HoTen;
            return user;
        }
    }
}