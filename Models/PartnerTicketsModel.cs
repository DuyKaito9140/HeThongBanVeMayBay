using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class PartnerTicketsModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<VEMAYBAY> Listvemaybay()
        {
            return db.VEMAYBAYs.ToList();
        }

        public VEMAYBAY layOnevemaybay(string id)
        {
            return db.VEMAYBAYs.First(m => m.idVe == id);
        }

        public void them_vemaybay(VEMAYBAY vmb)
        {           
            int soVe = int.Parse(vmb.idVe);
            string[] idmb = vmb.idChuyenBay.Split(' ');
            vmb.idChuyenBay = idmb[0];           
            for (int i = 0; i < soVe; i++)
            {
                VEMAYBAY x = new VEMAYBAY();
                string idvemb = Content.RandomString(9);
                x.idVe = idvemb + i;
                x.idChuyenBay = vmb.idChuyenBay;
                x.SoKgHanhLy = vmb.SoKgHanhLy;
                x.GiaVe = vmb.GiaVe;
                if (i < 16)
                {
                    x.idLoaiVe = "lv004";
                }
                else if (i >= 16 && i < 40)
                {
                    x.idLoaiVe = "lv003";
                }
                else if (i >= 40 && i < 72)
                {
                    x.idLoaiVe = "lv002";
                }
                else
                {
                    x.idLoaiVe = "lv001";
                }
                db.VEMAYBAYs.Add(x);
                db.SaveChanges();
            }           
        }

        public void sua_vemaybay(VEMAYBAY vmb)
        {
            string[] idcb = vmb.idChuyenBay.Split(' ');
            string[] idlv = vmb.idLoaiVe.Split(' ');

            VEMAYBAY x = layOnevemaybay(vmb.idVe);
            x.idChuyenBay = idcb[0];
            x.idLoaiVe = idlv[0];
            x.SoKgHanhLy = vmb.SoKgHanhLy;
            x.GiaVe = vmb.GiaVe;
            db.SaveChanges();
        }

        public void xoa_vemaybay(string id)
        {
            VEMAYBAY x = layOnevemaybay(id);
            db.VEMAYBAYs.Remove(x);
            db.SaveChanges();
        }        
    }
}