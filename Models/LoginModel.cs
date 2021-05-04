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
            Content.QuyenUser = user.ACCOUNT.LOAIQUYEN.TenQuyen;
            if (Content.QuyenUser == "Hãng")
            {
                return null;
            }
            else
            {
                Content.HoTen = user.HoTen;
                Content.Ngaysinh = user.NgaySinh.ToString();
                Content.Gioitinh = user.GioiTinh;
                Content.cmnd = user.Cmnd;
                Content.sdt = user.Sdt;
                Content.email = user.Email;
                Content.Diachi = user.DiaChi;
                Content.Quoctich = user.QuocTich;
                return user;
            }            
        }

        public HANGMAYBAY HangAccount(string tendangnhap, string pass)
        {
            if (tendangnhap == "" || pass == "")
            {
                return null;
            }
            HANGMAYBAY hang = db.HANGMAYBAYs.First(a => a.ACCOUNT.TenDangNhap == tendangnhap && a.ACCOUNT.Password == pass);
            Content.QuyenUser = hang.ACCOUNT.LOAIQUYEN.TenQuyen;
            Content.TenHang = hang.TenHang;
            Content.SdtHang = hang.SdtHang;
            Content.EmailHang = hang.EmailHang;
            return hang;
        }
    }
}