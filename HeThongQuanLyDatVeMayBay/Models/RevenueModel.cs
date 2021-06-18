using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class RevenueModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<DOANHTHU> Listdoanhthu() 
        {
            return db.DOANHTHUs.ToList();
        }
        public DOANHTHU layOnedt(string id)
        {
            return db.DOANHTHUs.First(m => m.idDoanhThu == id);
        }
        public void TinhDoanhThu(string ThangTK, string NamTK)
        {
            int sohd = 0;
            int sum = 0;
            var listdv = db.DATVEs.ToList();
            var listnologin = db.DATVEKOLOGINs.ToList();

            foreach (var dv in listdv)
            {
                if(ThangTK == dv.NgayDatVe.Value.Month.ToString() && NamTK == dv.NgayDatVe.Value.Year.ToString())
                {
                    sohd++;
                    var giaend = "";
                    var giacodinh = dv.TienThanhToan.Split('.');
                    if (giacodinh.Length == 3)
                    {
                        giaend = giacodinh[0] + giacodinh[1] + giacodinh[2];
                    }
                    else if (giacodinh.Length == 2)
                    {
                        giaend = giacodinh[0] + giacodinh[1];
                    }
                    else if (giacodinh.Length == 4)
                    {
                        giaend = giacodinh[0] + giacodinh[1] + giacodinh[2] + giacodinh[3];
                    }
                    sum += int.Parse(giaend);
                }
            }
            foreach (var dvno in listnologin)
            {
                if (ThangTK == dvno.NgayDat2.Value.Month.ToString() && NamTK == dvno.NgayDat2.Value.Year.ToString())
                {
                    sohd++;
                    var giaend2 = "";
                    var giacodinh2 = dvno.tienthanhtoan.Split('.');
                    if (giacodinh2.Length == 3)
                    {
                        giaend2 = giacodinh2[0] + giacodinh2[1] + giacodinh2[2];
                    }
                    else if (giacodinh2.Length == 2)
                    {
                        giaend2 = giacodinh2[0] + giacodinh2[1];
                    }
                    else if (giacodinh2.Length == 4)
                    {
                        giaend2 = giacodinh2[0] + giacodinh2[1] + giacodinh2[2] + giacodinh2[3];
                    }
                    sum += int.Parse(giaend2);
                }
            }

            DateTime now = DateTime.Now;
            string id = Content.RandomString(8);

            DOANHTHU dt = new DOANHTHU();
            dt.idDoanhThu = id;
            dt.ThangNamTK = now;
            dt.TongSoHD = sohd;
            dt.TongDT = sum;
            dt.TitleTK = "Admin" ;
            dt.ThangdcTk = ThangTK;
            dt.NamdcTk = NamTK;
            db.DOANHTHUs.Add(dt);
            db.SaveChanges();
        }

        public void xoadoanhthu(string id)
        {
            DOANHTHU x = layOnedt(id);
            db.DOANHTHUs.Remove(x);
            db.SaveChanges();
        }
    }
}